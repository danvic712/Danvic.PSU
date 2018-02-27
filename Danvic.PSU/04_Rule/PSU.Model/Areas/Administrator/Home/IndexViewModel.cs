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
using System.Text;

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
        /// 已完成报名比例
        /// </summary>
        public double Proportion { get; set; }

        #endregion
    }
}
