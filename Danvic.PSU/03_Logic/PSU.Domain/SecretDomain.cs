//-----------------------------------------------------------------------
// <copyright file= "SecretDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/11 星期日 13:48:44
// Modified by:
// Description: Secret控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Http;
using PSU.EFCore;
using PSU.Entity.Basic;
using PSU.IService;
using PSU.Repository;
using PSU.Utility;
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
        /// <param name="httpContextAccessor"></param>
        /// <returns></returns>
        public void RemoveCurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            httpContextAccessor.HttpContext.Session.SetString("CurrentUser_UserOID", "");
            httpContextAccessor.HttpContext.Session.SetString("CurrentUser_UserId", "0");
            httpContextAccessor.HttpContext.Session.SetString("CurrentUser_UserName", "");
            httpContextAccessor.HttpContext.Session.SetString("CurrentUser_UserAccount", "");
            httpContextAccessor.HttpContext.Session.SetString("CurrentUser_UserImage", "");
            httpContextAccessor.HttpContext.Session.SetString("CurrentUser_UserRole", "");
            httpContextAccessor.HttpContext.Session.SetString("CurrentUser_UserPage", "");
        }

        /// <summary>
        /// 清除Session数据
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <returns></returns>
        public void ClearSession(IHttpContextAccessor httpContextAccessor)
        {
            httpContextAccessor.HttpContext.Session.Clear();
        }

        /// <summary>
        /// 设置当前登录用户
        /// </summary>
        public async Task SetCurrentUser(string oid, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            CurrentUser.Configure(httpContextAccessor);

            var user = await PSURepository.GetUserByOIDAsync(oid, context);

            if (user != null)
            {
                string role = string.Empty;
                switch (user.AccountType)
                {
                    case 0:
                        role = "Administrator";
                        break;
                    case 1:
                        role = "Instructor";
                        break;
                    case 2:
                        role = "Student";
                        break;
                }

                CurrentUser.UserAccount = user.Account;
                CurrentUser.UserId = user.Id;
                CurrentUser.UserImage = user.ImageSrc;
                CurrentUser.UserName = user.Name;
                CurrentUser.UserOID = user.IdentityUserOID;
                CurrentUser.UserRole = role;
                CurrentUser.UserPage = user.HomePage;
            }
        }

        #endregion
    }
}
