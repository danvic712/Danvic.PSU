//-----------------------------------------------------------------------
// <copyright file= "StatisticsController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:45:35
// Modified by:
// Description: Administrator-Statistics控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.PSU.Areas.Administrator
{
    [Area("Administrator")]
    //[Authorize(Roles = "Administrator")]
    public class StatisticsController : Controller
    {
        #region Initialize
        #endregion

        #region View

        public IActionResult Behavior()
        {
            return View();
        }

        public IActionResult BehaviorByChart()
        {
            return View();
        }

        public IActionResult Dormitory()
        {
            return View();
        }

        public IActionResult DormitoryByChart()
        {
            return View();
        }

        public IActionResult Student()
        {
            return View();
        }

        public IActionResult StudentByChart()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        #endregion

        #region Service
        #endregion
    }
}
