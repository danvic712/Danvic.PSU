//-----------------------------------------------------------------------
// <copyright file= "CurrentUser.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/12 星期一 9:39:49
// Modified by:
// Description: 当前登录用户信息类
//-----------------------------------------------------------------------

using Microsoft.AspNetCore.Http;
using System;

namespace PSU.Utility
{
    public static class CurrentUser
    {
        #region Initialize

        private static IHttpContextAccessor _httpContextAccessor;

        private static ISession _session => _httpContextAccessor.HttpContext.Session;

        static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Attribute

        /// <summary>
        ///用户编号 
        /// </summary>
        public static string UserId
        {
            get => _session == null ? "" : _session.GetString("CurrentUser_UserId");
            set => _session.SetString("CurrentUser_UserId", value);
        }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public static string UserName
        {
            get => _session == null ? "" : _session.GetString("CurrentUser_UserName");
            set => _session.SetString("CurrentUser_UserName", value);
        }

        /// <summary>
        /// 用户头像地址
        /// </summary>
        public static string UserImage
        {
            get => _session == null ? "" : _session.GetString("CurrentUser_UserImage");
            set => _session.SetString("CurrentUser_UserImage", value);
        }

        /// <summary>
        /// 用户角色
        /// </summary>
        public static string UserRole
        {
            get => _session == null ? "" : _session.GetString("CurrentUser_UserRole");
            set => _session.SetString("CurrentUser_UserRole", value);
        }

        #endregion
    }
}
