//-----------------------------------------------------------------------
// <copyright file= "ProfileViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 21:58:05
// Modified by:
// Description: Administrator-Basic-个人信息页面 View Model
//-----------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace PSU.Model.Areas.Administrator.Basic
{
    public class ProfileViewModel
    {
        #region Attribute

        /// <summary>
        /// 工号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
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
        public string Phone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [EmailAddress(ErrorMessage = "输入内容不符合电子邮箱格式")]
        public string Email { get; set; }

        #endregion
    }
}
