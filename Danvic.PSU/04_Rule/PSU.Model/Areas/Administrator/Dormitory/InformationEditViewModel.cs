//-----------------------------------------------------------------------
// <copyright file= "InformationEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/28 星期三 15:43:05
// Modified by:
// Description: Administrator-Dormitory-宿舍编辑信息页面 View Model
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
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
