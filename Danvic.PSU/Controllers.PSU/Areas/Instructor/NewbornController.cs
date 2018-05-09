//-----------------------------------------------------------------------
// <copyright file= "NewbornController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-07 20:34:09
// Modified by:
// Description: Instructor-Newborn-控制器
//-----------------------------------------------------------------------
using Controllers.PSU.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Instructor;
using PSU.Model.Areas.Instructor.Newborn;
using PSU.Utility;
using PSU.Utility.Web;
using System;
using System.Threading.Tasks;

namespace Controllers.PSU.Areas.Instructor
{
    [Area("Instructor")]
    [Authorize(Policy = "Instructor")]
    public class NewbornController : DanvicController
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly INewbornService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public NewbornController(INewbornService service, ILogger<NewbornController> logger, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
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
        /// 新生报名情况页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 新生宿舍选择页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Dormitory()
        {
            return View();
        }

        /// <summary>
        /// 新生信息页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Information()
        {
            return View();
        }

        /// <summary>
        /// 新生详细信息页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var webModel = await _service.GetStudentAsync(Convert.ToInt64(id), _context);
                return View(webModel);
            }
            return Redirect("Information");
        }

        #endregion

        #region Service

        /// <summary>
        /// 新生报名信息页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchRegister(string search)
        {
            RegisterViewModel webModel = JsonUtility.ToObject<RegisterViewModel>(search);

            webModel = await _service.SearchRegisterAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SMajorClass) && string.IsNullOrEmpty(webModel.SDate);

            var returnData = new
            {
                data = webModel.RegisterList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.Total
            };

            return Json(returnData);
        }

        /// <summary>
        /// 新生预定寝室信息页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchDormitory(string search)
        {
            DormitoryViewModel webModel = JsonUtility.ToObject<DormitoryViewModel>(search);

            webModel = await _service.SearchDormitoryAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SStudent) && string.IsNullOrEmpty(webModel.SBuilding);

            var returnData = new
            {
                data = webModel.DormitoryList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.Total
            };

            return Json(returnData);
        }

        /// <summary>
        /// 新生信息页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchInformation(string search)
        {
            InformationViewModel webModel = JsonUtility.ToObject<InformationViewModel>(search);

            webModel = await _service.SearchStudentAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SId) && string.IsNullOrEmpty(webModel.SMajorClass);

            var returnData = new
            {
                data = webModel.StudentList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.Total
            };

            return Json(returnData);
        }

        #endregion
    }
}
