//-----------------------------------------------------------------------
// <copyright file= "StatisticsDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-04-02 21:17:07
// Modified by:
// Description: Administrator-Admission控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.Statistics;
using PSU.Repository.Areas.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Administrator
{
    public class StatisticsDomain : IStatisticsService
    {
        #region Initialize

        private readonly ILogger _logger;

        public StatisticsDomain(ILogger<StatisticsDomain> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Register Interface Service Implement

        /// <summary>
        /// 搜索新生注册信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<RegisterViewModel> SearchRegisterAsync(RegisterViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await StatisticsRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<RegisterData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new RegisterData
                    {
                        Id = item.StudentId.ToString(),
                        Name = item.Name,
                        Address = item.Place,
                        Department = item.Department,
                        MajorClass = item.MajorClass,
                        Way = item.Way,
                        DateTime = item.ArriveTime,
                        Express = item.ExpressId
                    }));
                }

                webModel.RegisterList = dataList;
                webModel.Total = await StatisticsRepository.GetListCountAsync(webModel, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取新生注册列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        #endregion

        #region Goods Interface Service Implement

        /// <summary>
        /// 搜索物品选择数据信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<GoodsViewModel> SearchGoodsAsync(GoodsViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await StatisticsRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<GoodsData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new GoodsData
                    {
                        Id = item.StudentId.ToString(),
                        Name = item.StudentName,
                        GoodsId = item.GoodsId.ToString(),
                        GoodsName = item.GoodsName,
                        Size = item.Size,
                        DateTime = item.ChosenTime,
                        Remark = item.Remark.Length > 20 ? item.Remark.Substring(0, 20) : item.Remark
                    }));
                }

                webModel.GoodsList = dataList;
                webModel.Total = await StatisticsRepository.GetListCountAsync(webModel, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取物品选择列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        #endregion

        #region Dormitory Interface Service Implement

        /// <summary>
        /// 搜索宿舍预定信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<DormitoryViewModel> SearchDormitoryAsync(DormitoryViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await StatisticsRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<DormitoryData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new DormitoryData
                    {
                        Dorm = item.DormName,
                        Floor = item.Floor,
                        Building = item.BuildingName,
                        Count = item.Count,
                        Chosen = item.Chosen,
                        StudentName = item.StudentName
                    }));
                }

                webModel.DormitoryList = dataList;
                webModel.Total = await StatisticsRepository.GetListCountAsync(webModel, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取宿舍预定列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        #endregion

        #region Book Interface Service Implement

        /// <summary>
        /// 搜索迎新服务预定信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<BookViewModel> SearchBookAsync(BookViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await StatisticsRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<BookData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new BookData
                    {
                        Id = item.Id.ToString(),
                        Name = item.Name,
                        Tel = item.Tel,
                        Count = item.Count,
                        ScheduledTime = item.ScheduledTime.ToString("yyyy-MM-dd HH:mm"),
                        ServiceName = item.ServiceName,
                        DepartureTime = item.DepartureTime.ToString("yyyy-MM-dd HH:mm"),
                        Place = item.Place,
                        Remark = item.Remark.Length > 20 ? item.Remark.Substring(0, 20) : item.Remark
                    }));
                }

                webModel.BookList = dataList;
                webModel.Total = await StatisticsRepository.GetListCountAsync(webModel, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取迎新服务预定列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        #endregion
    }
}
