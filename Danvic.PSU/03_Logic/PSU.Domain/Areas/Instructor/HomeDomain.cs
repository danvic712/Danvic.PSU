//-----------------------------------------------------------------------
// <copyright file= "HomeDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:28:32
// Modified by:
// Description: Instructor-Home控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Instructor;
using PSU.Model.Areas.Instructor.Home;
using PSU.Repository;
using PSU.Repository.Areas.Instructor;
using PSU.Utility.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Instructor
{
    public class HomeDomain : IHomeService
    {
        #region Initialize

        private readonly ILogger _logger;

        public HomeDomain(ILogger<HomeDomain> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Index Interface Service Implement

        /// <summary>
        /// 初始化加载
        /// </summary>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<IndexViewModel> InitIndexPageAsync(ApplicationDbContext context)
        {
            IndexViewModel webModel = new IndexViewModel();
            try
            {
                webModel.TodayEnrollmentCount = HomeRepository.GetTodayEnrollmentCount(context);
                webModel.YesterdayEnrollmentCount = HomeRepository.GetYesterdayEnrollmentCount(context);
                webModel.QuestionCount = HomeRepository.GetQuestionCount(context);
                webModel.Proportion = HomeRepository.GetProportion(context);
                webModel.BulletinList = (from item in await HomeRepository.GetBulletinList(context)
                                         select new BulletinData
                                         {
                                             Id = item.Id.ToString(),
                                             Title = item.Title
                                         }).ToList();
                webModel.QuestionList = (from item in await HomeRepository.GetQuestionList(context)
                                         select new QuestionData()
                                         {
                                             Id = item.Id.ToString(),
                                             Name = item.StuName,
                                             Content = item.Content,
                                             DateTime = item.AskTime
                                         }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("首页初始化失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 初始化加载折线图数据
        /// </summary>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<List<LineChartData>> InitLineChartAsync(ApplicationDbContext context)
        {
            return await HomeRepository.GetChartInfo(context);
        }

        /// <summary>
        /// 初始化加载折线图数据
        /// </summary>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<List<PieData>> InitPieChartAsync(ApplicationDbContext context)
        {
            return await HomeRepository.GetPieInfo(context);
        }

        #endregion

        #region Bulletin Interface Service Implement

        /// <summary>
        /// 获取公告详情
        /// </summary>
        /// <param name="id">公告编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<BulletinDetailViewModel> GetBulletinDetailAsync(long id, ApplicationDbContext context)
        {
            //Get Bulletin Data
            var bulletin = await HomeRepository.GetEntityAsync(id, context);

            //Bulid Web Model
            var webModel = new BulletinDetailViewModel
            {
                Title = bulletin.Title,
                Content = bulletin.Content,
                CreatedOn = bulletin.CreatedOn,
                OperateName = bulletin.CreatedName
            };
            return webModel;
        }

        /// <summary>
        /// 搜索公告数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<BulletinViewModel> SearchBulletinAsync(BulletinViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await HomeRepository.GetListAsync(webModel.Limit, webModel.Page, webModel.Start, webModel.STitle,
                    webModel.SDateTime, webModel.SType, context);
                //Return Data List
                var dataList = new List<ReturnData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(from item in list
                                      let content = StringUtility.HtmlToText(item.Content).Length <= 10 ? StringUtility.HtmlToText(item.Content) : StringUtility.HtmlToText(item.Content).Substring(0, 10) + "..."
                                      select new ReturnData
                                      {
                                          Id = item.Id.ToString(),
                                          Content = content,
                                          DateTime = item.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss"),
                                          Publisher = item.CreatedName,
                                          Target = item.Target,
                                          Title = item.Title,
                                          Type = item.Type
                                      });
                }

                webModel.BulletinList = dataList;
                webModel.Total = await HomeRepository.GetListCountAsync(webModel.Limit, webModel.Page, webModel.Start, webModel.STitle,
                    webModel.SDateTime, webModel.SType, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取公告列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        #endregion
    }
}
