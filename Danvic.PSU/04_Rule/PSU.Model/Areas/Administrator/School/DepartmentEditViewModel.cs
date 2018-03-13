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
        /// 院系名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 所属校区编号
        /// </summary>
        public string CampusId { get; set; }

        /// <summary>
        /// 办公地址
        /// </summary>
        [MaxLength(200)]
        public string Address { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Tel { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 官方微博
        /// </summary>
        [MaxLength(20)]
        public string Weibo { get; set; }

        /// <summary>
        /// 官方微信公众号
        /// </summary>
        [MaxLength(50)]
        public string Wechat { get; set; }

        /// <summary>
        /// 官方QQ
        /// </summary>
        [MaxLength(20)]
        public long QQ { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        [MaxLength(200)]
        public string Introduction { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion
    }

    #region Enum
    public enum IsEnable
    {
        [Display(Name = "不启用")]
        NotSelected = 0,
        [Display(Name = "启用")]
        NewsBulletin = 1,
    }
    #endregion
}
