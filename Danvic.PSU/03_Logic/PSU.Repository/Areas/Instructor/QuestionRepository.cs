//-----------------------------------------------------------------------
// <copyright file= "QuestionRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:33:04
// Modified by:
// Description: Instructor-Question-功能实现仓储
//-----------------------------------------------------------------------
using PSU.Entity.Admission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Model.Areas.Instructor.Question;
using PSU.Utility;

namespace PSU.Repository.Areas.Instructor
{
    public class QuestionRepository
    {
        #region Question API

        /// <summary>
        /// 搜索学生疑问信息
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Question>> GetListAsync(QuestionViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SDateTime) && webModel.IsReply == -1)
            {
                return await context.Set<Question>().AsNoTracking().Where(i => i.AskForFK == CurrentUser.UserOID).Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.AskTime).ToListAsync();
            }
            else
            {
                IQueryable<Question> questions = context.Question.AsQueryable();

                var predicate = PredicateBuilder.New<Question>();

                //当前登录人数据
                predicate = predicate.And(i => i.AskForFK == CurrentUser.UserOID);

                //学生姓名
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.StuName.Contains(webModel.SName));
                }

                //提问时间
                if (!string.IsNullOrEmpty(webModel.SDateTime))
                {
                    predicate = predicate.And(i => i.AskTime.ToString("yyyy-MM-dd") == webModel.SDateTime);
                }

                //是否回复
                if (webModel.IsReply != -1)
                {
                    bool flag = webModel.IsReply == 1;
                    predicate = predicate.And(i => i.IsReply == flag);
                }

                return await questions.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        #endregion
    }
}
