//-----------------------------------------------------------------------
// <copyright file= "HomeDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/27 星期二 15:13:35
// Modified by:
// Description: Administrator-Home控制器邻域功能接口实现
//-----------------------------------------------------------------------
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.Home;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Administrator
{
    public class HomeDomain : IHomeService
    {
        #region Interface Service Implement

        public Task<IndexViewModel> InitPageAsync()
        {
            IndexViewModel webModel = new IndexViewModel();
            return Task.FromResult(webModel);
        }

        #endregion
    }
}
