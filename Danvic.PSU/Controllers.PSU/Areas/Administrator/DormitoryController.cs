//-----------------------------------------------------------------------
// <copyright file= "DormitoryController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/10 星期六 15:43:36
// Modified by:
// Description: Administrator-Dormitory控制器
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
using PSU.Model.Areas.Administrator.Dormitory;
using PSU.Utility.Web;

namespace Controllers.PSU.Areas.Administrator
{
    [Area("Administrator")]
    //[Authorize(Roles = "Administrator")]
    public class DormitoryController : Controller
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IDormitoryService _service;
        public DormitoryController(IDormitoryService service, ILogger<DormitoryController> logger, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _context = context;
        }

        #endregion

        #region View

        /// <summary>
        /// 宿舍楼列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Building()
        {
            return View();
        }

        public IActionResult Bunk()
        {
            return View();
        }

        public IActionResult Information()
        {
            return View();
        }

        /// <summary>
        /// 宿舍楼编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditBuilding(string id)
        {
            BuildingEditViewModel webModel = new BuildingEditViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                //编辑信息，加载宿舍楼相关信息
                webModel = await _service.GetBuildingAsync(Convert.ToInt64(id), _context);
            }

            return View(webModel);
        }

        public IActionResult EditInformation()
        {
            return View();
        }

        #endregion

        #region Service

        /// <summary>
        /// 宿舍楼搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchBuilding(string search)
        {
            BuildingViewModel webModel = JsonUtility.ToObject<BuildingViewModel>(search);

            webModel = await _service.SearchBuildingAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SId) && webModel.SType == 0 && webModel.SEnable == 9;

            var returnData = new
            {
                data = webModel.BuildingList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.BuildingList.Count
            };

            return Json(returnData);
        }

        /// <summary>
        /// 宿舍楼编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditDepartment(BuildingEditViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    //Add Building
                    flag = await _service.InsertBuildingAsync(webModel, _context);
                }
                else
                {
                    //Update Building
                    flag = await _service.UpdateBuildingAsync(webModel, _context);
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "宿舍楼信息编辑成功" : "宿舍楼信息编辑失败"
                });
            }

            //Todo:return ModelState Error Info
            //Return First Error Information
            //var msg = ModelState.Values.First().Errors[0].ErrorMessage;

            return Json(new
            {
                success = false,
                //msg = ModelState.Values.First().Errors[0].ErrorMessage
            });
        }

        /// <summary>
        /// 删除部门/院系数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteBuilding(string id)
        {
            bool flag = await _service.DeleteBuildingAsync(Convert.ToInt64(id), _context);

            return Json(new
            {
                sueeess = flag,
                msg = flag ? "数据删除成功，宿舍楼编号：" + id : "数据删除失败，宿舍楼编号：" + id
            });
        }

        #endregion
    }
}
