//-----------------------------------------------------------------------
// <copyright file= "HomeDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 20:01:08
// Modified by:
// Description: Student-Home控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Student;
using PSU.Model.Areas.Student;
using PSU.Repository;
using PSU.Repository.Areas.Administrator;
using PSU.Utility;
using PSU.Utility.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Student
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
        /// 学生提问
        /// </summary>
        /// <param name="content">提问内容</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> AskQuestionAsync(string content, ApplicationDbContext context)
        {
            try
            {
                //Add the Question Data
                var model = await Repository.Areas.Student.HomeRepository.InsertAsync(content, context);

                if (model.Id == -1)
                {
                    return false;
                }

                //Make the transaction union
                var index = await context.SaveChangesAsync();

                return index == 1 ? true : false;
            }
            catch (Exception ex)
            {
                _logger.LogError("创建学生提问信息失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 页面加载初始化
        /// </summary>
        /// <param name="id">当前用户编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<IndexViewModel> InitIndexPageAsync(long id, ApplicationDbContext context)
        {
            IndexViewModel webModel = new IndexViewModel();
            try
            {
                webModel.Count = await Repository.Areas.Student.HomeRepository.GetSameCityCountAsync(context);
                webModel.Question = Repository.Areas.Student.HomeRepository.GetQuestionCountAsync(context);
                webModel.Todo = await Repository.Areas.Student.HomeRepository.GetTodoCountAsync(context);
                webModel.ClassCount = await Repository.Areas.Student.HomeRepository.GetClassCountAsync(context);

                var user = await PSURepository.GetUserByIdAsync(CurrentUser.UserId, context);
                var majorclass = await SchoolRepository.GetMajorClassAsync(user.MajorClassId, context);
                var instructor = await PSURepository.GetUserByIdAsync(majorclass.InstructorId, context);

                webModel.MyClass = new ClassData
                {
                    Department = majorclass.DepartmentName,
                    InstructorName = majorclass.InstructorName,
                    InstructorPhone = instructor.Phone,
                    InstructorQQ = instructor.QQ.ToString(),
                    InstructorWechat = string.IsNullOrEmpty(instructor.Wechat) ? "未预留微信号" : instructor.Wechat,
                    Major = majorclass.MajorName,
                    Name = majorclass.Name,
                    QQ = majorclass.QQ,
                    Session = majorclass.SessionNum + "级",
                    Wechat = string.IsNullOrEmpty(majorclass.Wechat) ? "未预留微信号" : majorclass.Wechat,
                };

                var bulletin = await Repository.Areas.Student.HomeRepository.GetBulletinInfo(context);
                webModel.BulletinInfo = new BulletinData
                {
                    Id = bulletin.Id.ToString(),
                    Title = bulletin.Title,
                    Content = bulletin.Content
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("首页初始化失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
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
            var bulletin = await Repository.Areas.Student.HomeRepository.GetEntityAsync(id, context);

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
                var list = await Repository.Areas.Student.HomeRepository.GetListAsync(webModel.Limit, webModel.Page, webModel.Start, webModel.STitle,
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
                webModel.Total = await Repository.Areas.Student.HomeRepository.GetListCountAsync(webModel.Limit, webModel.Page, webModel.Start, webModel.STitle,
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
