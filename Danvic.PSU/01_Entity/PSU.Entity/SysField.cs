//-----------------------------------------------------------------------
// <copyright file= "SysField.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/12 星期一 8:49:59
// Modified by:
// Description: 系统字段
//-----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity
{
    public class SysField
    {
        #region Attribute

        /// <summary>
        /// 创建人主键
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 创建人IP地址
        /// </summary>
        public string CreatedIp { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        [MaxLength(50)]
        public string CreatedName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改人主键
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// 修改人IP地址
        /// </summary>
        public string ModifiedIp { get; set; }

        /// <summary>
        /// 修改人姓名
        /// </summary>
        [MaxLength(50)]
        public string ModifiedName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiedOn { get; set; }

        #endregion
    }
}
