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
using System.Threading.Tasks;
using PSU.Model.Areas.Administrator.Statistics;
using PSU.Utility.Web;

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

        /// <summary>
        /// 服务预定信息详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> BookInfo(string id)
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
        /// 新生报名信息页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchGoods(string search)
        {
            GoodsViewModel webModel = JsonUtility.ToObject<GoodsViewModel>(search);

            webModel = await _service.SearchGoodsAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SGoodsName) && string.IsNullOrEmpty(webModel.SDate);

            var returnData = new
            {
                data = webModel.GoodsList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.GoodsList.Count
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

        /// <summary>
        /// 新生服务预定信息页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchService(string search)
        {
            BookViewModel webModel = JsonUtility.ToObject<BookViewModel>(search);

            webModel = await _service.SearchBookAsync(webModel, _context);
          
            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SStudent) && string.IsNullOrEmpty(webModel.SDate);

            var returnData = new
            {
                data = webModel.BookList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.BookList.Count
            };

            return Json(returnData);
        }

        #endregion
    }
}
