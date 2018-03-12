//-----------------------------------------------------------------------
// <copyright file= "SchoolDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-11 20:51:44
// Modified by:
// Description: Administrator-School控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.School;
using PSU.Repository.Areas.Administrator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Administrator
{
    public class SchoolDomain : ISchoolService
    {
        #region Initialize

        private readonly ILogger _logger;

        public SchoolDomain(ILogger<SchoolDomain> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Information Interface Service Implement

        /// <summary>
        /// 获取学校信息
        /// </summary>
        /// <param name="id">学校编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<InformationViewModel> GetInformationAsync(long id, ApplicationDbContext context)
        {
            //College Information
            var information = await SchoolRepository.GetEntityAsync(id, context);

            //Campus Information

            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增学校信息
        /// </summary>
        /// <param name="webModel">学校信息页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public Task<bool> InsertInformationAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            //College Information

            //Campus Information

            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新学校信息
        /// </summary>
        /// <param name="webModel">学校信息页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public Task<bool> UpdateInformationAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            //College Information

            //Campus Information

            throw new NotImplementedException();
        }

        #endregion

        #region Department Interface Service Implement

        /// <summary>
        /// 获取院系信息
        /// </summary>
        /// <param name="webModel"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<DepartmentViewModel> SearchDepartmentAsync(DepartmentViewModel webModel, ApplicationDbContext context)
        {
            try { }
            catch (Exception ex)
            {
                _logger.LogError("获取院系列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        #endregion
    }
}
