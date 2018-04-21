//-----------------------------------------------------------------------
// <copyright file= "ServiceEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 20:42:35
// Modified by:
// Description: Administrator-Admission-迎新服务编辑页面 View Model 
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using static PSU.Model.Areas.EnumType;

namespace PSU.Model.Areas.Administrator.Admission
{
    public class ServiceEditViewModel
    {
        #region Attribute

        /// <summary>
        /// 迎新服务编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public Enable IsEnabled { get; set; }

        #endregion
    }
}
