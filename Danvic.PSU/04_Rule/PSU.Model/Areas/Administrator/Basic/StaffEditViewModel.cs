//-----------------------------------------------------------------------
// <copyright file= "StaffEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 22:05:46
// Modified by:
// Description: Administrator-Basic-职工账户编辑页面 View Model 
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using static PSU.Model.Areas.EnumType;

namespace PSU.Model.Areas.Administrator.Basic
{
    public class StaffEditViewModel
    {
        #region Attribute

        /// <summary>
        /// 职工工号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public Enable IsEnabled { get; set; }

        #endregion
    }
}
