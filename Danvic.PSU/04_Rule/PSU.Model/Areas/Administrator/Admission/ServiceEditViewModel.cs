//-----------------------------------------------------------------------
// <copyright file= "ServiceEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 20:42:35
// Modified by:
// Description: Administrator-Admission-迎新服务编辑页面 View Model 
//-----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using static PSU.Model.Areas.EnumType;

namespace PSU.Model.Areas.Administrator.Admission
{
    public class ServiceEditViewModel
    {
        #region Attribute

        /// <summary>
        /// 迎新服务编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "服务名称不能为空")]
        [StringLength(20, ErrorMessage = "服务名称不能超过20个字符长度")]
        public string Name { get; set; }

        /// <summary>
        /// 迎新项目描述
        /// </summary>
        [StringLength(200, ErrorMessage = "迎新项目描述不能超过200个字符长度")]
        public string Description { get; set; }

        /// <summary>
        /// 服务提供开始时间
        /// </summary>
        [Required(ErrorMessage = "迎新服务开始时间不能为空")]
        [DataType(DataType.DateTime, ErrorMessage = "迎新服务开始时间不符合时间格式")]
        public string StartTime { get; set; }

        /// <summary>
        /// 服务提供结束时间
        /// </summary>
        [Required(ErrorMessage = "迎新服务结束间不能为空")]
        [DataType(DataType.DateTime, ErrorMessage = "迎新服务结束时间不符合时间格式")]
        public string EndTime { get; set; }

        /// <summary>
        /// 服务地点
        /// </summary>
        [StringLength(10)]
        public string Place { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [Required(ErrorMessage = "详细地址不能为空")]
        [StringLength(20, ErrorMessage = "详细地址不能超过20个字符长度")]
        public string Address { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public Enable IsEnabled { get; set; }

        #endregion
    }
}
