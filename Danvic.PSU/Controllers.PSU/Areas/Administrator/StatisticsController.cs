//-----------------------------------------------------------------------
// <copyright file= "StatisticsController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:45:35
// Modified by:
// Description: Administrator-Statistics控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Administrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.PSU.Areas.Administrator
{
    [Area("Administrator")]
    //[Authorize(Roles = "Administrator")]
    public class StatisticsController : Controller
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IStatisticsService _service;
        public StatisticsController(IStatisticsService service, ILogger<StatisticsController> logger, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _context = context;
        }

        #endregion

        #region View

        /// <summary>
        /// 宿舍数据统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Dormitory()
        {
            return View();
        }

        /// <summary>
        /// 物品预定数据统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Goods()
        {
            return View();
        }

        /// <summary>
        /// 报名数据统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 服务预定数据统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Book()
        {
            return View();
        }

        #endregion

        #region Service
        #endregion
    }
}
