//-----------------------------------------------------------------------
// <copyright file= "BasicController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:41:59
// Modified by:
// Description: Administrator-Basic控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.PSU.Areas.Administrator
{
    [Area("Administrator")]
    public class BasicController:Controller
    {
        #region Initialize
        #endregion

        #region View

        public IActionResult Staff()
        {
            return View();
        }

        public IActionResult Region()
        {
            return View();
        }

        public IActionResult Student()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        #endregion

        #region Service
        #endregion
    }
}
