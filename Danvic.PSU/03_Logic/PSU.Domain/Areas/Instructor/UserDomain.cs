//-----------------------------------------------------------------------
// <copyright file= "UserDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:29:36
// Modified by:
// Description: Instructor-User控制器邻域功能接口实现
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Instructor;
using PSU.Model.Areas.Instructor.User;

namespace PSU.Domain.Areas.Instructor
{
    public class UserDomain : IUserService
    {
        #region Initialize

        private readonly ILogger _logger;

        public UserDomain(ILogger<UserDomain> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Class Interface Service Implement

        public Task<ClassEditViewModel> GetClassAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        public Task<ClassViewModel> SearchClassAsync(ClassViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        public Task<ClassEditViewModel> UpdateClassAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Profile Interface Service Implement

        public Task<ProfileViewModel> GetProfileAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        public Task<ProfileViewModel> UpdateProfileAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
