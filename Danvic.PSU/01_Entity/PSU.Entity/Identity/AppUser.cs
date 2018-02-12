//-----------------------------------------------------------------------
// <copyright file= "AppUser.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/12 星期一 11:06:51
// Modified by:
// Description: 网站用户类
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSU.Entity.Identity
{
    public class AppUser : SysField
    {
        #region Constructed Function

        public AppUser()
        {
            AppUserOID = Guid.NewGuid();
        }

        #endregion

        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid AppUserOID { get; set; }

        #endregion
    }
}
