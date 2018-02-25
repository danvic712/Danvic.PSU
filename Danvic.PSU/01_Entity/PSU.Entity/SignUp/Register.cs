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
        #region Constructed Function

        public Register()
        {
            RegisterOID = Guid.NewGuid();
            Id = TimeUtility.GetTimespans();
        }

        #endregion

        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid RegisterOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

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
        /// 到达地点
        /// </summary>
        [Required]
        public string Place { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Remark { get; set; }

        #endregion
    }
}
