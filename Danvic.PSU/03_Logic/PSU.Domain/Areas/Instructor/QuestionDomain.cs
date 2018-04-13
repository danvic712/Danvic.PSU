//-----------------------------------------------------------------------
// <copyright file= "QuestionDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:29:16
// Modified by:
// Description: Instructor-Question控制器邻域功能接口实现
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Instructor;
using PSU.Model.Areas.Instructor.Question;
using PSU.Repository.Areas.Instructor;

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

        public Task<QuestionReplyViewModel> GetQuestionAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionReplyViewModel> ReplyQuestionAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

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
