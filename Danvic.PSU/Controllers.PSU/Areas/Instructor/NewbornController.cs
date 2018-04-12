//-----------------------------------------------------------------------
// <copyright file= "NewbornController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-07 20:34:09
// Modified by:
// Description: Instructor-Newborn-控制器
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
    public class NewbornController : Controller
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly INewbornService _service;
        public NewbornController(INewbornService service, ILogger<NewbornController> logger, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _context = context;
        }

        #endregion

        #region View

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Dormitory()
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
