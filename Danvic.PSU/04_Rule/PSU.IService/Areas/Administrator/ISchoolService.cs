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
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PSU.IService.Areas.Administrator
{
    public interface ISchoolService
    {
        #region School-Information

        /// <summary>
        /// 查看数据
        /// </summary>
        /// <param name="id">学校编号</param>
        /// <param name="context">数据库上下文连接对象</param>
        /// <returns></returns>
        Task<InformationViewModel> GetInformationAsync(long id, ApplicationDbContext context);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="webModel">信息页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        Task<bool> InsertInformationAsync(InformationViewModel webModel, ApplicationDbContext context);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="webModel">信息页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        Task<bool> UpdateInformationAsync(InformationViewModel webModel, ApplicationDbContext context);

        #endregion

        #region School-Department

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="webModel"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<DepartmentViewModel> SearchDepartmentAsync(DepartmentViewModel webModel, ApplicationDbContext context);

        #endregion
    }
}
