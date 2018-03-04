//-----------------------------------------------------------------------
// <copyright file= "AdmissionController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:44:13
// Modified by:
// Description: Administrator-Admission控制器
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
    public class AdmissionController:Controller
    {
        #region Initialize
        #endregion

        #region View

        public IActionResult Goods( )
        {
            return View();
        }

        public IActionResult Question()
        {
            return View();
        }

        public IActionResult Service()
        {
            return View();
        }

        public IActionResult Tuition()
        {
            return View();
        }

        #endregion

        #region Service
        #endregion
    }
}
