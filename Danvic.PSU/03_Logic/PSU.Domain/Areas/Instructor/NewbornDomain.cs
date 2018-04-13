//-----------------------------------------------------------------------
// <copyright file= "NewbornDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:28:58
// Modified by:
// Description: Instructor-Newborn控制器邻域功能接口实现
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Instructor;
using PSU.Model.Areas.Instructor.Newborn;
using PSU.Repository.Areas.Instructor;

namespace PSU.Domain.Areas.Instructor
{
    public class NewbornDomain : INewbornService
    {
        #region Initialize

        private readonly ILogger _logger;

        public NewbornDomain(ILogger<NewbornDomain> logger)
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
        public async Task<RegisterViewModel> SearchRegisterAsync(RegisterViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await NewbornRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<RegisterData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new RegisterData
                    {
                        Id = item.StudentId.ToString(),
                        Name = item.Name,
                        Address = item.Place,
                        Department = item.Department,
                        MajorClass = item.MajorClass,
                        Way = item.Way,
                        DateTime = item.ArriveTime,
                        Remark = item.Remark
                    }));
                }

                webModel.RegisterList = dataList;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取新生注册列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

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
    }
}
