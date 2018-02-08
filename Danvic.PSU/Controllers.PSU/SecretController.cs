//-----------------------------------------------------------------------
// <copyright file= "SecretController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/8 星期四 14:04:22
// Modified by:
// Description: 
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using PSU.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.PSU
{
    public class SecretController : Controller
    {
        #region Initialize
        #endregion

        #region Views

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        #endregion

        #region Services

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
