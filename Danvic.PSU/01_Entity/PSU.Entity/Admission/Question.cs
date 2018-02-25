//-----------------------------------------------------------------------
// <copyright file= "Question.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:36:48
// Modified by:
// Description: 学生提问表
//-----------------------------------------------------------------------
using PSU.Entity.Basic;
using PSU.Entity.Identity;
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSU.Entity.Admission
{
    public class Question
    {
        #region Constructed Function

        public Question()
        {
            QuestionOID = Guid.NewGuid();
            Id = TimeUtility.GetTimespans();
        }

        #endregion

        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid QuestionOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string StuName { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        [Required]
        public int SId { get; set; }

        /// <summary>
        /// 提问时间
        /// </summary>
        [Required]
        public DateTime AskTime { get; set; }

        /// <summary>
        /// 提问内容
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        /// <summary>
        /// 提问对象编号
        /// </summary>
        [Required]
        public int AskForNumber { get; set; }

        /// <summary>
        /// 提问对象姓名
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string AskForName { get; set; }

        /// <summary>
        /// 是否回复
        /// </summary>
        public bool IsReply { get; set; }

        /// <summary>
        /// 回复人编号
        /// </summary>
        public int ReplyNumer { get; set; }

        /// <summary>
        /// 回复人姓名
        /// </summary>
        [MaxLength(10)]
        public string ReplyName { get; set; }

        /// <summary>
        /// 回复内容
        /// </summary>
        [MaxLength(200)]
        public string ReplyContent { get; set; }

        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime ReplyTime { get; set; }

        #endregion

        #region Foreign Key

        /// <summary>
        /// 提问学生外键
        /// </summary>
        public Guid StudentFK { get; set; }

        /// <summary>
        /// 提问对象主键
        /// </summary>
        public string AskForFK { get; set; }

        /// <summary>
        /// 回复人主键
        /// </summary>
        public string ReplyFK { get; set; }

        [ForeignKey("StudentFK")]
        public virtual Student Student { get; set; }

        [ForeignKey("AskForFK")]
        public virtual AppUser AskFor { get; set; }

        [ForeignKey("ReplyFK")]
        public virtual AppUser Reply { get; set; }

        #endregion
    }
}
