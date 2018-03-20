//-----------------------------------------------------------------------
// <copyright file= "DepartmentEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/13 星期二 14:44:44
// Modified by:
// Description: Administrator-School-院系编辑视图模型
//-----------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace PSU.Model.Areas.Administrator.School
{
    public class DepartmentEditViewModel
    {
        #region Attribute

        /// <summary>
        /// 院系编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 部门/院系名称
        /// </summary>
        [Required(ErrorMessage = "部门/院系名称不能为空")]
        [StringLength(20, ErrorMessage = "部门/院系名称不能超过20个字符长度")]
        public string Name { get; set; }

        /// <summary>
        /// 办公地址
        /// </summary>
        [StringLength(200, ErrorMessage = "办公地址不能超过200个字符长度")]
        public string Address { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Required]
        [Phone(ErrorMessage = "输入内容不符合格式要求")]
        [StringLength(20, ErrorMessage = "联系电话不能超过20个字符长度")]
        public string Tel { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [EmailAddress(ErrorMessage = "输入内容不符合电子邮箱格式")]
        public string Email { get; set; }

        /// <summary>
        /// 官方微博
        /// </summary>
        [StringLength(50, ErrorMessage = "联系电话不能超过50个字符长度")]
        public string Weibo { get; set; }

        /// <summary>
        /// 官方微信公众号
        /// </summary>
        [StringLength(50, ErrorMessage = "官方微信公众号不能超过50个字符长度")]
        public string Wechat { get; set; }

        /// <summary>
        /// 官方QQ
        /// </summary>
        [StringLength(20, ErrorMessage = "官方QQ不能超过20个字符长度")]
        public long QQ { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        [StringLength(200, ErrorMessage = "介绍信息不能超过200个字符长度")]
        public string Introduction { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public Enable IsEnabled { get; set; }

        /// <summary>
        /// 是否为部门
        /// </summary>
        public Branch IsBranch { get; set; }

        #endregion
    }

    #region Enum

    /// <summary>
    /// 是否启用枚举
    /// </summary>
    public enum Enable
    {
        [Display(Name = "不启用")]
        NotUse = 0,
        [Display(Name = "启用")]
        Use = 1,
    }

    /// <summary>
    /// 是否为部门
    /// </summary>
    public enum Branch
    {
        [Display(Name = "否")]
        False = 0,
        [Display(Name = "是")]
        True = 1,
    }

    #endregion
}
