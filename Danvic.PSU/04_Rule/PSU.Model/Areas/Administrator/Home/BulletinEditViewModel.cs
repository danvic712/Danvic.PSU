//-----------------------------------------------------------------------
// <copyright file= "BulletinEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/28 星期三 16:30:16
// Modified by:
// Description: Administrator-Home-公告编辑信息页面 View Model
//-----------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace PSU.Model.Areas.Administrator.Home
{
    public class BulletinEditViewModel
    {
        #region Attribute

        /// <summary>
        /// 公告编号
        /// 判断是新增还是编辑
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "公告标题不能为空")]
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// 针对目标
        /// </summary>
        public EnumType.BulletinTarget Target { get; set; }

        /// <summary>
        /// 公告类型
        /// </summary>
        public EnumType.BulletinType Type { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required(ErrorMessage = "公告内容不能为空")]
        [StringLength(1000, ErrorMessage = "内容最多不能超过1000个字符")]
        public string Content { get; set; }

        #endregion
    }
}
