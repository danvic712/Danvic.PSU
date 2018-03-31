//-----------------------------------------------------------------------
// <copyright file= "IDormitoryService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/23 星期五 16:52:44
// Modified by:
// Description: Administrator-Dormitory控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Model.Areas.Administrator.Dormitory;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Administrator
{
    public interface IDormitoryService
    {
        #region Dormitory-Building

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<BuildingViewModel> SearchBuildingAsync(BuildingViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertBuildingAsync(BuildingEditViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<BuildingEditViewModel> GetBuildingAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> DeleteBuildingAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateBuildingAsync(BuildingEditViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Dormitory-Bunk

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<BunkViewModel> SearchBunkAsync(BunkViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertBunkAsync(BunkEditViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<BunkEditViewModel> GetBunkAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> DeleteBunkAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateBunkAsync(BunkEditViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Dormitory-Information

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<InformationViewModel> SearchInformationAsync(InformationViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertInformationAsync(InformationEditViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<InformationEditViewModel> GetInformationAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> DeleteInformationAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateInformationAsync(InformationEditViewModel webModel, ApplicationDbContext context);

        #endregion
    }
}
