//-----------------------------------------------------------------------
// <copyright file= "InformationViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/28 星期三 11:14:04
// Modified by:
// Description: Administrator-Dormitory-宿舍信息页面 View Model
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Administrator.Dormitory
{
    public class InformationViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 宿舍名称
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 宿舍类型
        /// </summary>
        public short SType { get; set; }

        /// <summary>
        /// 所在楼层
        /// </summary>
        public short SFloor { get; set; }

        #endregion

        #region Result

        public List<InformationData> InformationList { get; set; }

        #endregion
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
        /// 1:4人间;2:6人间;3:8人间;4:套房;5:其它
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
                        str = "4人间";
                        break;
                    case 2:
                        str = "6人间";
                        break;
                    case 3:
                        str = "8人间";
                        break;
                    case 4:
                        str = "套房";
                        break;
                    case 5:
                        str = "其它";
                        break;
                }

                return str;
            }
        }

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

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        public string IsEnabledStr => IsEnabled ? "启用" : "未启用";

        #endregion
    }
}
