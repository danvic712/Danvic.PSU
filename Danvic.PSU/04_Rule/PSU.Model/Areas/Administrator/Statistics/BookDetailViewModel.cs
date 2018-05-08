//-----------------------------------------------------------------------
// <copyright file= "BookDetailViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-06 21:14:15
// Modified by:
// Description: Administrator-Statistics-服务预定详情页面 View Model
//-----------------------------------------------------------------------
using System;

namespace PSU.Model.Areas.Administrator.Statistics
{
    public class BookDetailViewModel
    {
        #region Attribute

        /// <summary>
        /// 服务预定编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 人数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 预定时间
        /// </summary>
        public DateTime ScheduledTime { get; set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 服务时间
        /// </summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// 服务地点
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否取消
        /// </summary>
        public bool IsCancel { get; set; }

        #endregion
    }
}
