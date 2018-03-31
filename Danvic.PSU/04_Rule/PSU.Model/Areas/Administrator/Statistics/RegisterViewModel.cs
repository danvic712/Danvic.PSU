//-----------------------------------------------------------------------
// <copyright file= "RegisterViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 21:43:59
// Modified by:
// Description: Administrator-Statistics-报名数据列表页面 View Model
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace PSU.Model.Areas.Administrator.Statistics
{
    public class RegisterViewModel : PagingViewModel
    {
        #region Search
        #endregion

        #region Result

        /// <summary>
        /// 新生报名数据列表
        /// </summary>
        public List<RegisterData> RegisterList { get; set; }

        #endregion
    }

    /// <summary>
    /// 新生报名数据
    /// </summary>
    public class RegisterData
    {
        #region Table

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        #endregion
    }
}
