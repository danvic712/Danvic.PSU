//-----------------------------------------------------------------------
// <copyright file= "IUserService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-06 22:47:12
// Modified by:
// Description: Student-User-控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Model.Areas.Student;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Student
{
    public interface IUserService
    {
        #region User-Profile

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<ProfileViewModel> GetStudentAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateStudentAsync(ProfileViewModel webModel, ApplicationDbContext context);

        #endregion
    }
}
