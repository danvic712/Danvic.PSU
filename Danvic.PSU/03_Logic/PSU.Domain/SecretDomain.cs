//-----------------------------------------------------------------------
// <copyright file= "SecretDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/11 星期日 13:48:44
// Modified by:
// Description: Secret控制器邻域功能接口实现
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Entity.Basic;
using PSU.IService;
using PSU.Repository;
using System;
using System.Threading.Tasks;

namespace PSU.Domain
{
    public class SecretDomain : ISecretService
    {
        #region Interface Service Implement

        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<IdentityUser> GetUserAsync(string account, string password, ApplicationDbContext context)
        {
            return await PSURepository.GetUserAsync(account, context);
        }

        /// <summary>
        /// 移除登录用户信息
        /// </summary>
        /// <returns></returns>
        public Task RemoveCurrentUser()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 设置当前登录用户
        /// </summary>
        public void SetCurrentUser()
        {
            throw new NotImplementedException();
        }

        Task ISecretService.SetCurrentUser()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
