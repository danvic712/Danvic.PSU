//-----------------------------------------------------------------------
// <copyright file= "NewbornRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:32:49
// Modified by:
// Description: Instructor-Newborn-功能实现仓储
//-----------------------------------------------------------------------
using PSU.Entity.SignUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Model.Areas.Instructor.Newborn;
using PSU.Utility;

namespace PSU.Repository.Areas.Instructor
{
    public class NewbornRepository
    {
        #region Register API

        /// <summary>
        /// 根据搜索条件获取新生报名信息
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Register>> GetListAsync(RegisterViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SMajorClass) && string.IsNullOrEmpty(webModel.SDate))
            {
                return await context.Set<Register>().Where(i => i.InstructorId == CurrentUser.UserId).Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.DateTime).ToListAsync();
            }
            else
            {
                IQueryable<Register> registers = context.Register.AsQueryable();

                var predicate = PredicateBuilder.New<Register>();

                //当前登录人数据
                predicate = predicate.And(i => i.InstructorId == CurrentUser.UserId);

                //学生姓名
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //专业班级名称
                if (!string.IsNullOrEmpty(webModel.SMajorClass))
                {
                    predicate = predicate.And(i => i.MajorClass.Contains(webModel.SMajorClass));
                }

                //预计到校时间
                if (!string.IsNullOrEmpty(webModel.SDate))
                {
                    predicate = predicate.And(i => i.ArriveTime.ToString("yyyy-MM-dd") == webModel.SDate);
                }

                return await registers.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        #endregion
    }
}
