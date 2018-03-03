//-----------------------------------------------------------------------
// <copyright file= "College.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:42:22
// Modified by:
// Description: 学校信息表
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.School
{
    public class College : SysField
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string CollegeOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 中文名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        [MaxLength(200)]
        public string NameEN { get; set; }

        /// <summary>
        /// 校训
        /// </summary>
        [MaxLength(100)]
        public string Motto { get; set; }

        /// <summary>
        /// 建校时间
        /// </summary>
        public DateTime SetUpTime { get; set; }

        /// <summary>
        /// 官方网站
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string WebSite { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 官方微博
        /// </summary>
        [MaxLength(50)]
        public string Weibo { get; set; }

        /// <summary>
        /// 官方微信公众号
        /// </summary>
        [MaxLength(50)]
        public string Wechat { get; set; }

        /// <summary>
        /// 官方QQ
        /// </summary>
        [MaxLength(20)]
        public long QQ { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }

        /// <summary>
        /// 详细介绍
        /// </summary>
        [MaxLength(500)]
        public string Introduction { get; set; }

        /// <summary>
        /// 校徽
        /// </summary>
        [MaxLength(500)]
        public string SchoolBadge { get; set; }

        /// <summary>
        /// 校徽图片二进制流
        /// </summary>
        public byte Badge { get; set; }

        /// <summary>
        /// 宣传图地址
        /// </summary>
        [MaxLength(500)]
        public string ImageSrc { get; set; }

        /// <summary>
        /// 宣传图二进制流
        /// </summary>
        public byte Image { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion
    }
}
