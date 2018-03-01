//-----------------------------------------------------------------------
// <copyright file= "HomeRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/27 星期二 16:28:03
// Modified by:
// Description: Administrator-Home-首页功能实现仓储
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSU.Repository.Areas.Administrator
{
    public class HomeRepository
    {
        #region Initialize

        private readonly ApplicationDbContext _context;

        private readonly DbSet<IdentityUser> _dbSet;

        public HomeRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<IdentityUser>();
        }

        #endregion

        #region API



        #endregion
    }
}
