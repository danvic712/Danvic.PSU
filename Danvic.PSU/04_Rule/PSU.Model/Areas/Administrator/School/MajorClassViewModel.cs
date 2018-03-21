//-----------------------------------------------------------------------
// <copyright file= "MajorClassViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/20 星期二 16:49:11
// Modified by:
// Description: Administrator-School-专业班级列表视图模型
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Administrator.School
{
    public class MajorClassViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 班级名称
        /// </summary>
        public string SClassName { get; set; }

        /// <summary>
        /// 专业名称
        /// </summary>
        public string SMajorName { get; set; }

        /// <summary>
        /// 导员姓名
        /// </summary>
        public string SInstructorName { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 专业列表
        /// </summary>
        public List<MajorClassData> MajorClassList { get; set; }

        #endregion
    }

    /// <summary>
    /// 数据列表展示类
    /// </summary>
    public class MajorClassData
    {
        /// <summary>
        /// 专业班级编号
        /// 此处使用string传递防止进制转换
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 专业班级名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 专业代码
        /// </summary>
        public int MajorCode { get; set; }

        /// <summary>
        /// 专业名称
        /// </summary>
        public string MajorName { get; set; }

        /// <summary>
        /// 级数
        /// </summary>
        public string SessionNum { get; set; }

        /// <summary>
        /// 辅导员姓名
        /// </summary>
        public string InstructorName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        public string IsEnabledStr => IsEnabled ? "启用" : "未启用";
    }
}
