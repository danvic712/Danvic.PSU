//-----------------------------------------------------------------------
// <copyright file= "InformationEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/28 星期三 15:43:05
// Modified by:
// Description: Administrator-Dormitory-宿舍编辑信息页面 View Model
//-----------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PSU.Model.Areas.EnumType;

namespace PSU.Model.Areas.Administrator.Dormitory
{
    public class InformationEditViewModel
    {
        #region Attribute

        /// <summary>
        /// 宿舍编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 宿舍号
        /// </summary>
        [Required(ErrorMessage = "宿舍号不能为空")]
        [StringLength(20, ErrorMessage = "宿舍号不能超过20个字符长度")]
        public string Name { get; set; }

        /// <summary>
        /// 寝室楼编号
        /// </summary>
        [Required(ErrorMessage = "寝室楼编号不能为空")]
        public string BuildingId { get; set; }

        /// <summary>
        /// 楼层
        /// </summary>
        [Required]
        public short Floor { get; set; }

        /// <summary>
        /// 寝室类型编号
        /// </summary>
        [Required(ErrorMessage = "寝室类型编号不能为空")]
        public string BunkId { get; set; }

        /// <summary>
        /// 可容纳人数
        /// </summary>
        [Required(ErrorMessage = "可容纳人数不能为空")]
        public short Count { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public Enable IsEnabled { get; set; }

        /// <summary>
        /// 宿舍楼下拉列表
        /// </summary>
        public List<BuildingDropDown> BuildingList { get; set; }

        /// <summary>
        /// 宿舍类型下拉
        /// </summary>
        public List<BunkDropDown> BunkList { get; set; }

        #endregion
    }

    /// <summary>
    /// 宿舍楼下拉
    /// </summary>
    public class BuildingDropDown
    {
        /// <summary>
        /// 宿舍楼编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 宿舍楼名称
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// 宿舍类型下拉
    /// </summary>
    public class BunkDropDown
    {
        /// <summary>
        /// 宿舍类型编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 宿舍类型名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 可容纳人数
        /// </summary>
        public int Count { get; set; }
    }
}
