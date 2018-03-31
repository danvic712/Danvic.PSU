//-----------------------------------------------------------------------
// <copyright file= "BuildingEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/27 星期二 11:06:03
// Modified by:
// Description: Administrator-Dormitory-宿舍楼编辑信息页面 View Model
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static PSU.Model.Areas.EnumType;

namespace PSU.Model.Areas.Administrator.Dormitory
{
    public class BuildingEditViewModel
    {
        #region Attribute

        /// <summary>
        /// 宿舍楼编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 寝室楼名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 总楼层
        /// </summary>
        public short Floor { get; set; }

        /// <summary>
        /// 寝室楼类型
        /// 1:male;2:female;3:remix
        /// </summary>
        public BuildingType Type { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public Enable IsEnabled { get; set; }

        #endregion
    }
}
