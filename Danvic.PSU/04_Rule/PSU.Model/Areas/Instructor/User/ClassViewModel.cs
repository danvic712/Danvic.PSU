//-----------------------------------------------------------------------
// <copyright file= "ClassViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:46:46
// Modified by:
// Description: Instructor-Classes-列表 View Model
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Instructor.User
{
    public class ClassViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 班级名称
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 专业名称
        /// </summary>
        public string SMajor { get; set; }

        /// <summary>
        /// 班级QQ
        /// </summary>
        public string SQQ { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 我的班级列表
        /// </summary>
        public List<ClassData> ClassList { get; set; }

        #endregion
    }

    /// <summary>
    /// 我的班级列表显示项
    /// </summary>
    public class ClassData
    {
        #region Table

        /// <summary>
        /// 班级编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 级数
        /// </summary>
        public string SessionNum { get; set; }

        /// <summary>
        /// 所属院系
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 专业代码
        /// </summary>
        public int MajorCode { get; set; }

        /// <summary>
        /// 专业名称
        /// </summary>
        public string MajorName { get; set; }

        /// <summary>
        /// 班级QQ
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 班级微信
        /// </summary>
        public string Wechat { get; set; }

        #endregion
    }
}
