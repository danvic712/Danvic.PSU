//-----------------------------------------------------------------------
// <copyright file= "BasicController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:41:59
// Modified by:
// Description: Administrator-Basic控制器
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
using PSU.Model.Areas.Administrator.Basic;
using PSU.Utility.Web;
using System.Linq;

namespace Controllers.PSU.Areas.Administrator
{
    [Area("Administrator")]
    //[Authorize(Roles = "Administrator")]
    public class BasicController : Controller
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IBasicService _service;
        public BasicController(IBasicService service, ILogger<BasicController> logger, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _context = context;
        }

        #endregion

        #region View

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

            return View(webModel);
        }

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

            return View(webModel);
        }

        /// <summary>
        /// 个人信息页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Profile()
        {
            var webModel = new ProfileViewModel();
            return View(webModel);
        }

        #endregion

        #region Service

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
    }
}
