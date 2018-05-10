//-----------------------------------------------------------------------
// <copyright file= "UserController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-08 20:56:47
// Modified by:
// Description: Student-User控制器
//-----------------------------------------------------------------------
using Controllers.PSU.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Student;
using PSU.Model.Areas.Student;
using PSU.Utility;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers.PSU.Areas.Student
{
    [Area("Student")]
    [Authorize(Policy = "Student")]
    public class UserController : DanvicController
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
        public async Task<IActionResult> Profile()
        {
            var webModel = await _service.GetStudentAsync(CurrentUser.UserId, _context);
            return View(webModel);
        }

        #endregion

        #region Service

        /// <summary>
        /// 学生编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditProfile(ProfileViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;

                //Update Student
                flag = await _service.UpdateStudentAsync(webModel, _context);

                return Json(new
                {
                    success = flag,
                    msg = flag ? "个人信息编辑成功" : "个人信息编辑失败"
                });
            }

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
            });
        }

        #endregion
    }
}
