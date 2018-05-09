//-----------------------------------------------------------------------
// <copyright file= "HomeController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:48:18
// Modified by:
// Description: Student-Home控制器
//-----------------------------------------------------------------------
using Controllers.PSU.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Student;
using PSU.Utility;

namespace Controllers.PSU.Areas.Student
{
    [Area("Student")]
    [Authorize(Policy = "Student")]
    public class HomeController : DanvicController
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IHomeService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IHomeService service, ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            CurrentUser.Configure(_httpContextAccessor);
        }

        #endregion

        #region View

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Service
        #endregion
    }
}
