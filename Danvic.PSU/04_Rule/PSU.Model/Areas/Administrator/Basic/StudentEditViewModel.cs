//-----------------------------------------------------------------------
// <copyright file= "StudentEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 22:07:05
// Modified by:
// Description: Administrator-Basic-学生账户编辑页面 View Model 
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using static PSU.Model.Areas.EnumType;

namespace PSU.Model.Areas.Administrator.Basic
{
    public class StudentEditViewModel
    {
        #region Attribute

        /// <summary>
        /// 学生学号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public Enable IsEnabled { get; set; }

        #endregion
    }
}
