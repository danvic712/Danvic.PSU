//-----------------------------------------------------------------------
// <copyright file= "MajorClassEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/20 星期二 16:50:20
// Modified by:
// Description: Administrator-School-专业班级编辑信息页面 View Model
//-----------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PSU.Model.Areas.EnumType;

namespace PSU.Model.Areas.Administrator.School
{
    public class MajorClassEditViewModel
    {
        #region Attribute

        /// <summary>
        /// 专业班级编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        [Required(ErrorMessage = "班级名称不能为空")]
        [StringLength(20, ErrorMessage = "班级名称不能超过20个字符长度")]
        public string Name { get; set; }

        /// <summary>
        /// 专业代码
        /// </summary>
        [Required(ErrorMessage = "专业代码不能为空")]
        public string MajorCode { get; set; }

        /// <summary>
        /// 专业名称
        /// </summary>
        [Required(ErrorMessage = "所属专业不能为空")]
        [StringLength(50, ErrorMessage = "专业名称不能超过50个字符长度")]
        public string MajorName { get; set; }

        /// <summary>
        /// 所属院系编号
        /// </summary>
        [Required(ErrorMessage = "院系编号不能为空")]
        public string DepartmentId { get; set; }

        /// <summary>
        /// 所属院系名称
        /// </summary>
        [Required(ErrorMessage = "请选择所属院系信息")]
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
        [Required(ErrorMessage = "辅导员工号不能为空")]
        public string InstructorId { get; set; }

        /// <summary>
        /// 辅导员姓名
        /// </summary>
        [Required(ErrorMessage = "请选择班级辅导员信息")]
        public string InstructorName { get; set; }

        /// <summary>
        /// 级数
        /// </summary>
        public int SessionNum { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public Enable IsEnabled { get; set; }

        /// <summary>
        /// 部门下拉
        /// </summary>
        public List<DepartmentDropDown> DepartmentList { get; set; }

        /// <summary>
        /// 职工下拉
        /// </summary>
        public List<StaffDropDown> StaffList { get; set; }

        #endregion
    }

    /// <summary>
    /// 编辑页面部门下拉
    /// </summary>
    public class DepartmentDropDown
    {
        /// <summary>
        /// 部门编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// 编辑页面职工下拉
    /// </summary>
    public class StaffDropDown
    {
        /// <summary>
        /// 职工工号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 职工名称
        /// </summary>
        public string Name { get; set; }
    }
}
