//-----------------------------------------------------------------------
// <copyright file= "IBasicService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/4 星期三 13:38:47
// Modified by:
// Description: Administrator-Basic控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Model.Areas.Administrator.Basic;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Administrator
{
    public interface IBasicService
    {
        #region Basic-Profile

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<ProfileViewModel> GetUserProfileAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateUserProfileAsync(ProfileViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Basic-Staff

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">教职工编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> DeleteStaffAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">教职工编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<StaffEditViewModel> GetStaffAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertStaffAsync(StaffEditViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<StaffViewModel> SearchStaffAsync(StaffViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateStaffAsync(StaffEditViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Basic-Student

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> DeleteStudentAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<StudentEditViewModel> GetStudentAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertStudentAsync(StudentEditViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<StudentViewModel> SearchStudentAsync(StudentViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateStudentAsync(StudentEditViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Basic-Region

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">地区编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> DeleteRegionAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">地区编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<RegionEditViewModel> GetRegionAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertRegionAsync(RegionEditViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<RegionViewModel> SearchRegionAsync(RegionViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateRegionAsync(RegionEditViewModel webModel, ApplicationDbContext context);

        #endregion
    }
}
