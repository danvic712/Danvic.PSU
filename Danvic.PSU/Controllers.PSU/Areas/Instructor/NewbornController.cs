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
using System.Threading.Tasks;
using PSU.Utility.Web;
using PSU.Model.Areas.Instructor.Newborn;

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
                total = webModel.RegisterList.Count
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
                total = webModel.DormitoryList.Count
            };

            return Json(returnData);
        }

        #endregion
    }
}
