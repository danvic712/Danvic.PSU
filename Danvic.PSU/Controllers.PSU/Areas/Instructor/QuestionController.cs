//-----------------------------------------------------------------------
// <copyright file= "QuestionController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/7 星期三 13:13:34
// Modified by:
// Description: Instructor-Question-控制器
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
    public class QuestionController : Controller
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IQuestionService _service;
        public QuestionController(IQuestionService service, ILogger<QuestionController> logger, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _context = context;
        }

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
