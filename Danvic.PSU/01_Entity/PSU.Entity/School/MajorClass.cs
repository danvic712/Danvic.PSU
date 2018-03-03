//-----------------------------------------------------------------------
// <copyright file= "MajorClass.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:43:05
// Modified by:
// Description: 专业班级表
//-----------------------------------------------------------------------
using PSU.Entity.Basic;
using PSU.Entity.Identity;
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSU.Entity.School
{
    public class MajorClass : SysField
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string MajorClassOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 班级名称
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 专业代码
        /// </summary>
        [Required]
        public int MajorCode { get; set; }

        /// <summary>
        /// 专业名称
        /// </summary>
        [MaxLength(50)]
        public string MajorName { get; set; }

        /// <summary>
        /// 所属院系名称
        /// </summary>
        [MaxLength(20)]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 所在校区名称
        /// </summary>
        [MaxLength(20)]
        public string CampusName { get; set; }

        /// <summary>
        /// 班级微信号
        /// </summary>
        [MaxLength(20)]
        public string Wechat { get; set; }

        /// <summary>
        /// 班级QQ
        /// </summary>
        [MaxLength(20)]
        public string QQ { get; set; }

        /// <summary>
        /// 辅导员工号
        /// </summary>
        [Required]
        public long InstructorId { get; set; }

        /// <summary>
        /// 辅导员姓名
        /// </summary>
        [MaxLength(20)]
        public string InstructorName { get; set; }

        /// <summary>
        /// 级数
        /// </summary>
        public int SessionNum { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion

        #region Foreign Key

        /// <summary>
        /// 专业主键
        /// </summary>
        public string MajorFK { get; set; }

        /// <summary>
        /// 辅导员主键
        /// </summary>
        public string InstructorFK { get; set; }

        [ForeignKey("MajorFK")]
        public virtual Major Major { get; set; }

        [ForeignKey("InstructorFK")]
        public virtual Staff Instructor { get; set; }

        #endregion
    }
}
