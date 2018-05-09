//-----------------------------------------------------------------------
// <copyright file= "UserRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:32:30
// Modified by:
// Description: Instructor-User-功能实现仓储
//-----------------------------------------------------------------------
using LinqKit;
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.School;
using PSU.Model.Areas.Instructor.User;
using PSU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Repository.Areas.Instructor
{
    public class UserRepository
    {
        #region Class API

        /// <summary>
        /// 获取班级信息
        /// </summary>
        /// <param name="id">班级编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<MajorClass> GetClassAsync(long id, ApplicationDbContext context)
        {
            var model = await context.MajorClass.AsNoTracking().Where(i => i.Id == id).FirstOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 根据搜索条件获取我的班级信息
        /// </summary>
        /// <param name="webModel">专业班级列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<MajorClass>> GetListAsync(ClassViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SMajor) && string.IsNullOrEmpty(webModel.SQQ))
            {
                return await context.Set<MajorClass>().AsNoTracking().Where(i => i.InstructorId == CurrentUser.UserId && i.IsEnabled == true)
                    .Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                IQueryable<MajorClass> majorClasses = context.MajorClass.AsQueryable();

                var predicate = PredicateBuilder.New<MajorClass>();

                //当前登录人数据
                predicate = predicate.And(i => i.InstructorId == CurrentUser.UserId && i.IsEnabled == true);

                //班级名称
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //专业名称
                if (!string.IsNullOrEmpty(webModel.SMajor))
                {
                    predicate = predicate.And(i => i.MajorName == webModel.SMajor);
                }

                //班级QQ
                if (!string.IsNullOrEmpty(webModel.SQQ))
                {
                    predicate = predicate.And(i => i.QQ == webModel.SQQ);
                }

                return await majorClasses.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 根据搜索条件获取我的班级信息列表个数
        /// </summary>
        /// <param name="webModel">我的班级列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(ClassViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SMajor) && string.IsNullOrEmpty(webModel.SQQ))
            {
                var list = await context.Set<MajorClass>().AsNoTracking().Where(i => i.InstructorId == CurrentUser.UserId && i.IsEnabled == true)
                    .OrderByDescending(i => i.CreatedOn).ToListAsync();
                return list.Count();
            }
            else
            {
                IQueryable<MajorClass> majorClasses = context.MajorClass.AsQueryable();

                var predicate = PredicateBuilder.New<MajorClass>();

                //当前登录人数据
                predicate = predicate.And(i => i.InstructorId == CurrentUser.UserId && i.IsEnabled == true);

                //班级名称
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //专业名称
                if (!string.IsNullOrEmpty(webModel.SMajor))
                {
                    predicate = predicate.And(i => i.MajorName == webModel.SMajor);
                }

                //班级QQ
                if (!string.IsNullOrEmpty(webModel.SQQ))
                {
                    predicate = predicate.And(i => i.QQ == webModel.SQQ);
                }

                var list = await majorClasses.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
            }
        }

        /// <summary>
        /// 更新我的班级信息
        /// </summary>
        /// <param name="webModel">我的班级编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateEntityAsync(ClassEditViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.MajorClass.FirstOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));

            if (model == null)
            {
                return;
            }

            //Update
            model.QQ = webModel.QQ;
            model.Wechat = webModel.Wechat;
        }

        #endregion

        #region Profile API

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
            model.QQ = Convert.ToInt64(webModel.QQ);
            model.Wechat = webModel.Wechat;
            model.Name = webModel.Name;

            model.ModifiedOn = DateTime.Now;
            model.ModifiedBy = CurrentUser.UserOID;
            model.ModifiedName = CurrentUser.UserName;
        }

        #endregion
    }
}
