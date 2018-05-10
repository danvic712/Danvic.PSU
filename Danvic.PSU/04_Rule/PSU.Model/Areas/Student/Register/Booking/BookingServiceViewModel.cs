//-----------------------------------------------------------------------
// <copyright file= "BookingServiceViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-10 22:40:45
// Modified by:
// Description: Student-Register-新生预定服务信息 View Model 
//-----------------------------------------------------------------------
using System;

namespace PSU.Model.Areas.Student
{
    public class BookingServiceViewModel
    {
        #region Attribute

        /// <summary>
        /// 服务预定编号
        /// </summary>
        public string Id { get; set; }

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
        /// 服务编号
        /// </summary>
        public string ServiceId { get; set; }

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

        #endregion
    }
}
