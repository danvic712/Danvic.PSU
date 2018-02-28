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
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.Home;
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

        public HomeController(IHomeService service, ILogger<HomeController> logger)
        {
            _service = service;
            _logger = logger;
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
            var webModel = await _service.InitPageAsync();
            return View(webModel);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BulletinEditViewModel webModel)
        {
            return View();
        }

        #endregion
    }
}
