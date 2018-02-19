//-----------------------------------------------------------------------
// <copyright file= "ISecretService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/11 星期日 13:46:31
// Modified by:
// Description: 
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PSU.IService
{
    public interface ISecretService
    {
        #region Service

        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="isPersistent"></param>
        /// <returns></returns>
        bool SignInAsync(string account, string password,bool isPersistent);

        #endregion
    }
}
