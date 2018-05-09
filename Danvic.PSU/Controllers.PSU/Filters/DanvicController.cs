//-----------------------------------------------------------------------
// <copyright file= "DanvicController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-09 19:11:19
// Modified by:
// Description: 控制器基类
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PSU.Utility;

namespace Controllers.PSU.Filters
{
    public class DanvicController : Controller
    {
        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CurrentUser.UserId == 0)
            {
                string path = filterContext.HttpContext.Request.Path;
                filterContext.Result = new RedirectResult($"/Secret/Login?ReturnUrl={path}");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
