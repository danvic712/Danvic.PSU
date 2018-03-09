//-----------------------------------------------------------------------
// <copyright file= "BulletinEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/28 星期三 16:30:16
// Modified by:
// Description: Administrator-Home-公告编辑视图模型
//-----------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace PSU.Model.Areas.Administrator.Home
{
    public class BulletinEditViewModel
    {
        #region Attribute

        /// <summary>
        /// 公告标题
        /// 判断是新增还是编辑
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// 公告类型
        /// </summary>
        public BulletinType Type { get; set; }

        /// <summary>
        /// 针对目标
        /// </summary>
        public BulletinTarget Target { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        #endregion
    }

    #region Enum

    /// <summary>
    /// 公告类型枚举
    /// </summary>
    public enum BulletinType
    {
        [Display(Name = "请选择")]
        NotSelected = 0,
        [Display(Name = "新闻公告")]
        NewsBulletin = 1,
        [Display(Name = "优惠政策")]
        PreferentialPolicy = 2
    }

    /// <summary>
    /// 公告针对目标枚举
    /// </summary>
    public enum BulletinTarget
    {
        [Display(Name = "请选择")]
        NotSelected = 0,
        [Display(Name = "全部用户")]
        All = 1,
        [Display(Name = "教职工用户")]
        Staff = 2,
        [Display(Name = "学生用户")]
        Student = 3
    }

    #endregion
}
