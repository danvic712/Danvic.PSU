//-----------------------------------------------------------------------
// <copyright file= "Record.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/2 星期五 9:07:53
// Modified by:
// Description: 账号操作记录表
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.Basic
{
    public class Record
    {
        #region Attrbite

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string RecordOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 操作修改表
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string TableName { get; set; }

        /// <summary>
        /// 操作方法所在类
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string ClassName { get; set; }

        /// <summary>
        /// 操作方法名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string MethodName { get; set; }

        /// <summary>
        /// 数据项对应编号
        /// </summary>
        [Required]
        public long DataId { get; set; }

        /// <summary>
        /// 操作人主键
        /// </summary>
        [Required]
        public string UserOID { get; set; }

        /// <summary>
        /// 操作人编号
        /// </summary>
        [Required]
        public long UserId { get; set; }

        /// <summary>
        /// 操作人姓名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime DateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 操作类型
        /// 1：修改；2：删除
        /// </summary>
        [Required]
        public short Type { get; set; }

        /// <summary>
        /// 所做操作
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Operate { get; set; }

        #endregion
    }
}
