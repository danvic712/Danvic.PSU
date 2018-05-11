//-----------------------------------------------------------------------
// <copyright file= "RegisterRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-06 22:58:33
// Modified by:
// Description: Student-Register-功能实现仓储
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.Admission;
using PSU.Entity.Dormitory;
using PSU.Entity.SignUp;
using PSU.Model.Areas.Student;
using PSU.Repository.Areas.Administrator;
using PSU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSU.Repository.Areas.Student
{
    public class RegisterRepository
    {
        #region Information-API

        /// <summary>
        /// 获取报名信息
        /// </summary>
        /// <param name="id">报名编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Register> GetEntityAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Register.AsNoTracking().Where(i => i.StudentId == id).FirstOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 新增教职工信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Register> InsertAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            //Get Foreign Key Association Table Information
            //
            var user = await context.IdentityUser.AsNoTracking().Where(i => i.Id == CurrentUser.UserId).FirstOrDefaultAsync();

            //return error 
            if (user == null)
            {
                return new Register
                {
                    Id = -1
                };
            }

            var model = InsertModel(webModel);

            model.Department = user.Department;
            model.DepartmentId = user.DepartmentId;
            model.Instructor = user.InstructorName;
            model.InstructorId = user.InstructorId;
            model.MajorClass = user.MajorClass;
            model.MajorClassId = user.MajorClassId;
            model.Name = user.Name;
            model.StudentId = user.Id;

            await context.Register.AddAsync(model);

            return model;
        }

        #endregion

        #region Booking-API

        /// <summary>
        /// 获取迎新服务信息
        /// </summary>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Service>> GetServiceListAsync(ApplicationDbContext context)
        {
            var model = await context.Service.AsNoTracking().Where(i => i.IsEnabled == true).ToListAsync();
            return model;
        }

        /// <summary>
        /// 获取迎新服务信息
        /// </summary>
        /// <param name="id">迎新服务编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<ServiceInfo> GetServiceAsync(long id, ApplicationDbContext context)
        {
            var model = await context.ServiceInfo.AsNoTracking().Where(i => i.ServiceId == id && i.StudentId == CurrentUser.UserId).FirstOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 新增服务预定信息
        /// </summary>
        /// <param name="webModel">服务预定页视图Model</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<ServiceInfo> InsertAsync(BookingServiceViewModel webModel, ApplicationDbContext context)
        {
            ServiceInfo model = InsertModel(webModel);

            var user = await PSURepository.GetUserByIdAsync(CurrentUser.UserId, context);
            var service = await AdmissionRepository.GetServiceAsync(Convert.ToInt64(webModel.ServiceId), context);

            if (user == null || service == null)
            {
                return new ServiceInfo
                {
                    Id = -1
                };
            }

            if (!(Convert.ToDateTime(webModel.DepartureTime) >= service.StartTime && Convert.ToDateTime(webModel.DepartureTime) <= service.EndTime))
            {
                return new ServiceInfo
                {
                    Id = -2
                };
            }

            model.StudentId = user.Id;
            model.Name = user.Name;

            model.ServiceId = service.Id;
            model.ServiceName = service.Name;

            await context.ServiceInfo.AddAsync(model);

            return model;
        }

        #endregion

        #region Goods-API

        /// <summary>
        /// 获取物品信息
        /// </summary>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Goods>> GetGoodsListAsync(ApplicationDbContext context)
        {
            var model = await context.Goods.AsNoTracking().Where(i => i.IsEnabled == true).ToListAsync();
            return model;
        }

        /// <summary>
        /// 获取物品信息
        /// </summary>
        /// <param name="id">物品编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<GoodsInfo> GetGoodsAsync(long id, ApplicationDbContext context)
        {
            var model = await context.GoodsInfo.AsNoTracking().Where(i => i.GoodsId == id && i.StudentId == CurrentUser.UserId).FirstOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 新增物品选择信息
        /// </summary>
        /// <param name="webModel">物品选择页视图Model</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<GoodsInfo> InsertAsync(GoodsChosenViewModel webModel, ApplicationDbContext context)
        {
            GoodsInfo model = InsertModel(webModel);

            var user = await PSURepository.GetUserByIdAsync(CurrentUser.UserId, context);
            var goods = await AdmissionRepository.GetGoodsAsync(Convert.ToInt64(webModel.GoodsId), context);

            if (user == null || goods == null)
            {
                return new GoodsInfo
                {
                    Id = -1
                };
            }

            model.StudentId = user.Id;
            model.StudentName = user.Name;

            model.GoodsId = goods.Id;
            model.GoodsName = goods.Name;

            await context.GoodsInfo.AddAsync(model);

            return model;
        }

        #endregion

        #region Dormitory-API

        /// <summary>
        /// 获取寝室信息
        /// </summary>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Dorm>> GetDormitoryListAsync(ApplicationDbContext context)
        {
            var user = await PSURepository.GetUserByIdAsync(CurrentUser.UserId, context);
            int gender = user.Gender ? 1 : 2;
            var model = await context.Dorm.AsNoTracking().Where(i => i.IsEnabled == true && i.Count > i.SelectedCount && (i.Type == 3 || i.Type == gender)).ToListAsync();
            return model;
        }

        /// <summary>
        /// 获取寝室选择信息
        /// </summary>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<BunkInfo> GetDormitoryAsync(ApplicationDbContext context)
        {
            var model = await context.BunkInfo.AsNoTracking().Where(i => i.StudentId == CurrentUser.UserId).FirstOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 选择寝室信息
        /// </summary>
        /// <param name="id">寝室编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<BunkInfo> InsertAsync(long id, ApplicationDbContext context)
        {
            var user = await PSURepository.GetUserByIdAsync(CurrentUser.UserId, context);
            var dorm = await DormitoryRepository.GetDormAsync(id, context);

            //数据不准确
            if (user == null || dorm == null)
            {
                return new BunkInfo
                {
                    Id = -1
                };
            }

            // 寝室已被选完
            if (dorm.SelectedCount == dorm.Count)
            {
                return new BunkInfo
                {
                    Id = -2
                };
            }

            dorm.SelectedCount = Convert.ToInt16(dorm.SelectedCount + 1);

            BunkInfo model = new BunkInfo
            {
                BuildingId = dorm.BuildingId,
                BuildingName = dorm.BuildingName,
                Chosen = dorm.SelectedCount,
                Count = dorm.Count,
                DormId = dorm.Id,
                DormName = dorm.Name,
                Floor = dorm.Floor,
                InstructorId = user.InstructorId,
                MajorClassId = user.MajorClassId,
                MajorClassName = user.MajorClass,
                StudentId = user.Id,
                StudentName = user.Name,
                BunkType = dorm.BunkName,
            };

            await context.BunkInfo.AddAsync(model);

            return model;
        }

        #endregion

        #region Method-Insert

        /// <summary>
        /// Insert Register Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        private static Register InsertModel(InformationViewModel webModel)
        {
            return new Register
            {
                ArriveTime = Convert.ToDateTime(webModel.ArriveTime),
                DateTime = DateTime.Now,
                ExpressId = webModel.ExpressId,
                IsExpress = webModel.IsExpress,
                Place = webModel.Place,
                Remark = webModel.Remark,
                Way = webModel.Way
            };
        }

        /// <summary>
        /// Insert ServiceInfo Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        private static ServiceInfo InsertModel(BookingServiceViewModel webModel)
        {
            return new ServiceInfo
            {
                Count = webModel.Count,
                DepartureTime = Convert.ToDateTime(webModel.DepartureTime),
                IsCancel = false,
                Tel = webModel.Tel,
                Place = webModel.Place,
                Remark = webModel.Remark,
            };
        }

        /// <summary>
        /// Insert GoodsInfo Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        private static GoodsInfo InsertModel(GoodsChosenViewModel webModel)
        {
            return new GoodsInfo
            {
                Size = webModel.Size,
                Remark = webModel.Remark,
            };
        }

        #endregion
    }
}
