//-----------------------------------------------------------------------
// <copyright file= "StudentViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 21:16:12
// Modified by:
// Description: Administrator-Statistics-新生数据列表页面 View Model
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace PSU.Model.Areas.Administrator.Statistics
{
    public class StudentViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 专业方向
        /// </summary>
        public string SMajor { get; set; }

        /// <summary>
        /// 报名状态
        /// </summary>
        public short SStatus { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 新生数据列表
        /// </summary>
        public List<StudentData> StudentList { get; set; }

        #endregion
    }

    /// <summary>
    /// 新生报名数据
    /// </summary>
    public class StudentData
    {
        #region Table

        /// <summary>
        /// 学号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }

        public string GenderStr => Gender ? "男" : "女";

        /// <summary>
        /// 所属院系
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 专业方向
        /// </summary>
        public string Major { get; set; }

        /// <summary>
        /// 专业班级
        /// </summary>
        public string MajorClass { get; set; }

        /// <summary>
        /// 报名状态
        /// </summary>
        public bool Status { get; set; }

        public string StatusStr => Status ? "已完成" : "未完成";

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
