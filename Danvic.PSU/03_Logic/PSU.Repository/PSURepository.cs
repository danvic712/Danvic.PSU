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

        #region Service-Record

        /// <summary>
        /// 插入操作信息
        /// </summary>
        /// <param name="tableName">操作修改的表</param>
        /// <param name="className">操作所在类</param>
        /// <param name="methodName">操作方法</param>
        /// <param name="operate">操作内容</param>
        /// <param name="type">操作类型</param>
        /// <param name="dataId">操作表Id</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void InsertRecordAsync(string tableName, string className, string methodName, string operate, short type, long dataId, ApplicationDbContext context)
        {
            var model = new Record
            {
                TableName = tableName,
                ClassName = className,
                MethodName = methodName,
                Operate = operate,
                Type = type,
                DataId = dataId,
                UserOID = CurrentUser.UserOID,
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
            return await context.Record.AsNoTracking().Where(i => i.DataId == objId).ToListAsync();
        }

        #endregion

        #region Service-Account

        /// <summary>
        /// 获取登录账户信息
        /// </summary>
        /// <param name="account">帐户名</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<IdentityUser> GetUserAsync(string account, ApplicationDbContext context)
        {
            return await context.IdentityUser.AsNoTracking().Where(i => i.Account == account && i.IsEnabled == true).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// <param name="oid">主键</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<IdentityUser> GetUserByOIDAsync(string oid, ApplicationDbContext context)
        {
            return await context.IdentityUser.AsNoTracking().Where(i => i.IdentityUserOID == oid).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// <param name="account">帐户名</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<IdentityUser> GetUserByAccountAsync(string account, ApplicationDbContext context)
        {
            return await context.IdentityUser.AsNoTracking().Where(i => i.Account == account).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// <param name="account">编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<IdentityUser> GetUserByIdAsync(long id, ApplicationDbContext context)
        {
            return await context.IdentityUser.AsNoTracking().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        #endregion
    }
}
