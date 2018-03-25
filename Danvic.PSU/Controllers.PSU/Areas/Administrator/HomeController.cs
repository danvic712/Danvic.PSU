//-----------------------------------------------------------------------
// <copyright file= "HomeController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-08 19:35:43
// Modified by:
// Description: Administrator-Home-控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.Home;
using PSU.Utility.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers.PSU.Areas.Administrator
{
    [Area("Administrator")]
    //[Authorize(Roles = "Administrator")]
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
        /// 公告列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Bulletin()
        {
            return View();
        }

        /// <summary>
        /// 公告详情页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("Bulletin");
            }

            var model = await _service.GetBulletinDetailAsync(Convert.ToInt64(id), _context);

            return View(model);
        }

        /// <summary>
        /// 公告编辑页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            BulletinEditViewModel webModel = new BulletinEditViewModel
            {
                Title = "",
                Content = "",
                Target = 0,
                Type = 0
            };
            if (!string.IsNullOrEmpty(id))
            {
                //编辑页面，加载公告相关信息
                webModel = await _service.GetBulletinAsync(Convert.ToInt64(id), _context);
            }
            return View(webModel);
        }

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
        /// 删除公告数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            bool flag = await _service.DeleteBulletinAsync(Convert.ToInt64(id), _context);

            return Json(new
            {
                sueeess = flag,
                msg = flag ? "数据删除成功，公告编号：" + id : "数据删除失败，公告编号：" + id
            });
        }

        /// <summary>
        /// 公告编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(BulletinEditViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    //Add Bulletin
                    flag = await _service.InsertBulletinAsync(webModel, _context);
                }
                else
                {
                    //Update Bulletin
                    flag = await _service.UpdateBulletinAsync(webModel, _context);
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "公告信息编辑成功" : "公告信息编辑失败"
                });
            }

            //Todo:return ModelState Error Info
            //Return First Error Information
            //var msg = ModelState.Values.First().Errors[0].ErrorMessage;

            return Json(new
            {
                success = false
            });
        }

        /// <summary>
        /// 公告页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Search(string search)
        {
            BulletinViewModel webModel = JsonUtility.ToObject<BulletinViewModel>(search);

            webModel = await _service.SearchBulletinAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.STitle) && string.IsNullOrEmpty(webModel.SDateTime) && webModel.SType == 0;

            var returnData = new
            {
                data = webModel.BulletinList,
                limit = webModel.Limit,
                page = flag == true ? webModel.Page : 1,
                total = webModel.BulletinList.Count
            };

            return Json(returnData);
        }

        /// <summary>
        /// 获取折线图数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetLineChart()
        {
            string chart = await _service.InitLineChartAsync(_context);
            return Json(chart);
        }

        /// <summary>
        /// 获取饼图数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetPieChart()
        {
            string chart = await _service.InitPieChartAsync(_context);
            return Json(chart);
        }

        #endregion
    }
}
