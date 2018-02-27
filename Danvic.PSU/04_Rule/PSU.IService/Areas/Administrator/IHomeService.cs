//-----------------------------------------------------------------------
// <copyright file= "IHomeService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/27 星期二 15:04:25
// Modified by:
// Description: Administrator-Home控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.Model.Areas.Administrator.Home;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Administrator
{
    public interface IHomeService
    {
        #region Service

        /// <summary>
        /// 页面加载初始化
        /// </summary>
        /// <returns></returns>
        Task<IndexViewModel> InitPageAsync();

        #endregion
    }
}
