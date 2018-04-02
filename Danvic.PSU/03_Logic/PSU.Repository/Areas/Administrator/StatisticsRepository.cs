//-----------------------------------------------------------------------
// <copyright file= "StatisticsRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-04-02 21:24:00
// Modified by:
// Description: Administrator-Statistics-功能实现仓储
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace PSU.Repository.Areas.Administrator
{
    public class StatisticsRepository
    {
        #region Register API

        ///// <summary>
        ///// 根据搜索条件获取迎新服务信息
        ///// </summary>
        ///// <param name="webModel">列表页视图模型</param>
        ///// <param name="context">数据库上下文对象</param>
        ///// <returns></returns>
        //public static async Task<List<student>> GetListAsync(ServiceViewModel webModel, ApplicationDbContext context)
        //{
        //    if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SAddress) && string.IsNullOrEmpty(webModel.SDate))
        //    {
        //        return await context.Set<Service>().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
        //    }
        //    else
        //    {
        //        IQueryable<Service> services = context.Service.AsQueryable();

        //        var predicate = PredicateBuilder.New<Service>();

        //        //迎新服务名称
        //        if (!string.IsNullOrEmpty(webModel.SName))
        //        {
        //            predicate = predicate.And(i => i.Name == webModel.SName);
        //        }

        //        //迎新服务地点
        //        if (!string.IsNullOrEmpty(webModel.SAddress))
        //        {
        //            predicate = predicate.And(i => i.Place == webModel.SAddress);
        //        }

        //        //迎新服务时间
        //        if (!string.IsNullOrEmpty(webModel.SDate))
        //        {
        //            predicate = predicate.And(i => i.StartTime <= Convert.ToDateTime(webModel.SDate) && i.EndTime >= Convert.ToDateTime(webModel.SDate));
        //        }

        //        return await services.AsExpandable().Where(predicate).ToListAsync();
        //    }
        //}

        #endregion

        #region Goods API
        #endregion

        #region Dormitory API
        #endregion

        #region Book API
        #endregion
    }
}
