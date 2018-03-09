//-----------------------------------------------------------------------
// <copyright file= "HomeDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/27 星期二 15:13:35
// Modified by:
// Description: Administrator-Home控制器邻域功能接口实现
//-----------------------------------------------------------------------
using PSU.EFCore;
using PSU.Entity.Basic;
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.Home;
using PSU.Repository.Areas.Administrator;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Administrator
{
    public class HomeDomain : IHomeService
    {
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
        public Task<BulletinEditViewModel> InsertBulletinAsync(BulletinEditViewModel webModel, ApplicationDbContext context)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 搜索公告数据
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        public async Task<BulletinViewModel> SearchBulletinAsync(BulletinViewModel webModel, ApplicationDbContext context)
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
                    var model = new ReturnData
                    {
                        Id = item.Id.ToString(),
                        Content = item.Content,
                        DateTime = item.CreatedOn.ToString("yyyy-MM-dd hh:mm:ss"),
                        Publisher = item.CreatedName,
                        Target = item.Target,
                        Title = item.Title,
                        Type = item.Type
                    };
                    dataList.Add(model);
                }
            }

            webModel.BulletinList = dataList;

            return webModel;
        }

        #endregion

        #region Method
        #endregion
    }
}
