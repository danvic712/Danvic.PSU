//-----------------------------------------------------------------------
// <copyright file= "HomeController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:48:18
// Modified by:
// Description: Student-Home控制器
//-----------------------------------------------------------------------
using Controllers.PSU.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Student;
using PSU.Model.Areas.Student;
using PSU.Utility;
using PSU.Utility.Web;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers.PSU.Areas.Student
{
    [Area("Student")]
    [Authorize(Policy = "Student")]
    public class HomeController : DanvicController
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IHomeService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IHomeService service, ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
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
        /// 首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _service.InitIndexPageAsync(CurrentUser.UserId, _context);
            return View(model);
        }

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
                return Redirect("Bulletin");
            }

            var model = await _service.GetBulletinDetailAsync(Convert.ToInt64(id), _context);

            return View(model);
        }

        #endregion

        #region Service

        /// <summary>
        /// 学生提问
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Ask(IndexViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;

                //Update Question
                flag = await _service.AskQuestionAsync(webModel.Content, _context);

                return Json(new
                {
                    success = flag,
                    msg = flag ? "问题提交成功" : "问题提交失败"
                });
            }

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
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
                total = webModel.Total
            };

            return Json(returnData);
        }

        #endregion
    }
}
