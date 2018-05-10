//-----------------------------------------------------------------------
// <copyright file= "GoodsDetailViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-10 22:13:21
// Modified by:
// Description: Student-Register-物品详细页面 View Model 
//-----------------------------------------------------------------------

namespace PSU.Model.Areas.Student
{
    public class GoodsDetailViewModel
    {
        #region Attribute

        /// <summary>
        /// 物品编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 物品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 物品描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 物品尺寸
        /// </summary>
        public string Size { get; set; }

        #endregion
    }
}
