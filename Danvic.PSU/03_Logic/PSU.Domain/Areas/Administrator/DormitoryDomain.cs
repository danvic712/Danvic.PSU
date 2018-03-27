//-----------------------------------------------------------------------
// <copyright file= "DormitoryDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/23 星期五 16:57:20
// Modified by:
// Description: Administrator-Dormitory控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.Dormitory;
using PSU.Repository;
using PSU.Repository.Areas.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Administrator
{
    public class DormitoryDomain : IDormitoryService
    {
        #region Initialize

        private readonly ILogger _logger;

        public DormitoryDomain(ILogger<DormitoryDomain> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Building Interface Service Implement

        /// <summary>
        ///删除宿舍楼信息
        /// </summary>
        /// <param name="id">宿舍楼编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> DeleteBuildingAsync(long id, ApplicationDbContext context)
        {
            try
            {
                //Delete Building Data
                await DormitoryRepository.DeleteAsync(id, context);

                //Add Operate Information
                var operate = string.Format("删除宿舍楼数据，宿舍楼Id:{0}", id);
                PSURepository.InsertRecordAsync(operate, (short)PSURepository.OperateCode.Delete, id, context);

                var index = await context.SaveChangesAsync();
                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("删除宿舍楼失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取宿舍楼信息
        /// </summary>
        /// <param name="id">宿舍楼编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<BuildingEditViewModel> GetBuildingAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增宿舍楼信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> InsertBuildingAsync(BuildingEditViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 搜索宿舍楼信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<BuildingViewModel> SearchBuildingAsync(BuildingViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await DormitoryRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<BuildingData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new BuildingData
                    {
                        Id = item.Id.ToString(),
                        Name = item.Name,
                        Floor = item.Floor,
                        Type = item.Type,
                        CreatedName = item.CreatedName,
                        DateTime = item.CreatedOn.ToString("yyyy-MM-dd"),
                        IsEnabled = item.IsEnabled
                    }));
                }

                webModel.BuildingList = dataList;

            }
            catch (Exception ex)
            {
                _logger.LogError("获取宿舍楼列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 更新宿舍楼信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> UpdateBuildingAsync(BuildingEditViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
