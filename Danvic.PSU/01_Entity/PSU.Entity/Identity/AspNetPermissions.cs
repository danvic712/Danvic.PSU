//-----------------------------------------------------------------------
// <copyright file= "AspNetPermissions.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:41:54
// Modified by:
// Description: 网站权限表
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.Identity
{
    public class AspNetPermissions
    {
        #region Constructed Function

        public AspNetPermissions()
        {
            Id = Guid.NewGuid().ToString();
            Roles = new List<AspNetRolePermissions>();
        }

        #endregion

        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 权限描述
        /// </summary>
        [MaxLength(100)]
        public string Description { get; set; }

        /// <summary>
        /// 权限包含区域
        /// </summary>
        [MaxLength(500)]
        public string Area { get; set; }

        /// <summary>
        /// 权限包含控制器
        /// </summary>
        [MaxLength(500)]
        public string Controller { get; set; }

        /// <summary>
        /// 权限包含动作
        /// </summary>
        [MaxLength(500)]
        public string Action { get; set; }

        /// <summary>
        /// Url参数
        /// </summary>
        [MaxLength(100)]
        public string Param { get; set; }

        /// <summary>
        /// Url地址
        /// /{Area}/{Controller}/{Action}
        /// </summary>
        [MaxLength(500)]
        public string Url { get; set; }

        /// <summary>
        /// 权限包含的角色列表
        /// </summary>
        public ICollection<AspNetRolePermissions> Roles { get; set; }

        #endregion
    }
}
