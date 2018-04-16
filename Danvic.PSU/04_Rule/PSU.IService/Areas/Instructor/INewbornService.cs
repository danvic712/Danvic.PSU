//-----------------------------------------------------------------------
// <copyright file= "INewbornService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:22:21
// Modified by:
// Description: Instructor-Newborn控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Model.Areas.Instructor.Newborn;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Instructor
{
    public interface INewbornService
    {
        #region Newborn-Register

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<RegisterViewModel> SearchRegisterAsync(RegisterViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Newborn-Dormitory

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<DormitoryViewModel> SearchDormitoryAsync(DormitoryViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Newborn-Information

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<InformationViewModel> SearchStudentAsync(InformationViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<InformationDetailViewModel> GetStudentAsync(long id, ApplicationDbContext context);

        #endregion
    }
}
