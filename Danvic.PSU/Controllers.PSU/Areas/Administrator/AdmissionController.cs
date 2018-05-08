//-----------------------------------------------------------------------
// <copyright file= "AdmissionController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:44:13
// Modified by:
// Description: Administrator-Admission控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.Admission;
using PSU.Utility.Web;
using System.Linq;

namespace Controllers.PSU.Areas.Administrator
{
    [Area("Administrator")]
    [Authorize(Policy = "Administrator")]
    public class AdmissionController : Controller
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IAdmissionService _service;
        public AdmissionController(IAdmissionService service, ILogger<AdmissionController> logger, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _context = context;
        }

        #endregion

        #region View

        /// <summary>
        /// 物品信息编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditGoods(string id)
        {
            GoodsEditViewModel webModel = new GoodsEditViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                //编辑信息，加载物品相关信息
                webModel = await _service.GetGoodsAsync(Convert.ToInt64(id), _context);
            }

            return View(webModel);
        }

        /// <summary>
        /// 迎新服务编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditService(string id)
        {
            ServiceEditViewModel webModel = new ServiceEditViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                //编辑信息，加载迎新服务信息
                webModel = await _service.GetServiceAsync(Convert.ToInt64(id), _context);
            }

            return View(webModel);
        }

        /// <summary>
        /// 物品信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Goods()
        {
            return View();
        }

        /// <summary>
        /// 学生疑问数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Question()
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
            return Redirect("Question");
        }

        /// <summary>
        /// 迎新服务
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Service()
        {
            return View();
        }
        #endregion

        #region Service

        /// <summary>
        /// 删除物品信息数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteGoods(string id)
        {
            bool flag = await _service.DeleteGoodsAsync(Convert.ToInt64(id), _context);

            return Json(new
            {
                sueeess = flag,
                msg = flag ? "数据删除成功，物品编号：" + id : "数据删除失败，物品编号：" + id
            });
        }

        /// <summary>
        /// 删除迎新服务数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteService(string id)
        {
            bool flag = await _service.DeleteServiceAsync(Convert.ToInt64(id), _context);

            return Json(new
            {
                sueeess = flag,
                msg = flag ? "数据删除成功，迎新服务编号：" + id : "数据删除失败，迎新服务编号：" + id
            });
        }

        /// <summary>
        /// 物品信息编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditGoods(GoodsEditViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    //Add Data
                    flag = await _service.InsertGoodsAsync(webModel, _context);
                }
                else
                {
                    //Update Data
                    flag = await _service.UpdateGoodsAsync(webModel, _context);
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "物品信息编辑成功" : "物品信息编辑失败"
                });
            }

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
            });
        }

        /// <summary>
        /// 迎新服务编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditService(ServiceEditViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    //Add Data
                    flag = await _service.InsertServiceAsync(webModel, _context);
                }
                else
                {
                    //Update Data
                    flag = await _service.UpdateServiceAsync(webModel, _context);
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "迎新服务信息编辑成功" : "迎新服务信息编辑失败"
                });
            }

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
            });
        }

        /// <summary>
        /// 物品信息页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchGoods(string search)
        {
            GoodsViewModel webModel = JsonUtility.ToObject<GoodsViewModel>(search);

            webModel = await _service.SearchGoodsAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SId) && webModel.SEnable == -1;

            var returnData = new
            {
                data = webModel.GoodsList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.Total
            };

            return Json(returnData);
        }

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
            bool flag = string.IsNullOrEmpty(webModel.SAskFor) && string.IsNullOrEmpty(webModel.SDateTime) && webModel.IsReply == -1;

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
        /// 迎新服务页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchService(string search)
        {
            ServiceViewModel webModel = JsonUtility.ToObject<ServiceViewModel>(search);

            webModel = await _service.SearchServiceAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SAddress) && string.IsNullOrEmpty(webModel.SDate);

            var returnData = new
            {
                data = webModel.ServiceList,
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
