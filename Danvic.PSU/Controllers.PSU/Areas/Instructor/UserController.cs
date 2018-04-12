//-----------------------------------------------------------------------
// <copyright file= "UserController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-07 21:24:10
// Modified by:
// Description: Instructor-User-控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Instructor;

namespace Controllers.PSU.Areas.Instructor
{
    [Area("Instructor")]
    public class UserController : Controller
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IUserService _service;
        public UserController(IUserService service, ILogger<UserController> logger, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _context = context;
        }

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
