//-----------------------------------------------------------------------
// <copyright file= "BunkEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 16:08:58
// Modified by:
// Description: Administrator-Dormitory-宿舍类型编辑信息页面 View Model
//-----------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
using static PSU.Model.Areas.EnumType;

namespace PSU.Model.Areas.Administrator.Dormitory
{
    public class BunkEditViewModel
    {
        #region Attribute

        /// <summary>
        /// 宿舍类型编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 寝室类型名称
        /// </summary>
        [Required(ErrorMessage = "请输入寝室类型名称")]
        [StringLength(20, ErrorMessage = "寝室类型名称不能超过20个字符长度")]
        public string Name { get; set; }

        /// <summary>
        /// 可容纳人数
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 朝向
        /// </summary>
        public BunkToward Toward { get; set; }

        /// <summary>
        /// 类型示意图地址
        /// </summary>
        public string ImageSrc { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public Enable IsEnabled { get; set; }

        #endregion
    }
}
