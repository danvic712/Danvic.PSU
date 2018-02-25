//-----------------------------------------------------------------------
// <copyright file= "BunkInfo.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:43:40
// Modified by:
// Description: 新生选择床铺信息表
//-----------------------------------------------------------------------
using PSU.Entity.Basic;
using PSU.Entity.Dormitory;
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSU.Entity.SignUp
{
    public class BunkInfo
    {
        #region Constructed Function

        public BunkInfo()
        {
            BunkInfoOID = Guid.NewGuid();
            Id = TimeUtility.GetTimespans();
            ChosenTime = DateTime.Now;
        }

        #endregion

        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid BunkInfoOID { get; set; }

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
        /// 寝室楼名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string BName { get; set; }

        /// <summary>
        /// 寝室所在楼层数
        /// </summary>
        [Required]
        public int Floor { get; set; }

        /// <summary>
        /// 寝室名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string DName { get; set; }

        /// <summary>
        /// 床铺号
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string BNum { get; set; }

        /// <summary>
        /// 选择时间
        /// </summary>
        public DateTime ChosenTime { get; set; }

        #endregion

        #region Foreign Key

        /// <summary>
        /// 学生主键
        /// </summary>
        public Guid StudentFK { get; set; }

        /// <summary>
        /// 寝室楼主键
        /// </summary>
        public Guid BuildingFK { get; set; }

        /// <summary>
        /// 寝室主键
        /// </summary>
        public Guid DormFK { get; set; }

        [ForeignKey("StudentFK")]
        public virtual Student Student { get; set; }

        [ForeignKey("BuildingFK")]
        public virtual Building Building { get; set; }

        [ForeignKey("DormFK")]
        public virtual Dorm Dorm { get; set; }

        #endregion
    }
}
