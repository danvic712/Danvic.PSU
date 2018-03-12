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
using System.Collections.Generic;
using System.Text;

namespace PSU.Utility
{
    public class CurrentUser
    {
        #region Attribute

        public static long UserId{ get; set; }

        #endregion
    }
}
