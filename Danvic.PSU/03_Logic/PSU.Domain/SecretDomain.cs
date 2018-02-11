//-----------------------------------------------------------------------
// <copyright file= "SecretDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/11 星期日 13:48:44
// Modified by:
// Description: 
//-----------------------------------------------------------------------
using PSU.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSU.Domain
{
    public class SecretDomain : ISecretService
    {
        #region Interface Service Implement

        public bool SignIn(string account, string password)
        {
            return true;
        }

        #endregion
    }
}
