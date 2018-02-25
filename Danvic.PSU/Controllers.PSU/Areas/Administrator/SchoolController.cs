//-----------------------------------------------------------------------
// <copyright file= "SchoolController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:44:50
// Modified by:
// Description: Administrator-School控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.PSU.Areas.Administrator
{
    [Area("Administrator")]
    public class SchoolController : Controller
    {
        #region Initialize
        #endregion

        #region View

        public IActionResult Department()
        {
            return View();
        }

        public IActionResult Information()
        {
            return View();
        }

        public IActionResult Major()
        {
            return View();
        }

        #endregion

        #region Service
        #endregion
    }
}
