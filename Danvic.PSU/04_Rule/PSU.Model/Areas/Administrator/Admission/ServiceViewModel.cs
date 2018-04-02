//-----------------------------------------------------------------------
// <copyright file= "ServiceViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 20:34:10
// Modified by:
// Description: Administrator-Admission-迎新服务列表页面 View Model
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace PSU.Model.Areas.Administrator.Admission
{
    public class ServiceViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 迎新服务名称
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 迎新服务地点
        /// </summary>
        public string SAddress { get; set; }

        /// <summary>
        /// 服务时间
        /// </summary>
        public string SDate { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 数据列表
        /// </summary>
        public List<ServiceData> ServiceList { get; set; }

        #endregion
    }

    /// <summary>
    /// 列表展示数据
    /// </summary>
    public class ServiceData
    {
        #region Table

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 服务地点
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartDateTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndDateTime { get; set; }

        /// <summary>
        /// 服务描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        public string IsEnabledStr => IsEnabled ? "启用" : "未启用";

        #endregion
    }
}
