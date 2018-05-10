//-----------------------------------------------------------------------
// <copyright file= "ServiceDetailViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-10 22:12:29
// Modified by:
// Description: Student-Register-服务信息 View Model 
//-----------------------------------------------------------------------

namespace PSU.Model.Areas.Student
{
    public class ServiceDetailViewModel
    {
        #region Attribute

        /// <summary>
        /// 迎新服务编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 迎新项目描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 服务提供开始时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 服务提供结束时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 服务地点
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        #endregion
    }
}
