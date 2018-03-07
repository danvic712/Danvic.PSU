//-----------------------------------------------------------------------
// <copyright file= "UserController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-07 21:24:10
// Modified by:
// Description: Instructor-User控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.PSU.Areas.Instructor
{
    [Area("Instructor")]
    public class UserController:Controller
    {
        #region Initialize
        #endregion

        #region View

        public IActionResult Classes()
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
