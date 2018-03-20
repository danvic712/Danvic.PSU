//-----------------------------------------------------------------------
// <copyright file= "SchoolController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:44:50
// Modified by:
// Description: Administrator-School控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.School;
using PSU.Utility.Web;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.PSU.Areas.Administrator
{
    [Area("Administrator")]
    //[Authorize(Roles = "Administrator")]
    public class SchoolController : Controller
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly ISchoolService _service;
        public SchoolController(ISchoolService service, ILogger<SchoolController> logger, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _context = context;
        }

        #endregion

        #region View

        /// <summary>
        /// 部门/院系列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Department()
        {
            return View();
        }

        /// <summary>
        /// 部门/院系编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditDepartment(string id)
        {
            DepartmentEditViewModel webModel = new DepartmentEditViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                //编辑信息，加载部门/院系相关信息
                webModel = await _service.GetDepartmentAsync(Convert.ToInt64(id), _context);
            }

            return View(webModel);
        }

        /// <summary>
        /// 专业班级编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditMajorClass(string id)
        {
            MajorClassEditViewModel webModel = new MajorClassEditViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                //编辑信息，加载部门/院系相关信息
                webModel = await _service.GetMajorClassAsync(Convert.ToInt64(id), _context);
            }

            return View(webModel);
        }

        /// <summary>
        /// 专业班级列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult MajorClass()
        {
            return View();
        }

        #endregion

        #region Service

        /// <summary>
        /// 部门/院系页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchDepartment(string search)
        {
            DepartmentViewModel webModel = JsonUtility.ToObject<DepartmentViewModel>(search);

            webModel = await _service.SearchDepartmentAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SId) && string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.STel);

            var returnData = new
            {
                data = webModel.DepartmentList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.DepartmentList.Count
            };

            return Json(returnData);
        }

        /// <summary>
        /// 专业班级页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchMajorClass(string search)
        {
            MajorClassViewModel webModel = JsonUtility.ToObject<MajorClassViewModel>(search);

            webModel = await _service.SearchMajorClassAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SClassName) && string.IsNullOrEmpty(webModel.SMajorName) && string.IsNullOrEmpty(webModel.SInstructorName);

            var returnData = new
            {
                data = webModel.MajorClassList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.MajorClassList.Count
            };

            return Json(returnData);
        }

        #endregion
    }
}
