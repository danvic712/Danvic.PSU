//-----------------------------------------------------------------------
// <copyright file= "DormitoryController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:43:36
// Modified by:
// Description: Administrator-Dormitory控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.PSU.Areas.Administrator
{
    [Area("Administrator")]
    public class DormitoryController : Controller
    {
        #region Initialize
        #endregion

        #region View

        public IActionResult Building()
        {
            return View();
        }

        public IActionResult Bunk()
        {
            return View();
        }

        public IActionResult Information()
        {
            return View();
        }

        #endregion

        #region Service
        #endregion
    }
}
