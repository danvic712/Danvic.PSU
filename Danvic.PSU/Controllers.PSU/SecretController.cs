//-----------------------------------------------------------------------
// <copyright file= "SecretController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/8 星期四 14:04:22
// Modified by:
// Description: 网站首页控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSU.IService;
using PSU.Model;

using System.Threading.Tasks;

namespace Controllers.PSU
{
    public class SecretController : Controller
    {
        #region Initialize

        private readonly ISecretService _service;

        private readonly ILogger _logger;

        public SecretController(ISecretService secret, ILogger<SecretController> logger)
        {
            _service = secret;
            _logger = logger;
        }

        #endregion

        #region View

        public IActionResult Login()
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
        public async Task<IActionResult> Login(LoginViewModel viewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            //var result = await
            return View(viewModel);
        }

        #endregion
    }
}
