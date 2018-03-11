//-----------------------------------------------------------------------
// <copyright file= "Campus.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:41:11
// Modified by:
// Description: 校区信息表
//-----------------------------------------------------------------------
using PSU.Entity.Basic;
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSU.Entity.Dormitory
{
    public class Campus : SysField
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string CampusOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 校区名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

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
        /// 省份名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Province { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        /// <summary>
        /// 县区名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string District { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [MaxLength(20)]
        public string Tel { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public int ZipCode { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion

        #region Foreign Key

        /// <summary>
        /// 省份主键
        /// </summary>
        public string ProvinceFK { get; set; }

        /// <summary>
        /// 城市主键
        /// </summary>
        public string CityFK { get; set; }

        /// <summary>
        /// 县区主键
        /// </summary>
        public string DistrictFK { get; set; }

        [ForeignKey("ProvinceFK")]
        public virtual Region CProvince { get; set; }

        [ForeignKey("CityFK")]
        public virtual Region CCity { get; set; }

        [ForeignKey("DistrictFK")]
        public virtual Region CDistrict { get; set; }

        #endregion
    }
}
