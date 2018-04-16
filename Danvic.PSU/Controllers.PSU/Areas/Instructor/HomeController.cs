//-----------------------------------------------------------------------
// <copyright file= "HomeController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:47:25
// Modified by:
// Description: Instructor-Home-控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Instructor;
using System.Threading.Tasks;

namespace Controllers.PSU.Areas.Instructor
{
    [Area("Instructor")]
    public class HomeController : Controller
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IHomeService _service;
        public HomeController(IHomeService service, ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _context = context;
        }

        #endregion

        #region View

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var webModel = await _service.InitIndexPageAsync(_context);
            return View(webModel);
        }

        #endregion

        #region Service

        /// <summary>
        /// 获取折线图数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetLineChart()
        {
            var chart = await _service.InitLineChartAsync(_context);
            return Json(chart);
        }

        /// <summary>
        /// 获取饼图数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetPieChart()
        {
            var chart = await _service.InitPieChartAsync(_context);
            return Json(chart);
        }

        #endregion
    }
}
