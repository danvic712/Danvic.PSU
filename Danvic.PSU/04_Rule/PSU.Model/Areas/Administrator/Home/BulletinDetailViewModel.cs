//-----------------------------------------------------------------------
// <copyright file= "BulletinDetailViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-10 21:07:31
// Modified by:
// Description:Administrator-Home-公告信息详情页面 
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Administrator.Home
{
    public class BulletinDetailViewModel
    {
        #region Bulletin Information

        /// <summary>
        /// 公告标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 公告内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public string CreatedOn { get; set; }

        #endregion

        #region Operate Information

        /// <summary>
        /// 操作信息列表
        /// </summary>
        public List<Operate> OperateList { get; set; }

        #endregion
    }

    public class Operate
    {
        /// <summary>
        /// 创建/修改用户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// 操作内容
        /// </summary>
        public string Operating { get; set; }
    };
}
