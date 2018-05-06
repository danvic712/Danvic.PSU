//-----------------------------------------------------------------------
// <copyright file= "NewbornDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:28:58
// Modified by:
// Description: Instructor-Newborn控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Instructor;
using PSU.Model.Areas.Instructor.Newborn;
using PSU.Repository.Areas.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                webModel.Total = await NewbornRepository.GetListCountAsync(webModel, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取新生注册列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
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

        #region Information Interface Service Implement

        /// <summary>
        /// 搜索新生信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<InformationViewModel> SearchStudentAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await NewbornRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<StudentData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new StudentData
                    {
                        Id = item.Id.ToString(),
                        Name = item.Name,
                        Address = item.Province + "省 " + item.City + "市",
                        Department = item.Department,
                        MajorClass = item.MajorClass,
                        Age = item.Age,
                        Gender = item.Gender
                    }));
                }

                webModel.StudentList = dataList;
                webModel.Total = await NewbornRepository.GetListCountAsync(webModel, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取新生列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 获取新生详细数据
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<InformationDetailViewModel> GetStudentAsync(long id, ApplicationDbContext context)
        {
            var webModel = new InformationDetailViewModel();
            try
            {
                var model = await NewbornRepository.GetEntityAsync(id, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取新生数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        #endregion
    }
}
