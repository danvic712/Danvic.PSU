//-----------------------------------------------------------------------
// <copyright file= "UserController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-07 21:24:10
// Modified by:
// Description: Instructor-User-控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Instructor;
using System.Threading.Tasks;
using PSU.Utility;
using PSU.Model.Areas.Instructor.User;
using PSU.Utility.Web;
using System.Linq;

namespace Controllers.PSU.Areas.Instructor
{
    [Area("Instructor")]
    public class UserController : Controller
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IUserService _service;
        public UserController(IUserService service, ILogger<UserController> logger, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _context = context;
        }

        #endregion

        #region View

        /// <summary>
        /// 我的班级
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Classes()
        {
            return View();
        }

        /// <summary>
        /// 班级编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditClass(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var webModel = await _service.GetClassAsync(Convert.ToInt64(id), _context);
                return View(webModel);
            }
            return Redirect("Classes");
        }

        /// <summary>
        /// 个人中心
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var webModel = await _service.GetProfileAsync(CurrentUser.UserId, _context);
            return View(webModel);
        }

        #endregion

        #region Service

        /// <summary>
        /// 我的班级页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchClass(string search)
        {
            ClassViewModel webModel = JsonUtility.ToObject<ClassViewModel>(search);

            webModel = await _service.SearchClassAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SMajor) && string.IsNullOrEmpty(webModel.SQQ);

            var returnData = new
            {
                data = webModel.ClassList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.Total
            };

            return Json(returnData);
        }

        /// <summary>
        /// 专业班级编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditClass(ClassEditViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    return Json(new
                    {
                        success = false,
                        msg = "专业班级信息编辑失败,班级编号为空"
                    });
                }
                else
                {
                    //Update Major Class
                    flag = await _service.UpdateClassAsync(webModel, _context);
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "专业班级信息编辑成功" : "专业班级信息编辑失败"
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
