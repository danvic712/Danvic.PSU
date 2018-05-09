//-----------------------------------------------------------------------
// <copyright file= "RoleHandler.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-08 21:57:33
// Modified by:
// Description: 网站权限处理类
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Controllers.PSU.Filters
{
    public class RoleHandler : AuthorizationHandler<RoleRequirement>
    {
        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Issuer == "LOCAL AUTHORITY"))
            {
                return Task.CompletedTask;
            }

            var role = context.User.FindFirst(c => c.Type == ClaimTypes.Role && c.Issuer == "LOCAL AUTHORITY").Value;

            if (role.Equals(requirement.Role))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
