//-----------------------------------------------------------------------
// <copyright file= "IUserService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:22:58
// Modified by:
// Description: Instructor-User控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Model.Areas.Instructor.User;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Instructor
{
    public interface IUserService
    {
        #region User-Classes

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<ClassEditViewModel> GetClassAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<ClassViewModel> SearchClassAsync(ClassViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateClassAsync(ClassEditViewModel webModel, ApplicationDbContext context);

        #endregion

        #region User-Profile

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<ProfileViewModel> GetProfileAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateProfileAsync(ProfileViewModel webModel, ApplicationDbContext context);

        #endregion
    }
}
