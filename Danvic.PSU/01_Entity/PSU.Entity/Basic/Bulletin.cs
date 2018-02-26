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
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [MaxLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [MaxLength(1000)]
        public string Content { get; set; }

        /// <summary>
        /// 公告类型
        /// 1:公告信息;2:优惠政策
        /// </summary>
        [Required]
        public short Type { get; set; }

        /// <summary>
        /// 发布人
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Publisher { get; set; }

        #endregion

        #region Foreign Key

        /// <summary>
        /// 发布人主键
        /// </summary>
        public string PublisherFK { get; set; }

        [ForeignKey("PublisherFK")]
        public virtual Staff Publish { get; set; }

        #endregion
    }
}
