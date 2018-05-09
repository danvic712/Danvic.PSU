//-----------------------------------------------------------------------
// <copyright file= "QuestionController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/7 星期三 13:13:34
// Modified by:
// Description: Instructor-Question-控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Instructor;
using PSU.Model.Areas.Instructor.Question;
using PSU.Utility;
using PSU.Utility.Web;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers.PSU.Areas.Instructor
{
    [Area("Instructor")]
    [Authorize(Policy = "Instructor")]
    public class QuestionController : Controller
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IQuestionService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public QuestionController(IQuestionService service, ILogger<QuestionController> logger, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
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
        /// 学生疑问数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Information()
        {
            return View();
        }

        /// <summary>
        /// 回复疑问信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Reply(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var webModel = await _service.GetQuestionAsync(Convert.ToInt64(id), _context);
                return View(webModel);
            }
            return Redirect("Information");
        }

        #endregion

        #region Service

        /// <summary>
        /// 学生疑问页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchQuestion(string search)
        {
            QuestionViewModel webModel = JsonUtility.ToObject<QuestionViewModel>(search);

            webModel = await _service.SearchQuestionAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SDateTime) && webModel.IsReply == -1;

            var returnData = new
            {
                data = webModel.QuestionList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.Total
            };

            return Json(returnData);
        }

        /// <summary>
        /// 回复学生疑问信息页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Reply(QuestionReplyViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    return Json(new
                    {
                        success = false,
                        msg = "回复学生疑问信息失败,问题编号为空"
                    });
                }
                else
                {
                    //Update Question
                    flag = await _service.ReplyQuestionAsync(webModel, _context);
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "回复学生疑问信息成功" : "回复学生疑问信息失败"
                });
            }

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
            });
        }

        #endregion
    }
}
