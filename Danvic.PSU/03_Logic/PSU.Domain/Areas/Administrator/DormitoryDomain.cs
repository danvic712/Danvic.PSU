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
using PSU.Model.Areas;

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
        public async Task<BuildingEditViewModel> GetBuildingAsync(long id, ApplicationDbContext context)
        {
            var webModel = new BuildingEditViewModel();
            try
            {
                var model = await DormitoryRepository.GetBuildingAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.IsEnabled = (EnumType.Enable)(model.IsEnabled ? 1 : 0);
                webModel.Name = model.Name;
                webModel.Floor = model.Floor;
                webModel.Type = (EnumType.BuildingType)model.Type;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取宿舍楼数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 新增宿舍楼信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> InsertBuildingAsync(BuildingEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Add the Building Data
                var model = await DormitoryRepository.InsertAsync(webModel, context);

                //Make the transaction commit
                var index = await context.SaveChangesAsync();

                return index == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError("创建宿舍楼失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
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
        public async Task<bool> UpdateBuildingAsync(BuildingEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update Building Data
                DormitoryRepository.UpdateAsync(webModel, context);

                //Add Operate Information
                var operate = string.Format("修改宿舍楼信息，宿舍楼编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync(operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

                var index = await context.SaveChangesAsync();

                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("更新宿舍楼失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion

        #region Bunk Interface Service Implement

        /// <summary>
        ///删除宿舍类型信息
        /// </summary>
        /// <param name="id">宿舍类型编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> DeleteBunkAsync(long id, ApplicationDbContext context)
        {
            try
            {
                //Delete Bunk Data
                await DormitoryRepository.DeleteBunkAsync(id, context);

                //Add Operate Information
                var operate = string.Format("删除宿舍类型数据，宿舍类型Id:{0}", id);
                PSURepository.InsertRecordAsync(operate, (short)PSURepository.OperateCode.Delete, id, context);

                var index = await context.SaveChangesAsync();
                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("删除宿舍类型失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取宿舍类型信息
        /// </summary>
        /// <param name="id">宿舍类型编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<BunkEditViewModel> GetBunkAsync(long id, ApplicationDbContext context)
        {
            var webModel = new BunkEditViewModel();
            try
            {
                var model = await DormitoryRepository.GetBunkAsync(id, context);
                webModel.Id = model.Id.ToString();
                //webModel.IsEnabled = (EnumType.Enable)(model.IsEnabled ? 1 : 0);
                //webModel.Name = model.Name;
                //webModel.Floor = model.Floor;
                //webModel.Type = (EnumType.BuildingType)model.Type;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取宿舍类型数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 新增宿舍类型信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> InsertBunkAsync(BunkEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Add the Bunk Data
                var model = await DormitoryRepository.InsertAsync(webModel, context);

                //Make the transaction commit
                var index = await context.SaveChangesAsync();

                return index == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError("创建宿舍类型失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 搜索宿舍类型信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<BunkViewModel> SearchBunkAsync(BunkViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await DormitoryRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<BunkData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new BunkData
                    {
                        Id = item.Id.ToString(),
                        Name = item.Name,
                        ImageSrc = item.ImageSrc,
                        Number = item.Number,
                        Toward = item.Toward,
                        IsEnabled = item.IsEnabled
                    }));
                }

                webModel.BunkList = dataList;

            }
            catch (Exception ex)
            {
                _logger.LogError("获取宿舍类型列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 更新宿舍类型信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> UpdateBunkAsync(BunkEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update Bunk Data
                DormitoryRepository.UpdateAsync(webModel, context);

                //Add Operate Information
                var operate = string.Format("修改宿舍类型信息，宿舍类型编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync(operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

                var index = await context.SaveChangesAsync();

                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("更新宿舍类型失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion

        #region Information Interface Service Implement

        /// <summary>
        ///删除宿舍信息
        /// </summary>
        /// <param name="id">宿舍编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> DeleteInformationAsync(long id, ApplicationDbContext context)
        {
            try
            {
                //Delete Dorm Information Data
                await DormitoryRepository.DeleteDormAsync(id, context);

                //Add Operate Information
                var operate = string.Format("删除宿舍数据，宿舍Id:{0}", id);
                PSURepository.InsertRecordAsync(operate, (short)PSURepository.OperateCode.Delete, id, context);

                var index = await context.SaveChangesAsync();
                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("删除宿舍失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取宿舍信息
        /// </summary>
        /// <param name="id">宿舍编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<InformationEditViewModel> GetInformationAsync(long id, ApplicationDbContext context)
        {
            var webModel = new InformationEditViewModel();
            try
            {
                var model = await DormitoryRepository.GetDormAsync(id, context);
                webModel.Id = model.Id.ToString();
                //Todo:Add All Data
            }
            catch (Exception ex)
            {
                _logger.LogError("获取宿舍数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 新增宿舍信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> InsertInformationAsync(InformationEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Add the Dorm Information Data
                var model = await DormitoryRepository.InsertAsync(webModel, context);

                //Make the transaction commit
                var index = await context.SaveChangesAsync();

                return index == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError("创建宿舍楼失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 搜索宿舍信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<InformationViewModel> SearchInformationAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await DormitoryRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<InformationData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new InformationData
                    {
                        Id = item.Id.ToString(),
                        Name = item.Name,
                        BuildingName = item.BuildingName,
                        Floor = item.Floor,
                        Type = item.Type,
                        Count = item.Count,
                        SelectedCount = item.SelectedCount,
                        IsEnabled = item.IsEnabled
                    }));
                }

                webModel.InformationList = dataList;

            }
            catch (Exception ex)
            {
                _logger.LogError("获取宿舍列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 更新宿舍信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> UpdateInformationAsync(InformationEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update Building Data
                DormitoryRepository.UpdateAsync(webModel, context);

                //Add Operate Information
                var operate = string.Format("修改宿舍信息，宿舍编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync(operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

                var index = await context.SaveChangesAsync();

                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("更新宿舍失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion
    }
}
