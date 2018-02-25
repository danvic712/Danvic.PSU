//-----------------------------------------------------------------------
// <copyright file= "TuitionInfo.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:44:57
// Modified by:
// Description: 新生缴费金额信息表
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.SignUp
{
    public class TuitionInfo
    {
        #region Constructed Function

        public TuitionInfo()
        {
            TuitionInfoOID = Guid.NewGuid();
            Id = TimeUtility.GetTimespans();
        }

        #endregion

        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid TuitionInfoOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string SName { get; set; }

        /// <summary>
        /// 学生学号
        /// </summary>
        [Required]
        public int SId { get; set; }

        /// <summary>
        /// 已付款
        /// </summary>
        public decimal PaidAccount { get; set; }

        /// <summary>
        /// 凭证
        /// </summary>
        public string Proof { get; set; }

        /// <summary>
        /// 是否贷款
        /// </summary>
        public bool IsLoan { get; set; }

        #endregion
    }
}
