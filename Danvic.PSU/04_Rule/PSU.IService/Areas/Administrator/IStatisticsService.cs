//-----------------------------------------------------------------------
// <copyright file= "IStatisticsService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-04-02 21:06:44
// Modified by:
// Description: Administrator-Statistics控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Model.Areas.Administrator.Statistics;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Administrator
{
    public interface IStatisticsService
    {
        #region Statistics-Register

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<RegisterViewModel> SearchRegisterAsync(RegisterViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Statistics-Goods

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<GoodsViewModel> SearchStudentAsync(GoodsViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Statistics-Dormitory

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<DormitoryViewModel> SearchDormitoryAsync(DormitoryViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Statistics-Book

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<BookViewModel> SearchBookAsync(BookViewModel webModel, ApplicationDbContext context);

        #endregion
    }
}
