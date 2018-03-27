//-----------------------------------------------------------------------
// <copyright file= "PSURepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/10 星期六 9:18:49
// Modified by:
// Description: 通用功能仓储实现
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.Basic;
using PSU.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Repository
{
    public class PSURepository
    {
        #region Initialize

        public enum OperateCode
        {
            Insert = 0,
            Update = 1,
            Delete = 2
        }

        #endregion

        #region Service

        /// <summary>
        /// 插入操作信息
        /// </summary>
        /// <param name="operate">操作内容</param>
        /// <param name="type">操作类型</param>
        /// <param name="tableId">操作表Id</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void InsertRecordAsync(string operate, short type, long tableId, ApplicationDbContext context)
        {
            var model = new Record
            {
                Operate = operate,
                Type = type,
                TableId = tableId,
                UserId = CurrentUser.UserId,
                UserName = CurrentUser.UserName
            };

            await context.Record.AddAsync(model);
        }

        /// <summary>
        /// 获取对同一对象操作信息
        /// </summary>
        /// <param name="objId">对象编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Record>> GetRecordListAsync(long objId, ApplicationDbContext context)
        {
            return await context.Record.Where(i => i.TableId == objId).ToListAsync();
        }

        /// <summary>
        /// 获取地区相关信息
        /// </summary>
        /// <param name="id">地区信息编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Region> GetRegionAsync(long id, ApplicationDbContext context)
        {
            return await context.Region.SingleOrDefaultAsync(i => i.Id == id);
        }

        #endregion
    }
}
