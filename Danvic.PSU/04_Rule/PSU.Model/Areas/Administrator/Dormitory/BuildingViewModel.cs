//-----------------------------------------------------------------------
// <copyright file= "BuildingViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/23 星期五 16:54:55
// Modified by:
// Description: Administrator-Dormitory-宿舍楼信息页面 View Model
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Administrator.Dormitory
{
    public class BuildingViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 宿舍楼号
        /// </summary>
        public string SId { get; set; }

        /// <summary>
        /// 建筑类型
        /// </summary>
        public short SType { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public short SEnable { get; set; }

        #endregion

        #region Result

        public List<BuildingData> BuildingList { get; set; }

        #endregion
    }

    /// <summary>
    /// 数据列表展示
    /// </summary>
    public class BuildingData
    {
        #region Table

        /// <summary>
        /// 宿舍楼编号
        /// 此处使用string传递防止进制转换
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 宿舍楼名称
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
        public short Type { get; set; }

        public string TypeStr
        {
            get
            {
                string str = string.Empty;

                switch (Type)
                {
                    case 1:
                        str = "男生寝室";
                        break;
                    case 2:
                        str = "女生寝室";
                        break;
                    case 3:
                        str = "混合寝室";
                        break;
                }

                return str;
            }
        }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CreatedName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        public string IsEnabledStr => IsEnabled ? "启用" : "未启用";

        #endregion
    }
}
