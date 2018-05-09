﻿//-----------------------------------------------------------------------
// <copyright file= "SecretController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/8 星期四 14:04:22
// Modified by:
// Description: 网站首页控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.Entity.Basic;
using PSU.IService;
using PSU.Model;
using PSU.Utility.System;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Controllers.PSU
{
    [Authorize]
    public class SecretController : Controller
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ISecretService _service;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SecretController(ISecretService service, ILogger<SecretController> logger, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        #endregion

        #region View

        /// <summary>
        /// 登录页面
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            //移除当前登录人信息
            _service.RemoveCurrentUser(_httpContextAccessor);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            //登出系统
            _service.ClearSession(_httpContextAccessor);
            _logger.LogInformation("用户登出");
            return RedirectToAction(nameof(SecretController.Login), "Secret");
        }

        /// <summary>
        /// 错误页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }

        #endregion

        #region Service

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = await _service.GetUserAsync(viewModel.Account, viewModel.Password, _context);

                if (user != null)
                {
                    if (user.Password.Trim() != MD5Utility.Sign(viewModel.Password, user.Salt))
                    {
                        ModelState.AddModelError(string.Empty, "登录密码错误");
                        return View(viewModel);
                    }

                    _logger.LogInformation("用户：{0}于{1}登录系统", viewModel.Account, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

                    string role = GetRole(user);

                    //根据用户角色创建claim声明
                    List<Claim> claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, role)
                    };

                    var userIdentity = new ClaimsIdentity(role);
                    userIdentity.AddClaims(claim);

                    var userPrincipal = new ClaimsPrincipal(userIdentity);

                    await AuthenticationHttpContextExtensions.SignInAsync(HttpContext, userPrincipal, new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = false,
                        AllowRefresh = false
                    });

                    //设置当前用户信息
                    await _service.SetCurrentUser(user.IdentityUserOID, _httpContextAccessor, _context);

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToLocal(returnUrl);
                    }

                    return RedirectToRoute(new { area = user.HomePage, controller = "Home", action = "Index" });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "无效的登录尝试");
                    return View(viewModel);
                }
            }

            return View(viewModel);
        }

        #endregion

        #region Method

        /// <summary>
        /// 获取角色名称
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private static string GetRole(IdentityUser user)
        {
            string role = string.Empty;
            switch (user.AccountType)
            {
                case 0:
                    role = "Administrator";
                    break;
                case 1:
                    role = "Instructor";
                    break;
                case 2:
                    role = "Student";
                    break;
            }
            return role;
        }

        /// <summary>
        /// 重定向
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(SecretController.Login), "Sercret");
            }
        }

        #endregion
    }
}
