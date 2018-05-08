//-----------------------------------------------------------------------
// <copyright file= "RoleRequirement.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-08 21:51:14
// Modified by:
// Description: 网站权限要求类
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Authorization;

namespace Controllers.PSU.Filters
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Role { get; private set; }

        public RoleRequirement(string role)
        {
            this.Role = role;
        }
    }
}
