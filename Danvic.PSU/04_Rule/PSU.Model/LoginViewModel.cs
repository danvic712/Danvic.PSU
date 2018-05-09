//-----------------------------------------------------------------------
// <copyright file= "LoginViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/8 星期四 16:57:31
// Modified by:
// Description: 登录视图模型
//-----------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace PSU.Model
{
    public class LoginViewModel
    {
        #region Attribute

        /// <summary>
        /// 帐户名
        /// </summary>
        [Required(ErrorMessage = "登录名不能为空")]
        [Display(Name = "登录名")]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 是否记住帐户名
        /// </summary>
        [Display(Name = "记住登录名")]
        public bool RememberMe { get; set; }

        #endregion
    }
}
