//-----------------------------------------------------------------------
// <copyright file= "AspNetRolePermissions.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:42:10
// Modified by:
// Description: 网站角色权限表
//-----------------------------------------------------------------------

namespace PSU.Entity.Identity
{
    public class AspNetRolePermissions
    {
        #region Attribute

        /// <summary>
        /// 角色Id
        /// </summary>
        public virtual string RoleId { get; set; }

        /// <summary>
        /// 权限Id
        /// </summary>
        public virtual string PermissionId { get; set; }

        #endregion
    }
}
