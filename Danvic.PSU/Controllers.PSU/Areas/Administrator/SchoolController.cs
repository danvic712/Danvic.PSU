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
        /// 院系列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Department()
        {
            return View();
        }

        public IActionResult DepartmentDetail()
        {
            return View();
        }

        public IActionResult EditDepartment()
        {
            return View();
        }

        public IActionResult EditMajor()
        {
            return View();
        }

        public IActionResult EditMajorClass()
        {
            return View();
        }

        /// <summary>
        /// 学校信息页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Information(string id)
        {
            InformationViewModel webModel = new InformationViewModel();
            if (!string.IsNullOrEmpty(id))
            {
                webModel = await _service.GetInformationAsync(Convert.ToInt64(id), _context);
            }
            return View(webModel);
        }

        public IActionResult Major()
        {
            return View();
        }

        public IActionResult MajorClass()
        {
            return View();
        }
        public IActionResult MajorDetail()
        {
            return View();
        }

        #endregion

        #region Service

        /// <summary>
        /// 编辑学校信息
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Information(InformationViewModel webModel)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    //新增学校信息
                    flag = await _service.InsertInformationAsync(webModel, _context);
                }
                else
                {
                    //修改学校信息
                    flag = await _service.UpdateInformationAsync(webModel, _context);
                }

                return Json(new
                {
                    success = flag,
                    msg = flag == true ? "学校信息编辑成功" : "学校信息编辑失败"
                });
            }
            return Json(new
            {
                success = false
            });
        }

        /// <summary>
        /// 上传学校图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UploadImg()
        {
            return null;
        }

        /// <summary>
        /// 院系页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchDepartment(string search)
        {
            DepartmentViewModel webModel = JsonUtility.ToObject<DepartmentViewModel>(search);

            webModel = await _service.SearchDepartmentAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SId) && string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.Tel);

            var returnData = new
            {
                data = webModel.DepartmentList,
                limit = webModel.Limit,
                page = flag == true ? webModel.Page : 1,
                total = webModel.DepartmentList.Count
            };

            return Json(returnData);
        }

        #endregion
    }
}
