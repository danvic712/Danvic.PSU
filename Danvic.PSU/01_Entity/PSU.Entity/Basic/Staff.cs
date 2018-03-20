//-----------------------------------------------------------------------
// <copyright file= "Staff.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-25 15:13:09
// Modified by:
// Description: 教职工信息表
//-----------------------------------------------------------------------
using PSU.Entity.Identity;
using PSU.Entity.School;
using PSU.Utility.System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSU.Entity.Basic
{
    public class Staff : SysField
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string StaffOID { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        [MaxLength(200)]
        public string Address { get; set; }

        /// <summary>
        /// 所属院系、部门
        /// </summary>
        [MaxLength(50)]
        public string Department { get; set; }

        /// <summary>
        /// 是否为学校负责人
        /// </summary>
        public bool IsSupervisor { get; set; }

        /// <summary>
        /// 是否为院系负责人
        /// </summary>
        public bool IsMaster { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion

        #region Foreign Key

        /// <summary>
        /// 账号主键
        /// </summary>
        public string IdentityUserFK { get; set; }

        /// <summary>
        /// 院系主键
        /// </summary>
        public string DepartmentFK { get; set; }

        [ForeignKey("IdentityUserFK")]
        public virtual AppUser IdentityUser { get; set; }

        [ForeignKey("DepartmentFK")]
        public virtual Department UDepartment { get; set; }

        #endregion
    }
}
