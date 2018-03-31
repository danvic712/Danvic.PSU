//-----------------------------------------------------------------------
// <copyright file= "BookViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 21:55:25
// Modified by:
// Description: Administrator-Statistics-服务预定列表页面 View Model
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace PSU.Model.Areas.Administrator.Statistics
{
    public class BookViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string SStudent { get; set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string SName { get; set; }


        #endregion

        #region Result

        /// <summary>
        /// 迎新服务选择数据列表
        /// </summary>
        public List<BookData> BookList { get; set; }

        #endregion
    }

    /// <summary>
    /// 服务预定信息
    /// </summary>
    public class BookData
    {
        #region Table

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }



        #endregion
    }
}
