//-----------------------------------------------------------------------
// <copyright file= "ISecretService.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/11 星期日 13:46:31
// Modified by:
// Description: Secret控制器邻域功能接口
//-----------------------------------------------------------------------
using System.Threading.Tasks;

namespace PSU.IService
{
    public interface ISecretService
    {
        #region Service

        /// <summary>
        /// 添加用户登录记录
        /// </summary>
        /// <param name="userOID">用户主键</param>
        /// <param name="userName">用户姓名</param>
        /// <returns></returns>
        Task AddLogSync(string userOID, string userName);

        /// <summary>
        /// 设置当前登录用户
        /// </summary>
        void SetCurrentUser();

        #endregion
    }
}
