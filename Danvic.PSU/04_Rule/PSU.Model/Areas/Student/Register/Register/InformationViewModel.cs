//-----------------------------------------------------------------------
// <copyright file= "InformationViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-10 15:45:27
// Modified by:
// Description: Student-Register-报名页面 View Model 
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSU.Model.Areas.Student
{
    public class InformationViewModel
    {
        #region Attribute

        /// <summary>
        /// 报名信息编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        public string SId { get; set; }

        /// <summary>
        /// 所属院系名称
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 专业班级名称
        /// </summary>
        public string MajorClass { get; set; }

        /// <summary>
        /// 来校方式
        /// 1:火车;2:客车;3:飞机;4:自驾;5:客船;6:其它
        /// </summary>
        [Required(ErrorMessage = "请选择来校方式")]
        public short Way { get; set; }

        /// <summary>
        /// 到达地点
        /// </summary>
        [Required(ErrorMessage = "请填写到达地点")]
        [StringLength(30, ErrorMessage = "到达地点字段不能超过30个字符长度")]
        public string Place { get; set; }

        /// <summary>
        /// 预计到达时间
        /// </summary>
        [Required(ErrorMessage = "请选择预计到达日期")]
        [DataType(DataType.Date, ErrorMessage = "预计到达日期不符合日期格式要求")]
        public string ArriveTime { get; set; }

        /// <summary>
        /// 档案是否快递
        /// </summary>
        [Required(ErrorMessage = "请选择档案是否快递")]
        public bool IsExpress { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        [StringLength(50, ErrorMessage = "快递单号不能超过50个字段长度")]
        public string ExpressId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200, ErrorMessage = "备注不能超过200个字段长度")]
        public string Remark { get; set; }

        #endregion
    }
}
