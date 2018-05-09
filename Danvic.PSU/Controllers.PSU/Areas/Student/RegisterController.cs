//-----------------------------------------------------------------------
// <copyright file= "RegisterController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-06 22:57:02
// Modified by:
// Description: 
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
    public class RegisterController : DanvicController
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IRegisterService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RegisterController(IRegisterService service, ILogger<RegisterController> logger, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            CurrentUser.Configure(_httpContextAccessor);
        }

        #endregion

        #region View
        #endregion
    }
}
