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
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.Identity
{
    public class AppUser : IdentityUser
    {
        #region Attribute

        /// <summary>
        /// 图片地址
        /// </summary>
        [MaxLength(500)]
        public string ImageSrc { get; set; }

        /// <summary>
        /// 图片二进制流
        /// </summary>
        public byte Image { get; set; }

        #endregion
    }
}
