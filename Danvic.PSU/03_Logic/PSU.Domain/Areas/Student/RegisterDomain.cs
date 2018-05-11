//-----------------------------------------------------------------------
// <copyright file= "RegisterDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-06 22:59:19
// Modified by:
// Description: Student-Register控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.Entity.SignUp;
using PSU.IService.Areas.Student;
using PSU.Model.Areas.Student;
using PSU.Repository;
using PSU.Repository.Areas.Administrator;
using PSU.Repository.Areas.Student;
using PSU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Student
{
    public class RegisterDomain : IRegisterService
    {
        #region Initialize

        private readonly ILogger _logger;

        public RegisterDomain(ILogger<RegisterDomain> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Information Interface Service Implement

        /// <summary>
        /// 查找当前用户报名信息
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<InformationViewModel> GetInformationAsync(long id, ApplicationDbContext context)
        {
            var webModel = new InformationViewModel();
            try
            {
                //Get register Data
                var register = await RegisterRepository.GetEntityAsync(id, context);

                if (register != null)
                {
                    webModel.ArriveTime = register.ArriveTime.ToString("yyyy-MM-dd");
                    webModel.ExpressId = register.ExpressId;
                    webModel.Id = register.Id.ToString();
                    webModel.IsExpress = register.IsExpress;
                    webModel.Place = register.Place;
                    webModel.Remark = register.Remark;
                    webModel.Way = register.Way;
                }

                var user = await PSURepository.GetUserByIdAsync(CurrentUser.UserId, context);

                webModel.SId = user.Id.ToString();
                webModel.Department = user.Department;
                webModel.MajorClass = user.MajorClass;
                webModel.Name = user.Name;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取用户报名数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 新增当前用户报名信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> InsertInformationAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Add the register Data
                var model = await RegisterRepository.InsertAsync(webModel, context);

                if (model.Id == -1)
                {
                    return false;
                }

                //Make the transaction commit
                var index = await context.SaveChangesAsync();

                return index == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError("创建报名信息失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion

        #region Booking Interface Service Implement

        /// <summary>
        /// 获取服务预定信息
        /// </summary>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<BookingViewModel> GetBookingAsync(ApplicationDbContext context)
        {
            BookingViewModel webModel = new BookingViewModel();
            try
            {
                //Source Data List
                var list = await RegisterRepository.GetServiceListAsync(context);

                //Return Data List
                var dataList = new List<ServiceData>();

                if (list != null && list.Any())
                {
                    foreach (var item in list)
                    {
                        var info = await RegisterRepository.GetServiceAsync(item.Id, context);
                        var model = new ServiceData
                        {
                            Id = item.Id.ToString(),
                            Name = item.Name,
                            Address = item.Address,
                            StartDateTime = item.StartTime.ToString("yyyy-MM-dd HH:mm"),
                            EndDateTime = item.EndTime.ToString("yyyy-MM-dd HH:mm"),
                            IsBooking = info != null,
                            Description = !string.IsNullOrEmpty(item.Description) && item.Description.Length > 15 ? item.Description.Substring(0, 15) + "..." : item.Description
                        };
                        dataList.Add(model);
                    }
                }
                webModel.ServiceList = dataList;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取迎新服务列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 获取服务详细信息
        /// </summary>
        /// <param name="id">迎新服务编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<ServiceDetailViewModel> GetBookingAsync(long id, ApplicationDbContext context)
        {
            var webModel = new ServiceDetailViewModel();
            try
            {
                var model = await AdmissionRepository.GetServiceAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.Description = model.Description;
                webModel.EndTime = model.EndTime.ToString();
                webModel.Name = model.Name;
                webModel.Place = model.Place;
                webModel.Address = model.Address;
                webModel.StartTime = model.StartTime.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError("获取迎新服务数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 获取当前用户预定该服务的详细信息
        /// </summary>
        /// <param name="id">服务编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<BookingServiceViewModel> GetServiceBookingAsync(long id, ApplicationDbContext context)
        {
            var webModel = new BookingServiceViewModel();
            try
            {
                var model = await RegisterRepository.GetServiceAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.Count = model.Count;
                webModel.DepartureTime = model.DepartureTime.ToString("yyyy-MM-dd HH:mm");
                webModel.Remark = model.Remark;
                webModel.ScheduledTime = model.ScheduledTime;
                webModel.ServiceName = model.ServiceName;
                webModel.Tel = model.Tel;
                webModel.Place = model.Place;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取迎新服务预定数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 新增当前用户服务预定信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<int> InsertBookingAsync(BookingServiceViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Add the Service Data
                var model = await RegisterRepository.InsertAsync(webModel, context);

                if (model.Id == -1 || model.Id == -2)
                {
                    return (int)model.Id;
                }

                //Make the transaction commit
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("创建迎新服务失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return -1;
            }
        }

        #endregion

        #region Goods Interface Service Implement

        /// <summary>
        /// 获取物品信息
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<GoodsViewModel> GetGoodsAsync(ApplicationDbContext context)
        {
            GoodsViewModel webModel = new GoodsViewModel();
            try
            {
                //Source Data List
                var list = await RegisterRepository.GetGoodsListAsync(context);

                //Return Data List
                var dataList = new List<GoodsData>();

                if (list != null && list.Any())
                {
                    foreach (var item in list)
                    {
                        var goods = await RegisterRepository.GetGoodsAsync(item.Id, context);
                        var model = new GoodsData
                        {
                            Id = item.Id.ToString(),
                            Name = item.Name,
                            Size = item.Size,
                            IsChosen = goods != null,
                            Description = !string.IsNullOrEmpty(item.Description) && item.Description.Length > 15 ? item.Description.Substring(0, 15) + "..." : item.Description
                        };
                        dataList.Add(model);
                    }
                }
                webModel.GoodsList = dataList;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取物品信息列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 获取物品详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<GoodsDetailViewModel> GetGoodsAsync(long id, ApplicationDbContext context)
        {
            var webModel = new GoodsDetailViewModel();
            try
            {
                var model = await AdmissionRepository.GetGoodsAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.Description = model.Description;
                webModel.Name = model.Name;
                webModel.Size = model.Size;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取物品数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 获取当前用户选择的物品信息
        /// </summary>
        /// <param name="id">物品编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<GoodsChosenViewModel> GetGoodsChosenAsync(long id, ApplicationDbContext context)
        {
            var webModel = new GoodsChosenViewModel();
            try
            {
                var model = await RegisterRepository.GetGoodsAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.Remark = model.Remark;
                webModel.GoodsId = model.GoodsId.ToString();
                webModel.GoodsName = model.GoodsName;
                webModel.Size = model.Size;
                webModel.ChosenTime = model.ChosenTime;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取物品选择数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 新增当前用户物品选择信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> InsertGoodsAsync(GoodsChosenViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Add the goodsinfo Data
                var model = await RegisterRepository.InsertAsync(webModel, context);

                if (model.Id == -1)
                {
                    return false;
                }

                //Make the transaction commit
                var index = await context.SaveChangesAsync();

                return index == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError("物品选择失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion

        #region Dormitory Interface Service Implement

        /// <summary>
        /// 查找当前学生寝室选择信息
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<DormitoryViewModel> GetDormitoryAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增当前用户寝室选择信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> InsertDormitoryAsync(DormitoryViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
