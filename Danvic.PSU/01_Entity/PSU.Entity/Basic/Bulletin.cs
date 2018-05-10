//-----------------------------------------------------------------------
// <copyright file= "Bulletin.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:39:27
// Modified by:
// Description: 网站公告表
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.Basic
{
    public class Bulletin : SysField
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string BulletinOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        /// <summary>
        /// 公告类型
        /// 1:公告信息;2:学校政策
        /// </summary>
        [Required]
        public short Type { get; set; }

        /// <summary>
        /// 针对用户
        /// 1:全部用户;2:教职工用户;3:学生用户
        /// </summary>
        [Required]
        public short Target { get; set; }

        #endregion
    }
}
