//-----------------------------------------------------------------------
// <copyright file= "ISchoolService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-11 20:08:25
// Modified by:
// Description: Administrator-School控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Model.Areas.Administrator.School;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Administrator
{
    public interface ISchoolService
    {
        #region School-Department

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">部门/院系编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> DeleteDepartmentAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">部门/院系编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<DepartmentEditViewModel> GetDepartmentAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertDepartmentAsync(DepartmentEditViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<DepartmentViewModel> SearchDepartmentAsync(DepartmentViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateDepartmentAsync(DepartmentEditViewModel webModel, ApplicationDbContext context);

        #endregion

        #region School-Major Class

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> DeleteMajorClassAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 获取下拉列表
        /// </summary>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<MajorClassEditViewModel> GetDropDownListAsync(ApplicationDbContext context);

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<MajorClassEditViewModel> GetMajorClassAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertMajorClassAsync(MajorClassEditViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<MajorClassViewModel> SearchMajorClassAsync(MajorClassViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateMajorClassAsync(MajorClassEditViewModel webModel, ApplicationDbContext context);

        #endregion
    }
}
