//-----------------------------------------------------------------------
// <copyright file= "BasicRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/4 星期三 15:16:23
// Modified by:
// Description: Administrator-Basic-功能实现仓储
//-----------------------------------------------------------------------
using LinqKit;
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.Basic;
using PSU.Entity.School;
using PSU.Model.Areas.Administrator.Basic;
using PSU.Utility;
using PSU.Utility.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Repository.Areas.Administrator
{
    public class BasicRepository
    {
        #region Profile API

        /// <summary>
        /// 获取个人账户信息
        /// </summary>
        /// <param name="id">账户编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<IdentityUser> GetProfileAsync(long id, ApplicationDbContext context)
        {
            var model = await context.IdentityUser.AsNoTracking().Where(i => i.Id == id).FirstOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 更新个人信息
        /// </summary>
        /// <param name="webModel">编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateAsync(ProfileViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.IdentityUser.FirstOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));

            if (model == null)
            {
                return;
            }

            model.Address = webModel.Address;
            model.Age = webModel.Age;
            model.Gender = webModel.Gender;
            model.Phone = webModel.Phone;
            model.Email = webModel.Email;
            model.ModifiedOn = DateTime.Now;
            model.ModifiedBy = CurrentUser.UserOID;
            model.ModifiedName = CurrentUser.UserName;
        }

        #endregion

        #region Staff API

        /// <summary>
        /// 根据搜索条件获取教职工列表
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<IdentityUser>> GetListAsync(StaffViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SId) && string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SDepartment))
            {
                return await context.Set<IdentityUser>().AsNoTracking().Where(i => i.AccountType == 1).Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                IQueryable<IdentityUser> staves = context.IdentityUser.AsQueryable();

                var predicate = PredicateBuilder.New<IdentityUser>();

                //教职工账户
                predicate = predicate.And(i => i.AccountType == 1);

                //教职工工号
                if (!string.IsNullOrEmpty(webModel.SId))
                {
                    predicate = predicate.And(i => i.Id == Convert.ToInt64(webModel.SId));
                }

                //教职工姓名
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //教职工所属部门
                if (!string.IsNullOrEmpty(webModel.SDepartment))
                {
                    predicate = predicate.And(i => i.Department == webModel.SDepartment);
                }

                return await staves.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 根据搜索条件获取学生列表数目
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(StaffViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SId) && string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SDepartment))
            {
                var list = await context.Set<IdentityUser>().AsNoTracking().Where(i => i.AccountType == 2).OrderByDescending(i => i.CreatedOn).ToListAsync();
                return list.Count();
            }
            else
            {
                IQueryable<IdentityUser> staves = context.IdentityUser.AsQueryable();

                var predicate = PredicateBuilder.New<IdentityUser>();

                //教职工账户
                predicate = predicate.And(i => i.AccountType == 1);

                //教职工工号
                if (!string.IsNullOrEmpty(webModel.SId))
                {
                    predicate = predicate.And(i => i.Id == Convert.ToInt64(webModel.SId));
                }

                //教职工姓名
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //教职工所属部门
                if (!string.IsNullOrEmpty(webModel.SDepartment))
                {
                    predicate = predicate.And(i => i.Department == webModel.SDepartment);
                }

                var list = await staves.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
            }
        }

        /// <summary>
        /// 新增教职工信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<IdentityUser> InsertAsync(StaffEditViewModel webModel, ApplicationDbContext context)
        {
            //Get Foreign Key Association Table Information
            //
            var department = await context.Department.AsNoTracking().Where(i => i.Id == Convert.ToInt64(webModel.DepartmentId)).FirstOrDefaultAsync();

            //return error 
            if (department == null)
            {
                return new IdentityUser
                {
                    Id = -1
                };
            }

            var model = InsertModel(webModel);

            model.DepartmentId = Convert.ToInt64(webModel.DepartmentId);
            model.Department = department.Name;

            await context.IdentityUser.AddAsync(model);

            return model;
        }

        /// <summary>
        /// 更新教职工信息
        /// </summary>
        /// <param name="webModel">专业班级编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateAsync(StaffEditViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.IdentityUser.FirstOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));

            if (model == null)
            {
                return;
            }

            model = UpdateModel(webModel, model);

            //Get Foreign Key Association Table Information
            var department = await context.Department.Where(i => i.Id == Convert.ToInt64(webModel.DepartmentId)).FirstOrDefaultAsync();

            model.DepartmentId = Convert.ToInt64(webModel.DepartmentId);
            model.Department = department.Name;
        }

        #endregion

        #region Student API

        /// <summary>
        /// 根据搜索条件获取学生列表
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<IdentityUser>> GetListAsync(StudentViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SId) && string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SMajorClass))
            {
                return await context.Set<IdentityUser>().AsNoTracking().Where(i => i.AccountType == 2).Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                IQueryable<IdentityUser> students = context.IdentityUser.AsQueryable();

                var predicate = PredicateBuilder.New<IdentityUser>();

                //学生账户
                predicate = predicate.And(i => i.AccountType == 2);

                //学生学号
                if (!string.IsNullOrEmpty(webModel.SId))
                {
                    predicate = predicate.And(i => i.Id == Convert.ToInt64(webModel.SId));
                }

                //学生姓名
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //学生所属班级
                if (!string.IsNullOrEmpty(webModel.SMajorClass))
                {
                    predicate = predicate.And(i => i.MajorClass == webModel.SMajorClass);
                }

                return await students.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 根据搜索条件获取学生列表数目
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(StudentViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SId) && string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SMajorClass))
            {
                var list = await context.Set<IdentityUser>().AsNoTracking().Where(i => i.AccountType == 2).OrderByDescending(i => i.CreatedOn).ToListAsync();
                return list.Count();
            }
            else
            {
                IQueryable<IdentityUser> students = context.IdentityUser.AsQueryable();

                var predicate = PredicateBuilder.New<IdentityUser>();

                //学生账户
                predicate = predicate.And(i => i.AccountType == 2);

                //学生学号
                if (!string.IsNullOrEmpty(webModel.SId))
                {
                    predicate = predicate.And(i => i.Id == Convert.ToInt64(webModel.SId));
                }

                //学生姓名
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //学生所属班级
                if (!string.IsNullOrEmpty(webModel.SMajorClass))
                {
                    predicate = predicate.And(i => i.MajorClass == webModel.SMajorClass);
                }

                var list = await students.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
            }
        }

        /// <summary>
        /// 新增学生信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<IdentityUser> InsertAsync(StudentEditViewModel webModel, ApplicationDbContext context)
        {
            //Get Foreign Key Association Table Information
            //
            var majorclass = await context.MajorClass.AsNoTracking().Where(i => i.Id == Convert.ToInt64(webModel.MajorClassId)).FirstOrDefaultAsync();
            var department = await context.Department.AsNoTracking().Where(i => i.Id == Convert.ToInt64(webModel.DepartmentId)).FirstOrDefaultAsync();

            //return error 
            if (majorclass == null || department == null)
            {
                return new IdentityUser
                {
                    Id = -1
                };
            }

            var model = InsertModel(webModel);

            model.MajorClassId = Convert.ToInt64(webModel.MajorClassId);
            model.MajorClass = majorclass.Name;

            model.InstructorId = majorclass.InstructorId;
            model.InstructorName = majorclass.InstructorName;

            model.DepartmentId = Convert.ToInt64(webModel.DepartmentId);
            model.Department = department.Name;

            await context.IdentityUser.AddAsync(model);

            return model;
        }

        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="webModel">专业班级编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateAsync(StudentEditViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.IdentityUser.FirstOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));

            if (model == null)
            {
                return;
            }

            model = UpdateModel(webModel, model);

            //Get Foreign Key Association Table Information
            //
            var majorclass = await context.MajorClass.AsNoTracking().Where(i => i.Id == Convert.ToInt64(webModel.MajorClassId)).FirstOrDefaultAsync();
            var department = await context.Department.AsNoTracking().Where(i => i.Id == Convert.ToInt64(webModel.DepartmentId)).FirstOrDefaultAsync();

            //return error 
            if (majorclass == null || department == null)
            {
                return;
            }

            model.MajorClassId = Convert.ToInt64(webModel.MajorClassId);
            model.MajorClass = majorclass.Name;

            model.InstructorId = majorclass.InstructorId;
            model.InstructorName = majorclass.InstructorName;

            model.DepartmentId = Convert.ToInt64(webModel.DepartmentId);
            model.Department = department.Name;
        }

        #endregion

        #region Common API

        /// <summary>
        /// 获取部门下拉
        /// </summary>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Department>> GetDepartmentList(ApplicationDbContext context)
        {
            return await context.Department.AsNoTracking().Where(i => i.IsEnabled == true).ToListAsync();
        }

        /// <summary>
        /// 获取专业班级下拉
        /// </summary>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<MajorClass>> GetMajorClassList(ApplicationDbContext context)
        {
            return await context.MajorClass.AsNoTracking().Where(i => i.IsEnabled == true).ToListAsync();
        }

        /// <summary>
        /// 删除账户信息
        /// </summary>
        /// <param name="id">账户编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task DeleteStaffAsync(long id, ApplicationDbContext context)
        {
            var model = await context.IdentityUser.FirstOrDefaultAsync(i => i.Id == id);

            context.Remove(model);
        }

        #endregion

        #region Method-Insert

        /// <summary>
        /// Insert Identity Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        private static IdentityUser InsertModel(StaffEditViewModel webModel)
        {
            var salt = Guid.NewGuid().ToString();
            return new IdentityUser
            {
                Account = webModel.Account,
                AccountType = 1,
                Salt = salt,
                Password = MD5Utility.Sign(webModel.Password, salt),
                Email = webModel.Email,
                Phone = webModel.Phone,
                Name = webModel.Name,
                Gender = webModel.Gender,
                IdNumber = webModel.IdNumber,
                Wechat = webModel.Wechat,
                QQ = Convert.ToInt64(webModel.QQ),
                IsEnabled = (int)webModel.IsEnabled == 1,
                IsMaster = webModel.IsMaster,
                Address = webModel.Address,
                Age = webModel.Age,
                HomePage = "Instructor",
                CreatedId = CurrentUser.UserId,
                CreatedBy = CurrentUser.UserOID,
                CreatedName = CurrentUser.UserName
            };
        }

        /// <summary>
        /// Insert Identity Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        private static IdentityUser InsertModel(StudentEditViewModel webModel)
        {
            var salt = Guid.NewGuid().ToString();
            return new IdentityUser
            {
                Account = webModel.Account,
                AccountType = 2,
                Salt = salt,
                Password = MD5Utility.Sign(webModel.Password, salt),
                Email = webModel.Email,
                Phone = webModel.Phone,
                Name = webModel.Name,
                Gender = webModel.Gender,
                IdNumber = webModel.IdNumber,
                Wechat = webModel.Wechat,
                QQ = Convert.ToInt64(webModel.QQ),
                IsEnabled = (int)webModel.IsEnabled == 1,
                Address = webModel.Address,
                Age = webModel.Age,
                HomePage = "Student",
                Birthday = Convert.ToDateTime(webModel.Birthday),
                City = webModel.City,
                CityId = webModel.CityId,
                District = webModel.District,
                DistrictId = webModel.DistrictId,
                EndDate = Convert.ToDateTime(webModel.EndDate),
                HighSchool = webModel.HighSchool,
                Province = webModel.Province,
                ProvinceId = webModel.ProvinceId,
                Hobbies = webModel.Hobbies,
                StartDate = Convert.ToDateTime(webModel.StartDate),
                TicketId = Convert.ToInt64(webModel.TicketId),
                Winning = webModel.Winning,
                CreatedId = CurrentUser.UserId,
                CreatedBy = CurrentUser.UserOID,
                CreatedName = CurrentUser.UserName
            };
        }

        #endregion

        #region Method-Update

        /// <summary>
        /// Update Identity Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private static IdentityUser UpdateModel(StaffEditViewModel webModel, IdentityUser model)
        {
            model.Account = webModel.Account;
            model.Password = MD5Utility.Sign(webModel.Password, model.Salt);
            model.Email = webModel.Email;
            model.Phone = webModel.Phone;
            model.Name = webModel.Name;
            model.Gender = webModel.Gender;
            model.IdNumber = webModel.IdNumber;
            model.Wechat = webModel.Wechat;
            model.QQ = Convert.ToInt64(webModel.QQ);
            model.IsEnabled = (int)webModel.IsEnabled == 1;
            model.IsMaster = webModel.IsMaster;
            model.Address = webModel.Address;
            model.Age = webModel.Age;
            model.ModifiedOn = DateTime.Now;
            model.ModifiedId = CurrentUser.UserId;
            model.ModifiedBy = CurrentUser.UserOID;
            model.ModifiedName = CurrentUser.UserName;

            return model;
        }

        /// <summary>
        /// Update Identity Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private static IdentityUser UpdateModel(StudentEditViewModel webModel, IdentityUser model)
        {
            model.Account = webModel.Account;
            model.Password = MD5Utility.Sign(webModel.Password, model.Salt);
            model.Email = webModel.Email;
            model.Phone = webModel.Phone;
            model.Name = webModel.Name;
            model.Gender = webModel.Gender;
            model.IdNumber = webModel.IdNumber;
            model.Wechat = webModel.Wechat;
            model.QQ = Convert.ToInt64(webModel.QQ);
            model.IsEnabled = (int)webModel.IsEnabled == 1;
            model.Address = webModel.Address;
            model.Age = webModel.Age;
            model.Birthday = Convert.ToDateTime(webModel.Birthday);
            model.City = webModel.City;
            model.CityId = webModel.CityId;
            model.District = webModel.District;
            model.DistrictId = webModel.DistrictId;
            model.EndDate = Convert.ToDateTime(webModel.EndDate);
            model.HighSchool = webModel.HighSchool;
            model.Province = webModel.Province;
            model.ProvinceId = webModel.ProvinceId;
            model.Hobbies = webModel.Hobbies;
            model.StartDate = Convert.ToDateTime(webModel.StartDate);
            model.TicketId = Convert.ToInt64(webModel.TicketId);
            model.Winning = webModel.Winning;
            model.ModifiedOn = DateTime.Now;
            model.ModifiedId = CurrentUser.UserId;
            model.ModifiedBy = CurrentUser.UserOID;
            model.ModifiedName = CurrentUser.UserName;

            return model;
        }

        #endregion
    }
}
