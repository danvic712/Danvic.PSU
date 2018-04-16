//-----------------------------------------------------------------------
// <copyright file= "IndexViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:27:32
// Modified by:
// Description: Instructor-Home-首页 View Model
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace PSU.Model.Areas.Instructor.Home
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
        /// 公告列表
        /// </summary>
        public List<BulletinData> BulletinList { get; set; }

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

    /// <summary>
    /// 折线图数据
    /// </summary>
    public class LineChartData
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string Day { get; set; }

        /// <summary>
        /// 报名人数
        /// </summary>
        public int Count { get; set; }
    }

    /// <summary>
    /// 饼图数据
    /// </summary>
    public class PieData
    {
        /// <summary>
        /// 生源地
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 新生人数
        /// </summary>
        public int Count { get; set; }
    }
}
