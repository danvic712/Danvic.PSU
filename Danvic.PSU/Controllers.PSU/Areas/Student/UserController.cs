//-----------------------------------------------------------------------
// <copyright file= "UserController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-08 20:56:47
// Modified by:
// Description: Student-User控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.PSU.Areas.Student
{
    [Area("Student")]
    public class UserController:Controller
    {
        #region Initialize
        #endregion

        #region View

        public IActionResult Profile()
        {
            return View();
        }

        #endregion

        #region Service
        #endregion
    }
}
