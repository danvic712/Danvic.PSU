//-----------------------------------------------------------------------
// <copyright file= "DormitoryViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 21:46:28
// Modified by:
// Description: Administrator-Statistics-宿舍数据列表页面 View Model
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Administrator.Statistics
{
    public class DormitoryViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string SStudent { get; set; }

        /// <summary>
        /// 宿舍名称
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 宿舍楼
        /// </summary>
        public string SBuilding { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 宿舍选择数据列表
        /// </summary>
        public List<DormitoryData> DormitoryList { get; set; }

        #endregion
    }

    /// <summary>
    /// 寝室数据
    /// </summary>
    public class DormitoryData
    {
        #region Table

        /// <summary>
        /// 学生学号
        /// </summary>
        public string StudentId { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 专业班级
        /// </summary>
        public string MajorClass { get; set; }

        /// <summary>
        /// 宿舍名称
        /// </summary>
        public string Dorm { get; set; }

        /// <summary>
        /// 所在楼层
        /// </summary>
        public int Floor { get; set; }

        public string FloorStr => Floor + "层";

        /// <summary>
        /// 所属寝室楼
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        /// 选择时间
        /// </summary>
        public string DateTime { get; set; }

        #endregion
    }
}
