//-----------------------------------------------------------------------
// <copyright file= "IHomeService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/27 星期二 15:04:25
// Modified by:
// Description: Administrator-Home控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Model.Areas.Administrator.Home;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Administrator
{
    public interface IHomeService
    {
        #region Home-Index

        /// <summary>
        /// 页面加载初始化
        /// </summary>
        /// <returns></returns>
        Task<IndexViewModel> InitIndexPageAsync();

        #endregion

        #region Home-Bulletin

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <returns></returns>
        Task<BulletinViewModel> SearchBulletinAsync(BulletinViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <returns></returns>
        Task<BulletinEditViewModel> InsertBulletinAsync(BulletinEditViewModel webModel, ApplicationDbContext context);

        #endregion
    }
}
