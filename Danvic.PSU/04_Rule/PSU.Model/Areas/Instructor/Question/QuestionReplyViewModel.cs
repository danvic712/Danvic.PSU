//-----------------------------------------------------------------------
// <copyright file= "QuestionReplyViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:50:23
// Modified by:
// Description: Instructor-Question-学生疑问回复页面 View Model 
//-----------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace PSU.Model.Areas.Instructor.Question
{
    public class QuestionReplyViewModel
    {
        #region Attribute

        /// <summary>
        /// 学生提问编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StuName { get; set; }

        /// <summary>
        /// 提问时间
        /// </summary>
        public string AskTime { get; set; }

        /// <summary>
        /// 提问对象姓名
        /// </summary>
        public string AskForName { get; set; }

        /// <summary>
        /// 提问内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 是否回复
        /// </summary>
        public bool IsReply { get; set; }

        /// <summary>
        /// 回复人编号
        /// </summary>
        public long ReplyId { get; set; }

        /// <summary>
        /// 回复人姓名
        /// </summary>
        public string ReplyName { get; set; }

        /// <summary>
        /// 回复内容
        /// </summary>
        [StringLength(200, ErrorMessage = "回复内容不能超过200个字符长度")]
        public string ReplyContent { get; set; }

        /// <summary>
        /// 回复时间
        /// </summary>
        public string ReplyTime { get; set; }

        #endregion
    }
}
