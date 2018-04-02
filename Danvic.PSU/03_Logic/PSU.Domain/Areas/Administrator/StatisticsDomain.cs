//-----------------------------------------------------------------------
// <copyright file= "StatisticsDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-04-02 21:17:07
// Modified by:
// Description: Administrator-Admission控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.Statistics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Administrator
{
    public class StatisticsDomain : IStatisticsService
    {
        #region Initialize

        private readonly ILogger _logger;

        public StatisticsDomain(ILogger<StatisticsDomain> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Register Interface Service Implement

        /// <summary>
        /// 搜索新生注册信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<RegisterViewModel> SearchRegisterAsync(RegisterViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Student Interface Service Implement

        /// <summary>
        /// 搜索物品选择数据信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<GoodsViewModel> SearchStudentAsync(GoodsViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Dormitory Interface Service Implement

        /// <summary>
        /// 搜索宿舍预定信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<DormitoryViewModel> SearchDormitoryAsync(DormitoryViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Book Interface Service Implement

        /// <summary>
        /// 搜索迎新服务预定信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<BookViewModel> SearchBookAsync(BookViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
