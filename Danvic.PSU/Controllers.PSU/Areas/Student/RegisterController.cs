//-----------------------------------------------------------------------
// <copyright file= "RegisterController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-06 22:57:02
// Modified by:
// Description: 
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
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers.PSU.Areas.Student
{
    [Area("Student")]
    [Authorize(Policy = "Student")]
    public class RegisterController : DanvicController
    {
        #region Initialize

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IRegisterService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RegisterController(IRegisterService service, ILogger<RegisterController> logger, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
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
        /// 入学报名总页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Information()
        {
            return View();
        }

        /// <summary>
        /// 报名信息页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var webModel = await _service.GetInformationAsync(CurrentUser.UserId, _context);
            return View(webModel);
        }

        /// <summary>
        /// 服务预定页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Booking()
        {
            var webModel = await _service.GetBookingAsync(_context);
            return View(webModel);
        }

        /// <summary>
        /// 迎新服务编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ServiceInfo(string id)
        {
            ServiceDetailViewModel webModel = new ServiceDetailViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                //编辑信息，加载迎新服务信息
                webModel = await _service.GetBookingAsync(Convert.ToInt64(id), _context);
            }

            return View(webModel);
        }

        /// <summary>
        ///预定服务详情页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> BookingService(string id, bool isBooking)
        {
            BookingServiceViewModel webModel = new BookingServiceViewModel();
            webModel.ServiceId = id;

            if (isBooking)
            {
                //编辑信息，加载迎新服务信息
                webModel = await _service.GetServiceBookingAsync(Convert.ToInt64(id), _context);
            }

            return View(webModel);
        }

        /// <summary>
        /// 物品页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Goods()
        {
            var webModel = await _service.GetGoodsAsync(_context);
            return View(webModel);
        }

        /// <summary>
        /// 物品信息编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GoodsInfo(string id)
        {
            GoodsDetailViewModel webModel = new GoodsDetailViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                //编辑信息，加载物品相关信息
                webModel = await _service.GetGoodsAsync(Convert.ToInt64(id), _context);
            }

            return View(webModel);
        }

        /// <summary>
        ///选择物品页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> BookingGoods(string id, bool isChosen)
        {
            GoodsChosenViewModel webModel = new GoodsChosenViewModel();
            webModel.GoodsId = id;

            if (isChosen)
            {
                //加载物品选择信息
                webModel = await _service.GetGoodsChosenAsync(Convert.ToInt64(id), _context);
            }

            return View(webModel);
        }

        /// <summary>
        /// 寝室选择页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Dormitory()
        {
            return View();
        }

        #endregion

        #region Service-Information

        /// <summary>
        /// 学生编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SignUp(InformationViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    //Add Register
                    flag = await _service.InsertInformationAsync(webModel, _context);
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        msg = "预报名信息禁止修改"
                    });
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "预报名成功" : "预报名失败"
                });
            }

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
            });
        }

        #endregion

        #region Service-Booking

        /// <summary>
        /// 迎新服务编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> BookingService(BookingServiceViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    //Add Data
                    int index = await _service.InsertBookingAsync(webModel, _context);

                    if (index == -1)
                    {
                        return Json(new
                        {
                            success = false,
                            msg = "迎新服务预定失败"
                        });
                    }

                    if (index == -2)
                    {
                        return Json(new
                        {
                            success = false,
                            msg = "需要服务时间不在迎新服务提供时间段内"
                        });
                    }

                    flag = index == 1;
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        msg = "迎新服务预定信息禁止修改"
                    });
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "迎新服务预定成功" : "迎新服务预定失败"
                });
            }

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
            });
        }

        #endregion

        #region Service-Goods

        /// <summary>
        /// 学生编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> BookingGoods(GoodsChosenViewModel webModel)
        {
            if (ModelState.IsValid)
            {
                bool flag;
                if (string.IsNullOrEmpty(webModel.Id))
                {
                    //Add goods
                    flag = await _service.InsertGoodsAsync(webModel, _context);
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        msg = "物品选择信息禁止修改"
                    });
                }

                return Json(new
                {
                    success = flag,
                    msg = flag ? "物品选择成功" : "物品选择失败"
                });
            }

            return Json(new
            {
                success = false,
                msg = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors).FirstOrDefault().ErrorMessage
            });
        }

        #endregion

        #region Service-Dormitory
        #endregion
    }
}
