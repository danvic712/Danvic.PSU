//-----------------------------------------------------------------------
// <copyright file= "Region.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:39:43
// Modified by:
// Description: 地区信息表
//-----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.Basic
{
    public class Region
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string RegionOID { get; set; }

        #endregion
    }
}
