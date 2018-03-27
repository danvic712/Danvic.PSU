//-----------------------------------------------------------------------
// <copyright file= "DormitoryRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/23 星期五 16:58:27
// Modified by:
// Description: Administrator-Dormitory-首页功能实现仓储
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.Basic;
using PSU.Entity.Dormitory;
using PSU.Entity.School;
using PSU.Model.Areas.Administrator.Dormitory;

namespace PSU.Repository.Areas.Administrator
{
    public class DormitoryRepository
    {
        #region Building API

        /// <summary>
        /// 删除宿舍楼数据
        /// </summary>
        /// <param name="id">宿舍楼编号</param>
        /// <param name="context">数据库上下文对象</param>
        public static async Task DeleteAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Building.SingleOrDefaultAsync(i => i.Id == id);

            context.Remove(model);
        }

        /// <summary>
        /// 获取宿舍楼信息
        /// </summary>
        /// <param name="id">宿舍楼编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Building> GetEntityAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Building.Where(i => i.Id == id).SingleOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 根据搜索条件获取公告列表
        /// </summary>
        /// <param name="webModel">宿舍楼列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Building>> GetListAsync(BuildingViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SId) && webModel.SType == 0 && webModel.SEnable == 9)
            {
                return await context.Set<Building>().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                IQueryable<Building> buildings = context.Building.AsQueryable();

                var predicate = PredicateBuilder.New<Building>();

                //宿舍楼编号
                if (!string.IsNullOrEmpty(webModel.SId))
                {
                    predicate = predicate.And(i => i.Id == Convert.ToInt64(webModel.SId));
                }

                //宿舍楼类型
                if (webModel.SType != 0)
                {
                    predicate = predicate.And(i => i.Type == webModel.SType);
                }

                //宿舍楼是否启用
                if (webModel.SEnable != 9)
                {
                    bool flag = webModel.SEnable == 1;
                    predicate = predicate.And(i => i.IsEnabled == flag);
                }

                return await buildings.AsExpandable().Where(predicate).ToListAsync();
            }
        }



        #endregion

        #region Convert
        #endregion
    }
}
