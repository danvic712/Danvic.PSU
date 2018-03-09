//-----------------------------------------------------------------------
// <copyright file= "PagingViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/9 星期五 9:12:23
// Modified by:
// Description: 列表分页字段基类
//-----------------------------------------------------------------------

namespace PSU.Model
{
    public class PagingViewModel
    {
        #region Page

        /// <summary>
        /// 每页显示条数
        /// Linq分页查询时Take的参数
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// 每页开始的记录序号
        /// Linq分页查询时Skip的参数
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 当前页
        /// 返回前端显示当前页码
        /// </summary>
        public int Page { get; set; }

        #endregion
    }
}
