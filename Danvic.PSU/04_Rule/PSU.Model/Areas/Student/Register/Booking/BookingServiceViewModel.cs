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
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "请输入联系方式")]
        [Phone(ErrorMessage = "联系方式字段请输入符合电话格式的内容")]
        public string Tel { get; set; }

        /// <summary>
        /// 人数
        /// </summary>
        [Required(ErrorMessage = "请输入人数")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "人数只能输入数字")]
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
        [Required(ErrorMessage = "请选择需要提供服务的时间")]
        [DataType(DataType.DateTime, ErrorMessage = "需要服务时间不符合日期格式要求")]
        public string DepartureTime { get; set; }

        /// <summary>
        /// 服务地点
        /// </summary>
        [Required(ErrorMessage = "请输入需要提供服务的地点")]
        [StringLength(20, ErrorMessage = "服务地点不能超过20个字符长度")]
        public string Place { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200, ErrorMessage = "备注字段不能超过200个字符长度")]
        public string Remark { get; set; }

        #endregion
    }
}
