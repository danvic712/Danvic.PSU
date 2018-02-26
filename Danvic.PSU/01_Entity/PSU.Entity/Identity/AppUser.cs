//-----------------------------------------------------------------------
// <copyright file= "AppUser.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/12 星期一 11:06:51
// Modified by:
// Description: 网站用户类
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Identity;

namespace PSU.Entity.Identity
{
    public class AppUser : IdentityUser
    {
        #region Attribute

        ///// <summary>
        ///// 账号对应的教职工信息
        ///// </summary>
        //public Staff Staff { get; set; }

        ///// <summary>
        ///// 账号对应的学生账户
        ///// </summary>
        //public Student Student { get; set; }

        #endregion
    }
}
