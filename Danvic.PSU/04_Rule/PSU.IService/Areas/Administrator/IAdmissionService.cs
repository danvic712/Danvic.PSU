//-----------------------------------------------------------------------
// <copyright file= "IAdmissionService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 20:43:57
// Modified by:
// Description: Administrator-Admission控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Model.Areas.Administrator.Admission;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Administrator
{
    public interface IAdmissionService
    {
        #region Admission-Service

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> DeleteServiceAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<ServiceEditViewModel> GetServiceAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertServiceAsync(ServiceEditViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<ServiceViewModel> SearchServiceAsync(ServiceViewModel webModel, ApplicationDbContext context);
        
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateServiceAsync(ServiceEditViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Admission-Goods

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> DeleteGoodsAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<GoodsEditViewModel> GetGoodsAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertGoodsAsync(GoodsEditViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<GoodsViewModel> SearchGoodsAsync(GoodsViewModel webModel, ApplicationDbContext context);
        
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateGoodsAsync(GoodsEditViewModel webModel, ApplicationDbContext context);

        #endregion

        #region Admission-Question

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id">问题编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<QuestionReplyViewModel> GetQuestionAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">问题编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<QuestionReplyViewModel> ReplyQuestionAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<QuestionViewModel> SearchQuestionAsync(QuestionViewModel webModel, ApplicationDbContext context);

        #endregion
    }
}
