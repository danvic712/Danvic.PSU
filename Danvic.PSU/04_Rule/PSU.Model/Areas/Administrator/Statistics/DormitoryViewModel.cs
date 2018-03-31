//-----------------------------------------------------------------------
// <copyright file= "DormitoryViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 21:46:28
// Modified by:
// Description: Administrator-Statistics-宿舍数据列表页面 View Model
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

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
        /// 编号
        /// </summary>
        public string Id { get; set; }



        #endregion
    }
}
