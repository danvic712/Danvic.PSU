//-----------------------------------------------------------------------
// <copyright file= "ClassEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:47:11
// Modified by:
// Description: Instructor-User-专业班级编辑信息页面 View Model
//-----------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
using static PSU.Model.Areas.EnumType;

namespace PSU.Model.Areas.Instructor.User
{
    public class ClassEditViewModel
    {
        #region Attribute

        /// <summary>
        /// 专业班级编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 专业代码
        /// </summary>
        public string MajorCode { get; set; }

        /// <summary>
        /// 专业名称
        /// </summary>
        public string MajorName { get; set; }

        /// <summary>
        /// 所属院系编号
        /// </summary>
        public string DepartmentId { get; set; }

        /// <summary>
        /// 所属院系名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 班级微信号
        /// </summary>
        [StringLength(20, ErrorMessage = "班级微信号不能超过20个字符长度")]
        public string Wechat { get; set; }

        /// <summary>
        /// 班级QQ
        /// </summary>
        [StringLength(20, ErrorMessage = "班级QQ不能超过20个字符长度")]
        public string QQ { get; set; }

        /// <summary>
        /// 辅导员工号
        /// </summary>
        public string InstructorId { get; set; }

        /// <summary>
        /// 辅导员姓名
        /// </summary>
        public string InstructorName { get; set; }

        /// <summary>
        /// 级数
        /// </summary>
        public string SessionNum { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public Enable IsEnabled { get; set; }

        #endregion
    }
}
