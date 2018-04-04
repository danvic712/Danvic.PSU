//-----------------------------------------------------------------------
// <copyright file= "StaffViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 22:00:23
// Modified by:
// Description: Administrator-Basic-职工账户列表页面 View Model
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Administrator.Basic
{
    public class StaffViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 职工工号
        /// </summary>
        public string SId { get; set; }

        /// <summary>
        /// 职工姓名
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public string SDepartment { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 职工账户数据列表
        /// </summary>
        public List<StaffData> StaffList { get; set; }

        #endregion
    }

    /// <summary>
    /// 职工账户信息
    /// </summary>
    public class StaffData
    {
        #region Table

        /// <summary>
        /// 工号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }

        public string GenderStr => Gender ? "男" : "女";

        /// <summary>
        /// 登录账户名
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public string Department { get; set; }

        #endregion
    }
}
