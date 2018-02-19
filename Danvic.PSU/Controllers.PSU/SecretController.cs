//-----------------------------------------------------------------------
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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSU.Entity.Identity;
using PSU.Model;
using System;
using System.Threading.Tasks;

namespace Controllers.PSU
{
    [Authorize]
    public class SecretController : Controller
    {
        #region Initialize

        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        private readonly ILogger _logger;

        public SecretController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<SecretController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        #endregion

        #region View

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("用户登出");
            return RedirectToAction(nameof(SecretController.Login), "Secret");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

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
                var result = await _signInManager.PasswordSignInAsync(viewModel.Account, viewModel.Password, viewModel.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("用户：{0}于{1}登录系统", viewModel.Account, DateTime.Now.ToString("yyyy-MM-dd"));
                    return RedirectToLocal(returnUrl);
                }
                else if (result.IsLockedOut)
                {
                    _logger.LogWarning("用户：{0}于{1}账户被锁定", viewModel.Account, DateTime.Now.ToString("yyyy-MM-dd"));
                    return RedirectToAction(nameof(Lockout));
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
