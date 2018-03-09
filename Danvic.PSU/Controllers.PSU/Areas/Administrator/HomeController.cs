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
using System.Threading.Tasks;

namespace Controllers.PSU.Areas.Administrator
{
    [Area("Administrator")]
    //[Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        #region Initialize

        private readonly IHomeService _service;

        private readonly ILogger _logger;

        private readonly ApplicationDbContext _context;

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
            var webModel = await _service.InitIndexPageAsync();
            return View();
        }

        /// <summary>
        /// 公告页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Bulletin()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        #endregion

        #region Service

        /// <summary>
        /// 公告页面搜索
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Search(string search)
        {
            BulletinViewModel webModel = JsonUtility.ToObject<BulletinViewModel>(search);

            webModel = await _service.SearchBulletinAsync(webModel, _context);

            //var data = new ReturnData
            //{
            //    Id = "1111111111111",
            //    Content = "11111111",
            //    DateTime = DateTime.Now.ToString(),
            //    Publisher = "我发布的啊",
            //    Target = 1,
            //    Title = "我是标题啊",
            //    Type = 1
            //};

            //List<ReturnData> list = new List<ReturnData>();
            //list.Add(data);

            //webModel.BulletinList = list;

            var returnData = new
            {
                data = webModel.BulletinList,
                limit = webModel.Limit,
                page = webModel.Page,
                total = webModel.BulletinList.Count
            };

            return Json(returnData);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BulletinEditViewModel webModel)
        {
            return View();
        }

        #endregion
    }
}
