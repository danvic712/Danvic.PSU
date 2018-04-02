//-----------------------------------------------------------------------
// <copyright file= "RegisterViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 21:43:59
// Modified by:
// Description: Administrator-Statistics-报名数据列表页面 View Model
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace PSU.Model.Areas.Administrator.Statistics
{
    public class RegisterViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 专业班级
        /// </summary>
        public string SMajorClass { get; set; }

        /// <summary>
        /// 报名状态
        /// </summary>
        public short SStatus { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 新生报名数据列表
        /// </summary>
        public List<RegisterData> RegisterList { get; set; }

        #endregion
    }

    /// <summary>
    /// 新生报名数据
    /// </summary>
    public class RegisterData
    {
        #region Table

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        public string StudentId { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属院系
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 专业班级
        /// </summary>
        public string MajorClass { get; set; }

        /// <summary>
        /// 来校方式
        /// 1:火车;2:客车;3:飞机;4:自驾;5:客船;6:其它
        /// </summary>
        public short Way { get; set; }

        /// <summary>
        /// 预计到达时间
        /// </summary>
        public DateTime ArriveTime { get; set; }

        /// <summary>
        /// 档案是否快递
        /// </summary>
        public bool IsExpress { get; set; }

        public string IsExpressStr => IsExpress ? "快递" : "未快递";

        /// <summary>
        /// 快递单号
        /// </summary>
        public string Express { get; set; }

        #endregion
    }
}
