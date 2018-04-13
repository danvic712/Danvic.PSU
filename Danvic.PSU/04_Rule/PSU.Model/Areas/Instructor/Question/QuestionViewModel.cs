//-----------------------------------------------------------------------
// <copyright file= "QuestionViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:47:45
// Modified by:
// Description: Instructor-Question-学生疑问列表页面 View Model
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Instructor.Question
{
    public class QuestionViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 提问日期
        /// </summary>
        public string SDateTime { get; set; }

        /// <summary>
        /// 是否回复
        /// </summary>
        public short IsReply { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 学生疑问列表
        /// </summary>
        public List<QuestionData> QuestionList { get; set; }

        #endregion

    }

    /// <summary>
    /// 学生疑问信息
    /// </summary>
    public class QuestionData
    {
        #region Table

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 提问内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 提问时间
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// 是否回复
        /// </summary>
        public bool IsReply { get; set; }

        public string IsReplyStr => IsReply ? "已回复" : "未回复";

        #endregion
    }
}
