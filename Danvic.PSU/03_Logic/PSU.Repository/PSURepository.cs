//-----------------------------------------------------------------------
// <copyright file= "PSURepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/10 星期六 9:18:49
// Modified by:
// Description: 通用功能仓储实现
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.Basic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PSU.Repository
{
    public class PSURepository
    {
        #region Service

        /// <summary>
        /// 插入操作信息
        /// </summary>
        /// <param name="operate"></param>
        /// <param name="context"></param>
        public static async void InsertRecordAsync(string operate, ApplicationDbContext context)
        {
            var model = new Record
            {
                Operate = operate,
                UserId = "20180202124532",
                UserName = "测试用户姓名"
            };

            await context.Record.AddAsync(model);
        }

        #endregion
    }
}
