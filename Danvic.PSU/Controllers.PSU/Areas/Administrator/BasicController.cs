//-----------------------------------------------------------------------
// <copyright file= "BasicController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:41:59
// Modified by:
// Description: Administrator-Basic控制器
//-----------------------------------------------------------------------
using Controllers.PSU.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.Basic;
using PSU.Utility;
using PSU.Utility.Web;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers.PSU.Areas.Administrator
{
    [Area("Administrator")]
    [Authorize(Policy = "Administrator")]
    public class BasicController : DanvicController
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IBasicService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BasicController(IBasicService service, ILogger<BasicController> logger, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
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
        /// 职工管理页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Staff()
        {
            return View();
        }

        /// <summary>
        /// 职工编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditStaff(string id)
        {
            StaffEditViewModel webModel = new StaffEditViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                webModel = await _service.GetStaffAsync(Convert.ToInt64(id), _context);
            }

            //加载下拉列表信息
            webModel = await _service.GetDropDownListAsync(webModel, _context);

            return View(webModel);
        }

        /// <summary>
        /// 学生用户管理页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Student()
        {
            return View();
        }

        /// <summary>
        /// 学生编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditStudent(string id)
        {
            StudentEditViewModel webModel = new StudentEditViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                webModel = await _service.GetStudentAsync(Convert.ToInt64(id), _context);
            }

            //加载下拉列表信息
            webModel = await _service.GetDropDownListAsync(webModel, _context);

            return View(webModel);
        }

        /// <summary>
        /// 个人信息页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            if (CurrentUser.UserId != 0)
            {
                var webModel = await _service.GetUserProfileAsync(CurrentUser.UserId, _context);
                return View(webModel);
            }
            return Redirect("/");
        }

        #endregion

        #region Service-Profile

        /// <summary>
        /// 个人信息编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditProfile(ProfileViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (!string.IsNullOrEmpty(webModel.Id))
                {
                    flag = await _service.UpdateUserProfileAsync(webModel, _context);
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        msg = "个人信息编辑失败，编号为0"
                    });
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "个人信息编辑成功" : "个人信息编辑失败"
                });
            }

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
            });
        }

        #endregion

        #region Service-Staff

        /// <summary>
        /// 教职工信息页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchStaff(string search)
        {
            StaffViewModel webModel = JsonUtility.ToObject<StaffViewModel>(search);

            webModel = await _service.SearchStaffAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SDepartment) && string.IsNullOrEmpty(webModel.SId);

            var returnData = new
            {
                data = webModel.StaffList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.Total
            };

            return Json(returnData);
        }

        /// <summary>
        /// 删除教职工数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteStaff(string id)
        {
            bool flag = await _service.DeleteStaffAsync(Convert.ToInt64(id), _context);

            return Json(new
            {
                sueeess = flag,
                msg = flag ? "数据删除成功，教职工工号：" + id : "数据删除失败，教职工工号：" + id
            });
        }

        /// <summary>
        /// 教职工编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditStaff(StaffEditViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    //Add Staff
                    flag = await _service.InsertStaffAsync(webModel, _context);
                }
                else
                {
                    //Update Staff
                    flag = await _service.UpdateStaffAsync(webModel, _context);
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "教职工信息编辑成功" : "教职工信息编辑失败"
                });
            }

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
            });
        }

        #endregion

        #region Service-Student

        /// <summary>
        /// 学生信息页面搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchStudent(string search)
        {
            StudentViewModel webModel = JsonUtility.ToObject<StudentViewModel>(search);

            webModel = await _service.SearchStudentAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SMajorClass) && string.IsNullOrEmpty(webModel.SId);

            var returnData = new
            {
                data = webModel.StudentList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.Total
            };

            return Json(returnData);
        }

        /// <summary>
        /// 删除学生数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            bool flag = await _service.DeleteStudentAsync(Convert.ToInt64(id), _context);

            return Json(new
            {
                sueeess = flag,
                msg = flag ? "数据删除成功，学生学号：" + id : "数据删除失败，学生学号：" + id
            });
        }

        /// <summary>
        /// 学生编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditStudent(StudentEditViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    //Add Student
                    flag = await _service.InsertStudentAsync(webModel, _context);
                }
                else
                {
                    //Update Student
                    flag = await _service.UpdateStudentAsync(webModel, _context);
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "学生信息编辑成功" : "学生信息编辑失败"
                });
            }

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
            });
        }

        #endregion

        #region Service-Common

        /// <summary>
        /// 判断当前账户名是否存在
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<IActionResult> CheckAccount(string account)
        {
            bool flag = await _service.CheckAccountAsync(account, _context);

            return Json(new
            {
                sueeess = flag,
                msg = flag ? "当前用户名已存在：" : "当前用户名未存在"
            });
        }

        #endregion
    }
}
