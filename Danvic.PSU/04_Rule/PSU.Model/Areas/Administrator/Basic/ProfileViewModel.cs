﻿//-----------------------------------------------------------------------
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
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        [StringLength(200)]
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
        public string Phone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        #endregion
    }
}