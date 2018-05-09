//-----------------------------------------------------------------------
// <copyright file= "ProfileViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:50:05
// Modified by:
// Description: Instructor-User-个人信息页面 View Model
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSU.Model.Areas.Instructor.User
{
    public class ProfileViewModel
    {
        #region Attribute

        /// <summary>
        /// 工号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required(ErrorMessage = "用户姓名不能为空")]
        [StringLength(20, ErrorMessage = "用户姓名字段不能超过20个字符长度")]
        public string Name { get; set; }

        /// <summary>
        /// 登录账户名
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        [StringLength(200, ErrorMessage = "联系地址内容不能超过200个字符长度")]
        public string Address { get; set; }

        /// <summary>
        /// 所属院系名称
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Phone(ErrorMessage = "输入内容不符合手机号格式")]
        [StringLength(20, ErrorMessage = "手机号不能超过20个字符长度")]
        public string Phone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [EmailAddress(ErrorMessage = "输入内容不符合电子邮箱格式")]
        [StringLength(50, ErrorMessage = "电子邮箱不能超过20个字符长度")]
        public string Email { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        [StringLength(50, ErrorMessage = "微信号不能超过20个字符长度")]
        public string Wechat { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "QQ号只能输入数字")]
        [StringLength(20, ErrorMessage = "QQ号不能超过20个字符长度")]
        public string QQ { get; set; }

        #endregion
    }
}
