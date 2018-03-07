//-----------------------------------------------------------------------
// <copyright file= "HomeController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:47:25
// Modified by:
// Description: Instructor-Home控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.PSU.Areas.Instructor
{
    [Area("Instructor")]
    public class HomeController : Controller
    {
        #region Initialize
        #endregion

        #region View

        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Service
        #endregion
    }
}
