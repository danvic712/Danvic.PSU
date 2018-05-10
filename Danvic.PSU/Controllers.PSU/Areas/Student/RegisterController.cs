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
using PSU.Model.Areas.Student;
using PSU.Utility;
using System.Linq;
using System.Threading.Tasks;

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

        /// <summary>
        /// 报名信息页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Information()
        {
            var webModel = await _service.GetInformationAsync(CurrentUser.UserId, _context);
            return View(webModel);
        }

        /// <summary>
        /// 服务预定页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Booking()
        {
            return View();
        }

        /// <summary>
        /// 物品页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Goods()
        {
            return View();
        }

        /// <summary>
        /// 寝室选择页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Dormitory()
        {
            return View();
        }

        #endregion

        #region Service-Information

        /// <summary>
        /// 学生编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SignUp(InformationViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    //Add Register
                    flag = await _service.InsertInformationAsync(webModel, _context);
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        msg = "预报名信息禁止修改"
                    });
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "预报名成功" : "预报名失败"
                });
            }

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
            });
        }

        #endregion

        #region Service-Booking
        #endregion

        #region Service-Goods
        #endregion

        #region Service-Dormitory
        #endregion
    }
}
