//-----------------------------------------------------------------------
// <copyright file= "DepartmentViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/12 星期一 16:45:00
// Modified by:
// Description: Administrator-School-院系列表视图模型
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Administrator.School
{
    public class DepartmentViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 院系编号
        /// </summary>
        public string SId { get; set; }

        /// <summary>
        /// 院系名称
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string STel { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 院系列表
        /// </summary>
        public List<ReturnData> DepartmentList { get; set; }

        #endregion
    }

    /// <summary>
    /// 数据列表展示类
    /// </summary>
    public class ReturnData
    {
        #region Table

        /// <summary>
        /// 院系编号
        /// 此处使用string传递防止进制转换
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 院系名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 微信公众号
        /// </summary>
        public string Wechat { get; set; }

        /// <summary>
        /// 所在校区
        /// </summary>
        public string Campus { get; set; }

        #endregion
    };
}
