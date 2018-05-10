//-----------------------------------------------------------------------
// <copyright file= "IndexViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 20:00:20
// Modified by:
// Description: Student-Index-首页 View Model 
//-----------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSU.Model.Areas.Student
{
    public class IndexViewModel
    {
        #region Attribute

        /// <summary>
        /// 同一城市的人
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 提问问题
        /// </summary>
        public int Question { get; set; }

        /// <summary>
        /// 待办事项
        /// </summary>
        public int Todo { get; set; }

        /// <summary>
        /// 班级人数
        /// </summary>
        public int ClassCount { get; set; }

        /// <summary>
        /// 提问内容
        /// </summary>
        [Required(ErrorMessage = "请输入提问内容")]
        [StringLength(500, ErrorMessage = "提问内容最多不能超过500个字符长度")]
        public string Content { get; set; }

        /// <summary>
        /// 我的班级信息
        /// </summary>
        public ClassData MyClass { get; set; }

        /// <summary>
        /// 公告信息
        /// </summary>
        public BulletinData BulletinInfo { get; set; }

        #endregion
    }

    /// <summary>
    /// 班级信息
    /// </summary>
    public class ClassData
    {
        /// <summary>
        /// 班级名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 级数
        /// </summary>
        public string Session { get; set; }

        /// <summary>
        /// 辅导员姓名
        /// </summary>
        public string InstructorName { get; set; }

        /// <summary>
        /// 辅导员手机号
        /// </summary>
        public string InstructorPhone { get; set; }

        /// <summary>
        /// 辅导员微信
        /// </summary>
        public string InstructorWechat { get; set; }

        /// <summary>
        /// 辅导员QQ
        /// </summary>
        public string InstructorQQ { get; set; }

        /// <summary>
        /// 所属院系
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        public string Major { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        public string Wechat { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }
    }

    /// <summary>
    /// 公告信息
    /// </summary>
    public class BulletinData
    {
        /// <summary>
        /// 公告编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 公告标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 公告内容
        /// </summary>
        public string Content { get; set; }
    }
}
