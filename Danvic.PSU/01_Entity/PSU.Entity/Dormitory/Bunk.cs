//-----------------------------------------------------------------------
// <copyright file= "Bunk.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:40:58
// Modified by:
// Description: 床位信息表
//-----------------------------------------------------------------------
using PSU.Entity.Basic;
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSU.Entity.Dormitory
{
    public class Bunk : SysField
    {
        #region Constructed Function

        public Bunk()
        {
            BunkOID = Guid.NewGuid();
            Id = TimeUtility.GetTimespans();
            CreatedOn = DateTime.Now;
        }

        #endregion

        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid BunkOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// 所属寝室名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string DormName { get; set; }

        /// <summary>
        /// 床铺号
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Number { get; set; }

        /// <summary>
        /// 床铺选择状态
        /// 1:已选;2:未选;3:锁定中
        /// </summary>
        [Required]
        public short Status { get; set; }

        /// <summary>
        /// 选中人姓名
        /// </summary>
        [MaxLength(10)]
        public string SelectedName { get; set; }

        /// <summary>
        /// 选中人学号
        /// </summary>
        public int SelectedId { get; set; }

        /// <summary>
        /// 选择时间
        /// </summary>
        public DateTime SelectedTime { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion

        #region Foreign Key

        /// <summary>
        /// 所属寝室主键
        /// </summary>
        public Guid DormFK { get; set; }

        /// <summary>
        /// 选择学生主键
        /// </summary>
        public Guid StudentFK { get; set; }

        [ForeignKey("DormFK")]
        public virtual Dorm Dorm { get; set; }

        [ForeignKey("StudentFK")]
        public virtual Student Student { get; set; }

        #endregion
    }
}
