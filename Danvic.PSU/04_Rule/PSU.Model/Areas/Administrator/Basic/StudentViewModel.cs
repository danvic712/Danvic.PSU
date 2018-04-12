//-----------------------------------------------------------------------
// <copyright file= "StudentViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 22:06:54
// Modified by:
// Description: Administrator-Basic-学生账户列表页面 View Model
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Administrator.Basic
{
    public class StudentViewModel : PagingViewModel
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
        /// 所属班级
        /// </summary>
        public string SMajorClass { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 学生账户数据列表
        /// </summary>
        public List<StudentData> StudentList { get; set; }

        #endregion
    }

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
        /// 登录账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 所属院系
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 专业班级名称
        /// </summary>
        public string MajorClass { get; set; }

        #endregion
    }
}
