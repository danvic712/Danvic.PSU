//-----------------------------------------------------------------------
// <copyright file= "UserController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-08 20:56:47
// Modified by:
// Description: Student-User控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Student;
using PSU.Model.Areas.Student;
using PSU.Utility;

namespace Controllers.PSU.Areas.Student
{
    [Area("Student")]
    [Authorize(Policy = "Student")]
    public class UserController : Controller
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IUserService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IUserService service, ILogger<UserController> logger, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
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
        /// 个人中心
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Profile()
        {
            return View(new ProfileViewModel());
        }

        #endregion

        #region Service
        #endregion
    }
}
