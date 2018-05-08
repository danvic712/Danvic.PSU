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
using System.Linq;

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

        /// <summary>
        /// 宿舍类型列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Bunk()
        {
            return View();
        }

        /// <summary>
        /// 宿舍类型编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditBunk(string id)
        {
            BunkEditViewModel webModel = new BunkEditViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                //编辑信息，加载宿舍楼相关信息
                webModel = await _service.GetBunkAsync(Convert.ToInt64(id), _context);
            }

            return View(webModel);
        }

        /// <summary>
        /// 宿舍编辑页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditInformation(string id)
        {
            InformationEditViewModel webModel = new InformationEditViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                //编辑信息，加载宿舍相关信息
                webModel = await _service.GetInformationAsync(Convert.ToInt64(id), _context);
            }

            return View(webModel);
        }

        /// <summary>
        /// 宿舍信息列表页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Information()
        {
            return View();
        }
        #endregion

        #region Service

        /// <summary>
        /// 删除宿舍楼数据
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

        /// <summary>
        /// 删除宿舍类型数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteBunk(string id)
        {
            bool flag = await _service.DeleteBunkAsync(Convert.ToInt64(id), _context);

            return Json(new
            {
                sueeess = flag,
                msg = flag ? "数据删除成功，宿舍类型编号：" + id : "数据删除失败，宿舍类型编号：" + id
            });
        }

        /// <summary>
        /// 删除宿舍数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteInformation(string id)
        {
            bool flag = await _service.DeleteInformationAsync(Convert.ToInt64(id), _context);

            return Json(new
            {
                sueeess = flag,
                msg = flag ? "数据删除成功，宿舍编号：" + id : "数据删除失败，宿舍编号：" + id
            });
        }

        /// <summary>
        /// 宿舍楼编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditBuilding(BuildingEditViewModel webModel)
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

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
            });
        }

        /// <summary>
        /// 宿舍类型编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditBunk(BunkEditViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    //Add Building
                    flag = await _service.InsertBunkAsync(webModel, _context);
                }
                else
                {
                    //Update Building
                    flag = await _service.UpdateBunkAsync(webModel, _context);
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "宿舍类型信息编辑成功" : "宿舍类型信息编辑失败"
                });
            }

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
            });
        }

        /// <summary>
        /// 宿舍编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditInformation(InformationEditViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    //Add Dorm Information
                    flag = await _service.InsertInformationAsync(webModel, _context);
                }
                else
                {
                    //Update Dorm Information
                    flag = await _service.UpdateInformationAsync(webModel, _context);
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "宿舍信息编辑成功" : "宿舍信息编辑失败"
                });
            }

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
            });
        }

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
                total = webModel.Total
            };

            return Json(returnData);
        }

        /// <summary>
        /// 宿舍楼搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchBunk(string search)
        {
            BunkViewModel webModel = JsonUtility.ToObject<BunkViewModel>(search);

            webModel = await _service.SearchBunkAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SDirection) && webModel.SEnable == -1;

            var returnData = new
            {
                data = webModel.BunkList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.Total
            };

            return Json(returnData);
        }

        /// <summary>
        /// 宿舍搜索
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchInformation(string search)
        {
            InformationViewModel webModel = JsonUtility.ToObject<InformationViewModel>(search);

            webModel = await _service.SearchInformationAsync(webModel, _context);

            //Search Or Init
            bool flag = string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SType) && webModel.SFloor == -1;

            var returnData = new
            {
                data = webModel.InformationList,
                limit = webModel.Limit,
                page = flag ? webModel.Page : 1,
                total = webModel.Total
            };

            return Json(returnData);
        }

        #endregion
    }
}
