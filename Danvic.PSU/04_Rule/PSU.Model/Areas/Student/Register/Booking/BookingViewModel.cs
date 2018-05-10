//-----------------------------------------------------------------------
// <copyright file= "BookingViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-10 15:46:33
// Modified by:
// Description: Student-Register-预定页面 View Model 
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Student
{
    public class BookingViewModel
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        public List<ServiceData> ServiceList { get; set; }
    }

    /// <summary>
    /// 服务列表
    /// </summary>
    public class ServiceData
    {
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
        /// 是否预定
        /// </summary>
        public bool IsBooking { get; set; }
    }
}
