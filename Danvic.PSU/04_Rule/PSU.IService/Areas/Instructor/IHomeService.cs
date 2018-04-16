//-----------------------------------------------------------------------
// <copyright file= "IHomeService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:19:13
// Modified by:
// Description: Instructor-Home控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Model.Areas.Instructor.Home;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Instructor
{
    public interface IHomeService
    {
        #region Home-Index

        /// <summary>
        /// 页面加载初始化
        /// </summary>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<IndexViewModel> InitIndexPageAsync(ApplicationDbContext context);

        /// <summary>
        /// 获取折线图数据
        /// </summary>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<List<LineChartData>> InitLineChartAsync(ApplicationDbContext context);

        /// <summary>
        /// 获取折线图数据
        /// </summary>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<List<PieData>> InitPieChartAsync(ApplicationDbContext context);

        #endregion
    }
}
