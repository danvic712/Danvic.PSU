//-----------------------------------------------------------------------
// <copyright file= "QuestionController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/7 星期三 13:13:34
// Modified by:
// Description: 
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.PSU.Areas.Instructor
{
    [Area("Instructor")]
    public class QuestionController : Controller
    {
        #region Initialize
        #endregion

        #region View

        public IActionResult Information()
        {
            return View();
        }

        #endregion

        #region Service
        #endregion
    }
}
