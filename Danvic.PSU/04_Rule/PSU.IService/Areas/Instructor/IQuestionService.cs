//-----------------------------------------------------------------------
// <copyright file= "IQuestionService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:22:41
// Modified by:
// Description: Instructor-Question控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Model.Areas.Instructor.Question;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Instructor
{
    public interface IQuestionService
    {
        #region Question 

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">问题编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<QuestionReplyViewModel> GetQuestionAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">问题编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<QuestionReplyViewModel> ReplyQuestionAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<QuestionViewModel> SearchQuestionAsync(QuestionViewModel webModel, ApplicationDbContext context);

        #endregion
    }
}
