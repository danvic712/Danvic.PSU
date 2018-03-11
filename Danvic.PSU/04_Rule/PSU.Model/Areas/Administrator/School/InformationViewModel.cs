//-----------------------------------------------------------------------
// <copyright file= "InformationViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-11 20:01:02
// Modified by:
// Description: Administrator-School-学校信息视图模型
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSU.Model.Areas.Administrator.School
{
    public class InformationViewModel
    {
        #region Comprehensive Information

        /// <summary>
        /// 学校编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageSrc { get; set; }

        /// <summary>
        /// 图片二进制流
        /// </summary>
        public byte Image { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string NameEN { get; set; }

        /// <summary>
        /// 院校代码
        /// </summary>
        [Required]
        public int Code { get; set; }

        /// <summary>
        /// 建校时间
        /// </summary>
        public DateTime SetUpTime { get; set; }

        /// <summary>
        /// 校训
        /// </summary>
        [MaxLength(100)]
        public string Motto { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }

        #endregion

        #region Campus Information 

        /// <summary>
        /// 校区名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string CampusName { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [MaxLength(20)]
        public string CampusTel { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public int ZipCode { get; set; }

        /// <summary>
        /// 省份编号
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string ProvinceId { get; set; }

        /// <summary>
        /// 城市编号
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string CityId { get; set; }

        /// <summary>
        /// 县区编号
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string DistrictId { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        #endregion

        #region Contact Information

        /// <summary>
        /// 官方网站
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string WebSite { get; set; }

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
        /// 电子邮箱
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 官方QQ
        /// </summary>
        [MaxLength(20)]
        public long QQ { get; set; }

        #endregion

        #region Detail Information

        /// <summary>
        /// 详细介绍
        /// </summary>
        [MaxLength(500)]
        public string Introduction { get; set; }

        #endregion
    }
}
