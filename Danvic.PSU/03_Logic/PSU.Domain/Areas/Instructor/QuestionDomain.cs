//-----------------------------------------------------------------------
// <copyright file= "QuestionDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:29:16
// Modified by:
// Description: Instructor-Question控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Instructor;
using PSU.Model.Areas.Instructor.Question;
using PSU.Repository;
using PSU.Repository.Areas.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Instructor
{
    public class QuestionDomain : IQuestionService
    {
        #region Initialize

        private readonly ILogger _logger;

        public QuestionDomain(ILogger<QuestionDomain> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Question Interface Service Implement

        /// <summary>
        /// 获取学生疑问信息
        /// </summary>
        /// <param name="id">问题编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<QuestionReplyViewModel> GetQuestionAsync(long id, ApplicationDbContext context)
        {
            var webModel = new QuestionReplyViewModel();
            try
            {
                var model = await QuestionRepository.GetQuestionAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.AskForName = model.AskForName;
                webModel.AskTime = model.AskTime.ToString("yyyy-MM-dd HH:mm:ss");
                webModel.Content = model.Content;
                webModel.IsReply = model.IsReply;
                webModel.ReplyContent = model.ReplyContent;
                webModel.ReplyId = model.ReplyId;
                webModel.ReplyName = model.ReplyName;
                webModel.ReplyTime = model.ReplyTime.ToString("yyyy-MM-dd HH:mm:ss");
                webModel.StuName = model.StuName;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取疑问信息数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 回复学生疑问信息
        /// </summary>
        /// <param name="webModel">回复信息页视图Model</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<bool> ReplyQuestionAsync(QuestionReplyViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update Question Data
                QuestionRepository.ReplyQuestionAsync(webModel, context);

                //Add Operate Information
                var operate = string.Format("回复学生疑问信息，学生疑问编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync("Question", "QuestionDomain", "ReplyQuestionAsync", operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

                var index = await context.SaveChangesAsync();

                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("回复学生疑问失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 搜索学生疑问信息
        /// </summary>
        /// <param name="webModel"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<QuestionViewModel> SearchQuestionAsync(QuestionViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await QuestionRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<QuestionData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new QuestionData
                    {
                        Id = item.Id.ToString(),
                        Name = item.StuName,
                        DateTime = item.AskTime.ToString("yyyy-MM-dd HH:mm"),
                        IsReply = item.IsReply,
                        Content = item.Content.Length > 20 ? item.Content.Substring(0, 20) + "..." : item.Content
                    }));
                }

                webModel.QuestionList = dataList;
                webModel.Total = await QuestionRepository.GetListCountAsync(webModel, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取提问信息列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        #endregion
    }
}
