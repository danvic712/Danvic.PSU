//-----------------------------------------------------------------------
// <copyright file= "ISecretService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/11 星期日 13:46:31
// Modified by:
// Description: Secret控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Entity.Basic;
using System.Threading.Tasks;

namespace PSU.IService
{
    public interface ISecretService
    {
        #region Service

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="password">密码</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        Task<IdentityUser> GetUserAsync(string account, string password, ApplicationDbContext context);

        /// <summary>
        /// 设置当前登录用户
        /// </summary>
        Task SetCurrentUser();

        /// <summary>
        /// 移除当前用户
        /// </summary>
        /// <returns></returns>
        Task RemoveCurrentUser();

        #endregion
    }
}
