//-----------------------------------------------------------------------
// <copyright file= "InformationViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:49:17
// Modified by:
// Description: Instructor-Newborn-新生列表页面 View Model
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Instructor.Newborn
{
    public class InformationViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 学生学号
        /// </summary>
        public string SId { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 专业班级名称
        /// </summary>
        public string SMajorClass { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 新生数据列表
        /// </summary>
        public List<StudentData> StudentList { get; set; }

        #endregion
    }

    /// <summary>
    /// 学生数据
    /// </summary>
    public class StudentData
    {
        #region Table

        /// <summary>
        /// 学号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }

        public string GenderStr => Gender ? "男" : "女";

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 生源地
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 所属院系
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 专业班级
        /// </summary>
        public string MajorClass { get; set; }

        #endregion
    }
}
