//-----------------------------------------------------------------------
// <copyright file= "Register.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:44:04
// Modified by:
// Description: 新生报名信息表
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.SignUp
{
    public class Register
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string RegisterOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 学生姓名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 学生学号
        /// </summary>
        [Required]
        public long StudentId { get; set; }

        /// <summary>
        /// 院系名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Department { get; set; }

        /// <summary>
        /// 专业班级
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string MajorClass { get; set; }

        /// <summary>
        /// 来校方式
        /// 1:火车;2:客车;3:飞机;4:自驾;5:客船;6:其它
        /// </summary>
        public short Way { get; set; }

        /// <summary>
        /// 预计到达时间
        /// </summary>
        public DateTime ArriveTime { get; set; }

        /// <summary>
        /// 完成预报名时间
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 到达地点
        /// </summary>
        [Required]
        public string Place { get; set; }

        /// <summary>
        /// 档案是否快递
        /// </summary>
        public bool IsExpress { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        [MaxLength(50)]
        public string ExpressId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Remark { get; set; }

        #endregion
    }
}
