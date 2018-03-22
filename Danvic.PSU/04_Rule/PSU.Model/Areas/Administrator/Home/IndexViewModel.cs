//-----------------------------------------------------------------------
// <copyright file= "IndexViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/27 星期二 15:06:02
// Modified by:
// Description: Administrator-Home-首页视图模型
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace PSU.Model.Areas.Administrator.Home
{
    public class IndexViewModel
    {
        #region Attribute

        /// <summary>
        /// 今日报名人数
        /// </summary>
        public int TodayEnrollmentCount { get; set; }

        /// <summary>
        /// 昨日报名人数
        /// </summary>
        public int YesterdayEnrollmentCount { get; set; }

        /// <summary>
        /// 问题总数
        /// </summary>
        public int QuestionCount { get; set; }

        /// <summary>
        /// 已完成报名比例
        /// </summary>
        public double Proportion { get; set; }

        /// <summary>
        /// 报名人数走势曲线图
        /// </summary>
        public string Chart { get; set; }
        
        /// <summary>
        /// 公告列表
        /// </summary>
        public List<BulletinData> BulletinList { get; set; }

        /// <summary>
        /// 生源地分布饼图
        /// </summary>
        public string Pie { get; set; }

        /// <summary>
        /// 问题列表
        /// </summary>
        public List<QuestionData> QuestionList { get; set; }

        #endregion
    }

    /// <summary>
    /// 公告列表
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
    }

    /// <summary>
    /// 学生疑问列表
    /// </summary>
    public class QuestionData
    {
        /// <summary>
        /// 问题编号
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
        public DateTime DateTime { get; set; }
    }
}
