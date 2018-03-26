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
    public class CurrentUser
    {
        #region Initialize

        private readonly IHttpContextAccessor _httpContextAccessor;

        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        //Todo:Let Attribute Stored in Session
        #region Attribute

        //Set Session _session.SetString("code","123456");
        //Get Session _session.GetString("code");

        //Stored Info in ASP.NET MVC
        //public static string UserCode
        //{
        //    get
        //    {
        //        if (HttpContext.Current == null)
        //        {
        //            return "";
        //        }
        //        if (HttpContext.Current.Session == null)
        //        {
        //            return "";
        //        }
        //        return Utils.ToString(HttpContext.Current.Session["FlyerUser_UserCode"]);
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["FlyerUser_UserCode"] = value;
        //    }
        //}

        /// <summary>
        ///用户编号 
        /// </summary>
        public long UserId
        {
            get
            {
                if (_session == null)
                {
                    return 0;
                }
                
                //return Convert.ToInt64(_session.GetString(""));
                return 0;
            }
        }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public static string UserName { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public static string UserImage { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public static string UserRole { get; set; }

        #endregion
    }
}
