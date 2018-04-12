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
using PSU.Model.Areas.Administrator.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Repository.Areas.Administrator
{
    public class BasicRepository
    {
        #region Profile API
        #endregion

        #region Staff API

        /// <summary>
        /// 根据搜索条件获取教职工列表
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Staff>> GetListAsync(StaffViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SId) && string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SDepartment))
            {
                return await context.Set<Staff>().AsNoTracking().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                IQueryable<Staff> staves = context.Staff.AsQueryable();

                var predicate = PredicateBuilder.New<Staff>();

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
                    predicate = predicate.And(i => i.DepartmentId == Convert.ToInt64(webModel.SDepartment));
                }

                return await staves.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        #endregion

        #region Student API

        /// <summary>
        /// 根据搜索条件获取学生列表
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Entity.Basic.Student>> GetListAsync(StudentViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SId) && string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SMajorClass))
            {
                return await context.Set<Entity.Basic.Student>().AsNoTracking().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                IQueryable<Entity.Basic.Student> students = context.Student.AsQueryable();

                var predicate = PredicateBuilder.New<Entity.Basic.Student>();

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
                    predicate = predicate.And(i => i.MajorClassId == Convert.ToInt64(webModel.SMajorClass));
                }

                return await students.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        #endregion
    }
}
