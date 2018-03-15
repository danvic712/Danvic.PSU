//-----------------------------------------------------------------------
// <copyright file= "HomeDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/27 星期二 15:13:35
// Modified by:
// Description: Administrator-Home控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.Entity.Basic;
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.Home;
using PSU.Repository;
using PSU.Repository.Areas.Administrator;
using PSU.Utility.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Administrator
{
    public class HomeDomain : IHomeService
    {
        #region Initialize

        private readonly ILogger _logger;

        public HomeDomain(ILogger<HomeDomain> logger)
        {
            _logger = logger;
        }

        public enum OperateCode
        {
            Insert = 0,
            Update = 1,
            Delete = 2
        }

        #endregion

        #region Index Interface Service Implement

        /// <summary>
        /// 初始化加载
        /// </summary>
        /// <returns></returns>
        public Task<IndexViewModel> InitIndexPageAsync()
        {
            IndexViewModel webModel = new IndexViewModel();
            return Task.FromResult(webModel);
        }

        #endregion

        #region Bulletin Interface Service Implement

        /// <inheritdoc />
        /// <summary>
        /// 删除公告数据
        /// </summary>
        /// <param name="id">公告编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<bool> DeleteBulletinAsync(long id, ApplicationDbContext context)
        {
            try
            {
                //Delete Bulletin Data
                await HomeRepository.DeleteAsync(id, context);

                //Add Operate Information
                var operate = string.Format("删除公告数据，公告Id:{0}", id);
                PSURepository.InsertRecordAsync(operate, (short)OperateCode.Delete, id, context);

                var index = await context.SaveChangesAsync();
                return index == 2 ? true : false;
            }
            catch (Exception ex)
            {
                _logger.LogError("删除公告数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取公告数据
        /// </summary>
        /// <param name="id">公告编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<BulletinEditViewModel> GetBulletinAsync(long id, ApplicationDbContext context)
        {
            var webModel = new BulletinEditViewModel();
            try
            {
                var model = await HomeRepository.GetEntityAsync(id, context);
                webModel.Title = model.Title;
                webModel.Id = model.Id.ToString();
                webModel.Content = model.Content;
                webModel.Target = (BulletinTarget)model.Target;
                webModel.Type = (BulletinType)model.Type;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取公告数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 获取公告详情页数据
        /// </summary>
        /// <param name="id">公告编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<BulletinDetailViewModel> GetDetailAsync(long id, ApplicationDbContext context)
        {
            //Get Bulletin Data
            var bulletin = await HomeRepository.GetEntityAsync(id, context);

            //Get Operate Data
            var record = await PSURepository.GetRecordListAsync(id, context);
            var list = new List<Operate>();
            if (record != null && record.Any())
                list.AddRange(record.Select(item => new Operate
                {
                    Name = item.UserName,
                    DateTime = item.DateTime.ToString("yyyy-MM-dd HH:mm"),
                    Operating = item.Operate
                }));

            //Bulid Web Model
            var webModel = new BulletinDetailViewModel
            {
                Title = bulletin.Title,
                Content = bulletin.Content,
                CreatedOn = bulletin.CreatedOn,
                OperateName = bulletin.CreatedName,
                OperateList = list.OrderBy(i => i.DateTime).ToList()
            };
            return webModel;
        }

        /// <summary>
        /// 新增公告数据
        /// </summary>
        /// <param name="webModel">公告编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<bool> InsertBulletinAsync(BulletinEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Add the Bulletion Data
                var model = await HomeRepository.InsertAsync(webModel.Title, (short)webModel.Target, (short)webModel.Type, webModel.Content, context);

                //Make the transaction union
                var index = await context.SaveChangesAsync();

                return index == 1 ? true : false;
            }
            catch (Exception ex)
            {
                _logger.LogError("创建新公告失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// 搜索公告数据
        /// </summary>
        /// <param name="webModel">公告列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<BulletinViewModel> SearchBulletinAsync(BulletinViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await HomeRepository.GetListAsync(webModel.Limit, webModel.Page, webModel.Start, webModel.STitle,
                    webModel.SDateTime, webModel.SType, context);
                //Return Data List
                var dataList = new List<ReturnData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(from item in list
                        let content = StringUtility.HtmlToText(item.Content).Length <= 10 ? StringUtility.HtmlToText(item.Content) : StringUtility.HtmlToText(item.Content).Substring(0, 10) + "..."
                        select new ReturnData
                        {
                            Id = item.Id.ToString(),
                            Content = content,
                            DateTime = item.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss"),
                            Publisher = item.CreatedName,
                            Target = item.Target,
                            Title = item.Title,
                            Type = item.Type
                        });
                }

                webModel.BulletinList = dataList;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取公告列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 更新公告数据
        /// </summary>
        /// <param name="webModel">公告编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<bool> UpdateBulletinAsync(BulletinEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update Bulletin Data
                HomeRepository.UpdateAsync(Convert.ToInt64(webModel.Id), webModel.Title, (short)webModel.Target, (short)webModel.Type, webModel.Content, context);

                //Add Operate Information
                var operate = string.Format("修改公告信息，公告编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync(operate, (short)OperateCode.Update, Convert.ToInt64(webModel.Id), context);

                var index = await context.SaveChangesAsync();

                return index == 2 ? true : false;
            }
            catch (Exception ex)
            {
                _logger.LogError("更新公告数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion

        #region Method
        #endregion
    }
}
