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

namespace PSU.Entity.Basic
{
    public class Student : SysField
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string StudentOID { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        /// <summary>
        /// 准考证号
        /// </summary>
        [Required]
        public long TicketId { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Required]
        public long IdNumber { get; set; }

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
        /// 家庭地址
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
        /// 省份代码
        /// </summary>
        public int ProvinceId { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        [MaxLength(50)]
        public string Province { get; set; }

        /// <summary>
        /// 城市代码
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        [MaxLength(50)]
        public string City { get; set; }

        /// <summary>
        /// 县区Id
        /// </summary>
        public int DistrictId { get; set; }

        /// <summary>
        /// 县区名称
        /// </summary>
        [MaxLength(50)]
        public string District { get; set; }

        /// <summary>
        /// 院系编号
        /// </summary>
        public long DepartmentId { get; set; }

        /// <summary>
        /// 院系名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Department { get; set; }

        /// <summary>
        /// 专业班级编号
        /// </summary>
        public long MajorClassId { get; set; }

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
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion

        #region Foreign Key

        /// <summary>
        /// 账号主键
        /// </summary>
        public string IdentityUserFK { get; set; }

        #endregion
    }
}
