//-----------------------------------------------------------------------
// <copyright file= "SchoolRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-11 20:59:20
// Modified by:
// Description: Administrator-School-首页功能实现仓储
//-----------------------------------------------------------------------
using LinqKit;
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.Basic;
using PSU.Entity.School;
using PSU.Model.Areas.Administrator.School;
using PSU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Repository.Areas.Administrator
{
    public class SchoolRepository
    {
        #region Department API

        /// <summary>
        /// 删除院系信息
        /// </summary>
        /// <param name="id">院系编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task DeleteAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Department.FirstOrDefaultAsync(i => i.Id == id);

            context.Remove(model);
        }

        /// <summary>
        /// 获取院系信息
        /// </summary>
        /// <param name="id">院系编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Department> GetAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Department.AsNoTracking().Where(i => i.Id == id).FirstOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 根据搜索条件获取院系信息
        /// </summary>
        /// <param name="webModel">院系列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Department>> GetListAsync(DepartmentViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SId) && string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.STel))
            {
                return await context.Set<Department>().AsNoTracking().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                IQueryable<Department> departments = context.Department.AsQueryable();

                var predicate = PredicateBuilder.New<Department>();

                //院系编号
                if (!string.IsNullOrEmpty(webModel.SId))
                {
                    predicate = predicate.And(i => i.Id == Convert.ToInt64(webModel.SId));
                }

                //院系名称
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //院系联系方式
                if (!string.IsNullOrEmpty(webModel.STel))
                {
                    predicate = predicate.And(i => i.Tel == webModel.STel);
                }

                return await departments.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 根据搜索条件获取院系信息列表数目
        /// </summary>
        /// <param name="webModel">院系列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(DepartmentViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SId) && string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.STel))
            {
                var list = await context.Set<Department>().AsNoTracking().OrderByDescending(i => i.CreatedOn).ToListAsync();
                return list.Count();
            }
            else
            {
                IQueryable<Department> departments = context.Department.AsQueryable();

                var predicate = PredicateBuilder.New<Department>();

                //院系编号
                if (!string.IsNullOrEmpty(webModel.SId))
                {
                    predicate = predicate.And(i => i.Id == Convert.ToInt64(webModel.SId));
                }

                //院系名称
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //院系联系方式
                if (!string.IsNullOrEmpty(webModel.STel))
                {
                    predicate = predicate.And(i => i.Tel == webModel.STel);
                }

                var list = await departments.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
            }
        }

        /// <summary>
        /// 新增院系信息
        /// </summary>
        /// <param name="webModel">院系编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Department> InsertAsync(DepartmentEditViewModel webModel, ApplicationDbContext context)
        {
            Department model = InsertModel(webModel);

            await context.Department.AddAsync(model);

            return model;
        }

        /// <summary>
        /// 更新院系信息
        /// </summary>
        /// <param name="webModel">院系编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateAsync(DepartmentEditViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.Department.FirstOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));

            if (model == null)
            {
                return;
            }

            model = UpdateModel(webModel, model);
        }

        #endregion

        #region MajorClass API

        /// <summary>
        /// 删除专业班级信息
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task DeleteMajorClassAsync(long id, ApplicationDbContext context)
        {
            var model = await context.MajorClass.FirstOrDefaultAsync(i => i.Id == id);

            context.Remove(model);
        }

        /// <summary>
        /// 获取部门下拉
        /// </summary>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Department>> GetDepartmentList(ApplicationDbContext context)
        {
            return await context.Department.AsNoTracking().Where(i => i.IsEnabled == true && i.IsBranch == false).ToListAsync();
        }

        /// <summary>
        /// 根据搜索条件获取专业班级信息
        /// </summary>
        /// <param name="webModel">专业班级列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<MajorClass>> GetListAsync(MajorClassViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SClassName) && string.IsNullOrEmpty(webModel.SInstructorName) && string.IsNullOrEmpty(webModel.SMajorName))
            {
                return await context.Set<MajorClass>().AsNoTracking().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                IQueryable<MajorClass> majorClasses = context.MajorClass.AsQueryable();

                var predicate = PredicateBuilder.New<MajorClass>();

                //班级名称
                if (!string.IsNullOrEmpty(webModel.SClassName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SClassName);
                }

                //导员名称
                if (!string.IsNullOrEmpty(webModel.SInstructorName))
                {
                    predicate = predicate.And(i => i.InstructorName == webModel.SInstructorName);
                }

                //专业名称
                if (!string.IsNullOrEmpty(webModel.SMajorName))
                {
                    predicate = predicate.And(i => i.MajorName == webModel.SMajorName);
                }

                return await majorClasses.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 根据搜索条件获取专业班级信息列表个数
        /// </summary>
        /// <param name="webModel">专业班级列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(MajorClassViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SClassName) && string.IsNullOrEmpty(webModel.SInstructorName) && string.IsNullOrEmpty(webModel.SMajorName))
            {
                var list = await context.Set<MajorClass>().AsNoTracking().OrderByDescending(i => i.CreatedOn).ToListAsync();
                return list.Count();
            }
            else
            {
                IQueryable<MajorClass> majorClasses = context.MajorClass.AsQueryable();

                var predicate = PredicateBuilder.New<MajorClass>();

                //班级名称
                if (!string.IsNullOrEmpty(webModel.SClassName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SClassName);
                }

                //导员名称
                if (!string.IsNullOrEmpty(webModel.SInstructorName))
                {
                    predicate = predicate.And(i => i.InstructorName == webModel.SInstructorName);
                }

                //专业名称
                if (!string.IsNullOrEmpty(webModel.SMajorName))
                {
                    predicate = predicate.And(i => i.MajorName == webModel.SMajorName);
                }

                var list = await majorClasses.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
            }
        }

        /// <summary>
        /// 获取专业班级信息
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<MajorClass> GetMajorClassAsync(long id, ApplicationDbContext context)
        {
            var model = await context.MajorClass.AsNoTracking().Where(i => i.Id == id).FirstOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 获取职工下拉
        /// </summary>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Staff>> GetStaffList(ApplicationDbContext context)
        {
            return await context.Staff.AsNoTracking().Where(i => i.IsEnabled).ToListAsync();
        }

        /// <summary>
        /// 新增专业班级信息
        /// </summary>
        /// <param name="webModel">专业班级编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<MajorClass> InsertAsync(MajorClassEditViewModel webModel, ApplicationDbContext context)
        {
            var model = InsertModel(webModel);

            //Get Foreign Key Association Table Information
            //
            var staff = await context.Staff.AsNoTracking().Where(i => i.Id == Convert.ToInt64(webModel.InstructorId)).FirstOrDefaultAsync();
            var department = await context.Department.AsNoTracking().Where(i => i.Id == Convert.ToInt64(webModel.DepartmentId)).FirstOrDefaultAsync();

            //return error 
            if (staff == null || department == null)
            {
                return new MajorClass
                {
                    Id = -1
                };
            }

            model.InstructorId = Convert.ToInt64(webModel.InstructorId);
            model.InstructorFK = staff.StaffOID;
            model.InstructorName = staff.Name;

            model.DepartmentId = Convert.ToInt64(webModel.DepartmentId);
            model.DepartmentFK = department.DepartmentOID;
            model.DepartmentName = department.Name;

            await context.MajorClass.AddAsync(model);

            return model;
        }

        /// <summary>
        /// 更新专业班级信息
        /// </summary>
        /// <param name="webModel">专业班级编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateAsync(MajorClassEditViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.MajorClass.FirstOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));

            if (model == null)
            {
                return;
            }

            model = UpdateModel(webModel, model);

            //Get Foreign Key Association Table Information
            //
            var staff = await context.Staff.Where(i => i.Id == Convert.ToInt64(webModel.InstructorId)).FirstOrDefaultAsync();
            var department = await context.Department.Where(i => i.Id == Convert.ToInt64(webModel.DepartmentId)).FirstOrDefaultAsync();

            model.InstructorId = Convert.ToInt64(webModel.InstructorId);
            model.InstructorFK = staff.StaffOID;
            model.InstructorName = staff.Name;

            model.DepartmentId = Convert.ToInt64(webModel.DepartmentId);
            model.DepartmentFK = department.DepartmentOID;
            model.DepartmentName = department.Name;
        }

        #endregion

        #region Method

        /// <summary>
        /// Insert Department Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        private static Department InsertModel(DepartmentEditViewModel webModel)
        {
            return new Department
            {
                Address = string.IsNullOrEmpty(webModel.Address) ? "" : webModel.Address,
                Weibo = string.IsNullOrEmpty(webModel.Weibo) ? "" : webModel.Weibo,
                Wechat = string.IsNullOrEmpty(webModel.Wechat) ? "" : webModel.Wechat,
                Tel = string.IsNullOrEmpty(webModel.Tel) ? "" : webModel.Tel,
                QQ = string.IsNullOrEmpty(webModel.QQ) ? "" : webModel.QQ,
                Name = string.IsNullOrEmpty(webModel.Name) ? "" : webModel.Name,
                IsBranch = (int)webModel.IsBranch == 1,
                Email = string.IsNullOrEmpty(webModel.Email) ? "" : webModel.Email,
                Introduction = string.IsNullOrEmpty(webModel.Introduction) ? "" : webModel.Introduction,
                IsEnabled = (int)webModel.IsEnabled == 1,
                CreatedBy = string.IsNullOrEmpty(CurrentUser.UserOID) ? "" : CurrentUser.UserOID,
                CreatedName = string.IsNullOrEmpty(CurrentUser.UserName) ? "" : CurrentUser.UserName
            };
        }

        /// <summary>
        /// Insert Major Class Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        private static MajorClass InsertModel(MajorClassEditViewModel webModel)
        {
            return new MajorClass
            {
                MajorCode = Convert.ToInt32(webModel.MajorCode),
                IsEnabled = (int)webModel.IsEnabled == 1,
                MajorName = webModel.MajorName,
                SessionNum = webModel.SessionNum,
                Wechat = webModel.Wechat,
                QQ = webModel.QQ,
                InstructorId = Convert.ToInt64(webModel.InstructorId),
                DepartmentId = Convert.ToInt64(webModel.DepartmentId),
                CreatedBy = CurrentUser.UserOID,
                CreatedName = CurrentUser.UserName
            };
        }

        /// <summary>
        /// Update Department Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <param name="model"></param>
        private static Department UpdateModel(DepartmentEditViewModel webModel, Department model)
        {
            model.Address = webModel.Address;
            model.Weibo = webModel.Weibo;
            model.Wechat = webModel.Wechat;
            model.Tel = webModel.Tel;
            model.QQ = webModel.QQ;
            model.Name = webModel.Name;
            model.IsBranch = (int)webModel.IsBranch == 1;
            model.Email = webModel.Email;
            model.Introduction = webModel.Introduction;
            model.IsEnabled = (int)webModel.IsEnabled == 1;
            model.ModifiedOn = DateTime.Now;
            model.ModifiedBy = CurrentUser.UserOID;
            model.ModifiedName = CurrentUser.UserName;

            return model;
        }

        /// <summary>
        /// Update Major Class Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <param name="model"></param>
        private static MajorClass UpdateModel(MajorClassEditViewModel webModel, MajorClass model)
        {
            model.MajorCode = Convert.ToInt32((webModel.MajorCode));
            model.IsEnabled = (int)webModel.IsEnabled == 1;
            model.MajorName = webModel.MajorName;
            model.SessionNum = webModel.SessionNum;
            model.Wechat = webModel.Wechat;
            model.QQ = webModel.QQ;
            model.InstructorId = Convert.ToInt64(webModel.InstructorId);
            model.DepartmentId = Convert.ToInt64(webModel.DepartmentId);
            model.ModifiedOn = DateTime.Now;
            model.ModifiedBy = CurrentUser.UserOID;
            model.ModifiedName = CurrentUser.UserName;

            return model;
        }

        #endregion
    }
}
