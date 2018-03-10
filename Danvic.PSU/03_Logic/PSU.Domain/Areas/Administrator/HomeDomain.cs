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

        /// <summary>
        /// 新增公告数据
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        public async Task<bool> InsertBulletinAsync(BulletinEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Add the Bulletion Data
                HomeRepository.InsertBulletinAsync(webModel.Title, (short)webModel.Target, (short)webModel.Type, webModel.Content, context);

                //Add the Record Data
                string operate = string.Format("创建新公告：{0}", webModel.Title);
                PSURepository.InsertRecordAsync(operate, context);

                //Make the transaction 
                var index = await context.SaveChangesAsync();

                return index == 2 ? true : false;
            }
            catch (Exception ex)
            {
                _logger.LogError("创建新公告失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 搜索公告数据
        /// </summary>
        /// <param name="webModel"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<BulletinViewModel> SearchBulletinAsync(BulletinViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                List<Bulletin> list = await HomeRepository.GetBulletinListAsync(webModel.Limit, webModel.Page, webModel.Start, webModel.STitle,
                    webModel.SDateTime, webModel.SType, context);
                //Return Data List
                List<ReturnData> dataList = new List<ReturnData>();

                if (list != null && list.Any())
                {
                    foreach (var item in list)
                    {
                        string content = StringUtility.HtmlToText(item.Content).Length <= 10 ? StringUtility.HtmlToText(item.Content) : StringUtility.HtmlToText(item.Content).Substring(0, 10) + "...";

                        var model = new ReturnData
                        {
                            Id = item.Id.ToString(),
                            Content = content,
                            DateTime = item.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss"),
                            Publisher = item.CreatedName,
                            Target = item.Target,
                            Title = item.Title,
                            Type = item.Type
                        };
                        dataList.Add(model);
                    }
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
        /// <param name="webModel"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task<bool> UpdateBulletinAsync(BulletinEditViewModel webModel, ApplicationDbContext context)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取公告数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public BulletinEditViewModel GetBulletin(long id, ApplicationDbContext context)
        {
            BulletinEditViewModel webModel = new BulletinEditViewModel();
            try
            {
                var model = HomeRepository.GetBulletin(id, context);
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
        /// 删除公告数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBulletinAsync(long id, ApplicationDbContext context)
        {
            try
            {
                HomeRepository.DeleteBulletin(id, context);

                int index = await context.SaveChangesAsync();
                return index == 1 ? true : false;
            }
            catch (Exception ex)
            {
                _logger.LogError("删除公告数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion

        #region Method
        #endregion
    }
}
