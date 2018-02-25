//-----------------------------------------------------------------------
// <copyright file= "Student.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:40:18
// Modified by:
// Description: 学生信息表
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSU.Entity.Basic
{
    public class Student : SysField
    {
        #region Constructed Function

        public Student()
        {
            StudentOID = Guid.NewGuid();
            Id = TimeUtility.GetTimespans();
            CreatedOn = DateTime.Now;
        }

        #endregion

        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid StudentOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public short Age { get; set; }

        /// <summary>
        /// 生日日期
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        [MaxLength(500)]
        public string ImageSrc { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [MaxLength(100)]
        public string Address { get; set; }

        /// <summary>
        /// 兴趣爱好
        /// </summary>
        [MaxLength(500)]
        public string Hobbies { get; set; }

        /// <summary>
        /// 获奖情况
        /// </summary>
        [MaxLength(500)]
        public string Winning { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        [MaxLength(50)]
        public string Province { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        [MaxLength(50)]
        public string City { get; set; }

        /// <summary>
        /// 县区名称
        /// </summary>
        [MaxLength(50)]
        public string District { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        [Required]
        public int SId { get; set; }

        /// <summary>
        /// 系部名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Department { get; set; }

        /// <summary>
        /// 专业名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Major { get; set; }

        /// <summary>
        /// 专业班级
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string MajorClass { get; set; }

        /// <summary>
        /// 高中名称
        /// </summary>
        [MaxLength(50)]
        public string HighSchool { get; set; }

        /// <summary>
        /// 入学年月
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 毕业年月
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        [MaxLength(1000)]
        public string Files { get; set; }

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
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion

        #region Foreign Key

        /// <summary>
        /// 省份主键
        /// </summary>
        public Guid ProvinceFK { get; set; }

        /// <summary>
        /// 城市主键
        /// </summary>
        public Guid CityFK { get; set; }

        /// <summary>
        /// 县区主键
        /// </summary>
        public Guid DistrictFK { get; set; }

        [ForeignKey("ProvinceFK")]
        public virtual Region SProvince { get; set; }

        [ForeignKey("CityFK")]
        public virtual Region SCity { get; set; }

        [ForeignKey("DistrictFK")]
        public virtual Region SDistrict { get; set; }

        #endregion
    }
}
