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
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Administrator
{
    public class SchoolDomain:ISchoolService
    {
        #region Initialize

        private readonly ILogger _logger;

        public SchoolDomain(ILogger<SchoolDomain> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Information nterface Service Implement

        /// <summary>
        /// 获取学校信息
        /// </summary>
        /// <param name="id">学校编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public Task<InformationViewModel> GetInformationAsync(long id, ApplicationDbContext context)
        {
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
            throw new NotImplementedException();
        }

        #endregion
    }
}
