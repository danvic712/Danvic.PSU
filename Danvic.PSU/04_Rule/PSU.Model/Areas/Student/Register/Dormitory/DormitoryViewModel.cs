//-----------------------------------------------------------------------
// <copyright file= "DormitoryViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-10 15:47:30
// Modified by:
// Description: Student-Register-寝室选择页面 View Model 
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Student
{
    public class DormitoryViewModel
    {
        /// <summary>
        /// 是否选择
        /// </summary>
        public bool IsChosen { get; set; }

        /// <summary>
        /// 寝室选择信息
        /// </summary>
        public DormitoryInfo DormitoryInfo { get; set; }

        /// <summary>
        /// 数据列表
        /// </summary>
        public List<InformationData> InformationList { get; set; }
    }

    /// <summary>
    /// 数据列表展示
    /// </summary>
    public class InformationData
    {
        #region Table

        /// <summary>
        /// 宿舍编号
        /// 此处使用string传递防止进制转换
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 宿舍名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 宿舍楼名称
        /// </summary>
        public string BuildingName { get; set; }

        /// <summary>
        /// 楼层
        /// </summary>
        public short Floor { get; set; }

        public string FloorStr => Floor + "楼";

        /// <summary>
        /// 寝室类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 可容纳人数
        /// </summary>
        public short Count { get; set; }

        public string CountStr => Count + "人";

        /// <summary>
        /// 已选择人数
        /// </summary>
        public short SelectedCount { get; set; }

        public string SelectedCountStr => SelectedCount + "人";

        #endregion
    }

    /// <summary>
    /// 寝室选择信息
    /// </summary>
    public class DormitoryInfo
    {
        /// <summary>
        /// 寝室选择编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 宿舍名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 宿舍楼名称
        /// </summary>
        public string BuildingName { get; set; }

        /// <summary>
        /// 楼层
        /// </summary>
        public short Floor { get; set; }

        public string FloorStr => Floor + "楼";

        /// <summary>
        /// 寝室类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 选择时间
        /// </summary>
        public string DateTime { get; set; }
    }
}
