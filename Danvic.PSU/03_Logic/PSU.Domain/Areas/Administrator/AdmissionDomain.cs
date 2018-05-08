//-----------------------------------------------------------------------
// <copyright file= "AdmissionDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/2 星期一 13:58:06
// Modified by:
// Description: Administrator-Admission控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.Admission;
using PSU.Repository;
using PSU.Repository.Areas.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PSU.Model.Areas.EnumType;

namespace PSU.Domain.Areas.Administrator
{
    public class AdmissionDomain : IAdmissionService
    {
        #region Initialize

        private readonly ILogger _logger;

        public AdmissionDomain(ILogger<AdmissionDomain> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Service Interface Service Implement

        /// <summary>
        /// 搜索迎新服务信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<ServiceViewModel> SearchServiceAsync(ServiceViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await AdmissionRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<ServiceData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new ServiceData
                    {
                        Id = item.Id.ToString(),
                        Name = item.Name,
                        Address = item.Address,
                        IsEnabled = item.IsEnabled,
                        StartDateTime = item.StartTime.ToString("yyyy-MM-dd HH:mm"),
                        EndDateTime = item.EndTime.ToString("yyyy-MM-dd HH:mm"),
                        Description = !string.IsNullOrEmpty(item.Description) && item.Description.Length > 15 ? item.Description.Substring(0, 15) + "..." : item.Description
                    }));
                }

                webModel.ServiceList = dataList;
                webModel.Total = await AdmissionRepository.GetListCountAsync(webModel, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取迎新服务列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 新增迎新服务信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> InsertServiceAsync(ServiceEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Add the Service Data
                var model = await AdmissionRepository.InsertAsync(webModel, context);

                //Make the transaction commit
                var index = await context.SaveChangesAsync();

                return index == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError("创建迎新服务失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取迎新服务信息
        /// </summary>
        /// <param name="id">迎新服务编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<ServiceEditViewModel> GetServiceAsync(long id, ApplicationDbContext context)
        {
            var webModel = new ServiceEditViewModel();
            try
            {
                var model = await AdmissionRepository.GetServiceAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.Description = model.Description;
                webModel.EndTime = model.EndTime.ToString();
                webModel.IsEnabled = (Enable)(model.IsEnabled ? 1 : 0);
                webModel.Name = model.Name;
                webModel.Place = model.Place;
                webModel.Address = model.Address;
                webModel.StartTime = model.StartTime.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError("获取迎新服务数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        ///删除迎新服务信息
        /// </summary>
        /// <param name="id">迎新服务编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> DeleteServiceAsync(long id, ApplicationDbContext context)
        {
            try
            {
                //Delete Service Data
                await AdmissionRepository.DeleteServiceAsync(id, context);

                //Add Operate Information
                var operate = string.Format("删除迎新服务信息，迎新服务编号:{0}", id);
                PSURepository.InsertRecordAsync("Service", "AdmissionDomain", "DeleteServiceAsync", operate, (short)PSURepository.OperateCode.Delete, id, context);

                var index = await context.SaveChangesAsync();
                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("删除迎新服务失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新迎新服务信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> UpdateServiceAsync(ServiceEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update Service Data
                AdmissionRepository.UpdateAsync(webModel, context);

                //Add Operate Information
                var operate = string.Format("修改迎新服务信息，迎新服务编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync("Service", "AdmissionDomain", "UpdateServiceAsync", operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

                var index = await context.SaveChangesAsync();

                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("更新迎新服务失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion

        #region Goods Interface Service Implement

        /// <summary>
        /// 搜索物品信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<GoodsViewModel> SearchGoodsAsync(GoodsViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await AdmissionRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<GoodsData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new GoodsData
                    {
                        Id = item.Id.ToString(),
                        Name = item.Name,
                        IsEnabled = item.IsEnabled,
                        Size = item.Size,
                        ImageSrc = item.ImageSrc,
                        Description = item.Description.Length > 20 ? item.Description.Substring(0, 20) + "..." : item.Description
                    }));
                }

                webModel.GoodsList = dataList;
                webModel.Total = await AdmissionRepository.GetListCountAsync(webModel, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取物品信息列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 新增物品信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> InsertGoodsAsync(GoodsEditViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取物品信息
        /// </summary>
        /// <param name="id">物品编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<GoodsEditViewModel> GetGoodsAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///删除物品信息
        /// </summary>
        /// <param name="id">物品编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> DeleteGoodsAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新物品信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> UpdateGoodsAsync(GoodsEditViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Question Interface Service Implement

        /// <summary>
        /// 获取提问详情
        /// </summary>
        /// <param name="id">疑问编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<QuestionReplyViewModel> GetQuestionAsync(long id, ApplicationDbContext context)
        {
            var webModel = new QuestionReplyViewModel();
            try
            {
                var model = await AdmissionRepository.GetQuestionAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.AskForName = model.AskForName;
                webModel.AskTime = model.AskTime.ToString("yyyy-MM-dd HH:mm:ss");
                webModel.Content = model.Content;
                webModel.IsReply = model.IsReply;
                webModel.ReplyContent = model.ReplyContent;
                webModel.ReplyId = model.ReplyId;
                webModel.ReplyName = model.ReplyName;
                webModel.ReplyTime = model.ReplyTime.ToString("yyyy-MM-dd HH:mm:ss");
                webModel.StuName = model.StuName;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取疑问信息数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 回复提问信息
        /// </summary>
        /// <param name="webModel">疑问回复页视图Model</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<bool> ReplyQuestionAsync(QuestionReplyViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update Question Data
                AdmissionRepository.ReplyQuestionAsync(webModel, context);

                //Add Operate Information
                var operate = string.Format("回复学生疑问信息，学生疑问编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync("Question", "AdmissionDomain", "ReplyQuestionAsync", operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

                var index = await context.SaveChangesAsync();

                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("回复学生疑问失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 搜索提问信息
        /// </summary>
        /// <param name="webModel"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<QuestionViewModel> SearchQuestionAsync(QuestionViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await AdmissionRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<QuestionData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new QuestionData
                    {
                        Id = item.Id.ToString(),
                        Name = item.StuName,
                        AskFor = item.AskForName,
                        DateTime = item.AskTime.ToString("yyyy-MM-dd HH:mm"),
                        IsReply = item.IsReply,
                        Content = item.Content.Length > 20 ? item.Content.Substring(0, 20) + "..." : item.Content
                    }));
                }

                webModel.QuestionList = dataList;
                webModel.Total = await AdmissionRepository.GetListCountAsync(webModel, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取提问信息列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        #endregion
    }
}
