//-----------------------------------------------------------------------
// <copyright file= "IRegisterService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-06 22:57:49
// Modified by:
// Description: Student-Register-控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Model.Areas.Student;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Student
{
    public interface IRegisterService
    {
        #region Information-API

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<InformationViewModel> GetInformationAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertInformationAsync(InformationViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Booking-API

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<BookingViewModel> GetBookingAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertBookingAsync(BookingViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Goods-API

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<GoodsViewModel> GetGoodsAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertGoodsAsync(GoodsViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Dormitory-API

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<DormitoryViewModel> GetDormitoryAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertDormitoryAsync(DormitoryViewModel webModel, ApplicationDbContext context);

        #endregion
    }
}
