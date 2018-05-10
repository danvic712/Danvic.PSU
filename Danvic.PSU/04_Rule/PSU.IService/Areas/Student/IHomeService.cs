//-----------------------------------------------------------------------
// <copyright file= "IHomeService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:57:53
// Modified by:
// Description: Student-Home-控制器邻域功能接口
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Model.Areas.Student;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Student
{
    public interface IHomeService
    {
        #region Home-Index

        /// <summary>
        /// 页面加载初始化
        /// </summary>
        /// <param name="id">当前用户编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<IndexViewModel> InitIndexPageAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 学生提问
        /// </summary>
        /// <param name="content">提问内容</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<bool> AskQuestionAsync(string content, ApplicationDbContext context);

        #endregion

        #region Home-Bulletin

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id">公告编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<BulletinDetailViewModel> GetBulletinDetailAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        Task<BulletinViewModel> SearchBulletinAsync(BulletinViewModel webModel, ApplicationDbContext context);

        #endregion
    }
}
