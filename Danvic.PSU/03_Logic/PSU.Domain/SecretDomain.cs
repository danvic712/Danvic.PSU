//-----------------------------------------------------------------------
// <copyright file= "SecretDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/11 星期日 13:48:44
// Modified by:
// Description: Secret控制器邻域功能接口实现
//-----------------------------------------------------------------------
using PSU.IService;
using System;
using System.Threading.Tasks;

namespace PSU.Domain
{
    public class SecretDomain : ISecretService
    {
        #region Interface Service Implement

        /// <summary>
        /// 添加用户登录记录
        /// </summary>
        /// <param name="userOID">用户主键</param>
        /// <param name="userName">用户姓名</param>
        /// <returns></returns>
        public Task AddLogSync(string userOID, string userName)
        {
            //1、新增登录日志信息记录

            //2、更新用户登录次数

            throw new NotImplementedException();
        }

        #endregion
    }
}
