//-----------------------------------------------------------------------
// <copyright file= "StaffEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 22:05:46
// Modified by:
// Description: Administrator-Basic-职工账户编辑页面 View Model 
//-----------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PSU.Model.Areas.EnumType;

namespace PSU.Model.Areas.Administrator.Basic
{
    public class StaffEditViewModel
    {
        #region Attribute

        /// <summary>
        /// 职工工号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 登录帐户名
        /// </summary>
        [Required(ErrorMessage = "账户不能为空")]
        [MaxLength(20, ErrorMessage = "账户不能超过20个字符长度")]
        public string Account { get; set; }

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
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码字段不能为空")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

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
        /// 所属院系、部门编号
        /// </summary>
        [Required(ErrorMessage = "所属院系不能为空")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "院系编号只能为数字")]
        public long DepartmentId { get; set; }

        /// <summary>
        /// 所属院系名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 是否为院系负责人
        /// </summary>
        public bool IsMaster { get; set; }

        /// <summary>
        /// 家庭住址
        /// </summary>
        [StringLength(200, ErrorMessage = "联络地址字段不能超过200个字符长度")]
        public string Address { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public Enable IsEnabled { get; set; }

        /// <summary>
        /// 部门下拉
        /// </summary>
        public List<DepartmentDropDown> DepartmentList { get; set; }

        #endregion
    }

    /// <summary>
    /// 编辑页面部门下拉
    /// </summary>
    public class DepartmentDropDown
    {
        /// <summary>
        /// 部门编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }
    }
}
