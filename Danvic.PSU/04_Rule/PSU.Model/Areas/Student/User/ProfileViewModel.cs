//-----------------------------------------------------------------------
// <copyright file= "ProfileViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-06 22:45:37
// Modified by:
// Description: Student-Index-个人中心页面 View Model 
//-----------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace PSU.Model.Areas.Student
{
    public class ProfileViewModel
    {
        #region Attribute

        /// <summary>
        /// 用户编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [EmailAddress(ErrorMessage = "输入内容不符合电子邮箱格式规范")]
        public string Email { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [StringLength(20, ErrorMessage = "手机号不能超过20个字符长度")]
        [Phone(ErrorMessage = "输入内容不符合电话格式")]
        public string Phone { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required(ErrorMessage = "用户姓名不能为空")]
        [StringLength(20, ErrorMessage = "用户姓名不能超过20个字符长度")]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 准考证号
        /// </summary>
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "准考证号只能输入数字")]
        public string TicketId { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Required(ErrorMessage = "身份证号不能为空")]
        [StringLength(18, ErrorMessage = "身份证号不能超过20个字符长度")]
        public string IdNumber { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        [MaxLength(50, ErrorMessage = "微信号不能超过20个字符长度")]
        public string Wechat { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "QQ号只能输入数字")]
        [MaxLength(20, ErrorMessage = "QQ号不能超过20个字符长度")]
        public string QQ { get; set; }

        /// <summary>
        /// 高中名称
        /// </summary>
        [MaxLength(50)]
        public string HighSchool { get; set; }

        /// <summary>
        /// 生日日期
        /// </summary>
        [DataType(DataType.DateTime, ErrorMessage = "出生年月输入的内容不符合日期格式")]
        public string Birthday { get; set; }

        /// <summary>
        /// 入学年月
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// 毕业年月
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 省份代码
        /// </summary>
        public int ProvinceId { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        [StringLength(50)]
        public string Province { get; set; }

        /// <summary>
        /// 城市代码
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        [StringLength(50)]
        public string City { get; set; }

        /// <summary>
        /// 县区Id
        /// </summary>
        public int DistrictId { get; set; }

        /// <summary>
        /// 县区名称
        /// </summary>
        [StringLength(50)]
        public string District { get; set; }

        /// <summary>
        /// 家庭住址
        /// </summary>
        [StringLength(200, ErrorMessage = "家庭住址字段不能超过200个字符长度")]
        public string Address { get; set; }

        /// <summary>
        /// 所属院系名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 专业班级名称
        /// </summary>
        public string MajorClass { get; set; }

        /// <summary>
        /// 兴趣爱好
        /// </summary>
        [StringLength(100, ErrorMessage = "兴趣爱好不能超过100个字符长度")]
        public string Hobbies { get; set; }

        /// <summary>
        /// 获奖情况
        /// </summary>
        [StringLength(500, ErrorMessage = "获奖情况不能超过500个字符长度")]
        public string Winning { get; set; }

        #endregion
    }
}
