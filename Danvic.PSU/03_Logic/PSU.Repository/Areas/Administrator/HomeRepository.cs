//-----------------------------------------------------------------------
// <copyright file= "HomeRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/27 星期二 16:28:03
// Modified by:
// Description: Administrator-Home-首页功能实现仓储
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Repository.Areas.Administrator
{
    public class HomeRepository
    {
        #region Index API
        #endregion

        #region Bulletin API

        /// <summary>
        /// 根据搜索条件获取公告列表
        /// </summary>
        /// <param name="context">数据库连接上下文</param>
        /// <param name="limit">每页显示条数</param>
        /// <param name="page">当前页</param>
        /// <param name="start">每页开始记录条数</param>
        /// <param name="title">公告标题</param>
        /// <param name="datetime">发布日期</param>
        /// <param name="type">公告类型</param>
        /// <returns></returns>
        public static async Task<List<Bulletin>> GetBulletinListAsync(int limit, int page, int start, string title, string datetime, short type, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(datetime) && type == 0)
            {
                return await context.Set<Bulletin>().Skip(start).Take(limit).ToListAsync();
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
