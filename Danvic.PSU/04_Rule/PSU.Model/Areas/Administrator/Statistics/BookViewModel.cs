//-----------------------------------------------------------------------
// <copyright file= "BookViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 21:55:25
// Modified by:
// Description: Administrator-Statistics-服务预定列表页面 View Model
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace PSU.Model.Areas.Administrator.Statistics
{
    public class BookViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string SStudent { get; set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 预定时间
        /// </summary>
        public string SDate { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 迎新服务选择数据列表
        /// </summary>
        public List<BookData> BookList { get; set; }

        #endregion
    }

    /// <summary>
    /// 服务预定信息
    /// </summary>
    public class BookData
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
        /// 联系方式
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 人数
        /// </summary>
        public int Count { get; set; }

        public string CountStr => Count + "人";

        /// <summary>
        /// 预定时间
        /// </summary>
        public string ScheduledTime { get; set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 服务时间
        /// </summary>
        public string DepartureTime { get; set; }

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

        public string IsCancelStr => IsCancel ? "是" : "否";

        #endregion
    }
}
