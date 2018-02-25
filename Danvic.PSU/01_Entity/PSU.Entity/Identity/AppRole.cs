//-----------------------------------------------------------------------
// <copyright file= "AppRole.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:41:41
// Modified by:
// Description: 网站角色表
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.Identity
{
    public class AppRole : IdentityRole
    {
        #region Constructed Function

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public AppRole() : base()
        {
            Permissions = new List<AspNetRolePermissions>();
        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="name">角色名</param>
        public AppRole(string name) : base(name)
        {
            base.Name = name;
        }

        #endregion

        #region Attribute

        /// <summary>
        /// 角色描述
        /// </summary>
        [MaxLength(100)]
        public string Description { get; set; }

        /// <summary>
        /// 角色对应的权限列表
        /// </summary>
        public ICollection<AspNetRolePermissions> Permissions { get; set; }

        #endregion
    }
}
