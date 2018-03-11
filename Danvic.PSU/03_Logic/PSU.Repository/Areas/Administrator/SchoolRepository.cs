//-----------------------------------------------------------------------
// <copyright file= "SchoolRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-11 20:59:20
// Modified by:
// Description: Administrator-School-首页功能实现仓储
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.School;
using PSU.Model.Areas.Administrator.School;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Repository.Areas.Administrator
{
    public class SchoolRepository
    {
        #region Information API

        /// <summary>
        /// 获取学校信息
        /// </summary>
        /// <param name="id">学校编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<College> GetEntityAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Collage.Where(i => i.Id == id).SingleOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 新增学校信息
        /// </summary>
        /// <param name="webModel">学校信息页面视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<College> InsertAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            var model = new College { };

            await context.Collage.AddAsync(model);

            return model;
        }

        /// <summary>
        /// 更新学校信息
        /// </summary>
        /// <param name="webModel">学校信息页面视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.Collage.SingleOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));
        }

        #endregion
    }
}
