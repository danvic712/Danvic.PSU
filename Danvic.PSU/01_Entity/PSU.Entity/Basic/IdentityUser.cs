//-----------------------------------------------------------------------
// <copyright file= "IdentityUser.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-08 21:59:38
// Modified by:
// Description: 用户类
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.Basic
{
    public class IdentityUser : SysField
    {
        #region Attribute-Common

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string IdentityUserOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 帐户名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Account { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [MaxLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 加密参数
        /// </summary>
        [Required]
        public string Salt { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Required]
        public long IdNumber { get; set; }

        /// <summary>
        /// 生日日期
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string ImageSrc { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        [MaxLength(50)]
        public string Wechat { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [MaxLength(20)]
        public string QQ { get; set; }

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
        /// 家庭住址
        /// </summary>
        [MaxLength(200)]
        public string Address { get; set; }

        /// <summary>
        /// 所属院系、部门编号
        /// </summary>
        public long DepartmentId { get; set; }

        /// <summary>
        /// 所属院系、部门名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Department { get; set; }

        /// <summary>
        /// 账户类型
        /// 0：管理员账户；1：教职工账户；2：学生用户
        /// </summary>
        public short AccountType { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 主页地址
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string HomePage { get; set; }

        #endregion

        #region Attribute-Instructor

        /// <summary>
        /// 是否为院系负责人
        /// </summary>
        public bool IsMaster { get; set; }

        #endregion

        #region Attribute-Student

        /// <summary>
        /// 准考证号
        /// </summary>
        [Required]
        public long TicketId { get; set; }

        /// <summary>
        /// 辅导员Id
        /// </summary>
        public long InstructorId { get; set; }

        /// <summary>
        /// 辅导员姓名
        /// </summary>
        [MaxLength(20)]
        public string InstructorName { get; set; }

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
        /// 专业班级编号
        /// </summary>
        public long MajorClassId { get; set; }

        /// <summary>
        /// 专业班级名称
        /// </summary>
        [MaxLength(20)]
        public string MajorClass { get; set; }

        /// <summary>
        /// 兴趣爱好
        /// </summary>
        [MaxLength(100)]
        public string Hobbies { get; set; }

        /// <summary>
        /// 获奖情况
        /// </summary>
        [MaxLength(500)]
        public string Winning { get; set; }

        #endregion
    }
}
