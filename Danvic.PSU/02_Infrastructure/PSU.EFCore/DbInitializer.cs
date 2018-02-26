//-----------------------------------------------------------------------
// <copyright file= "DbInitializer.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/26 星期一 16:36:03
// Modified by:
// Description: 数据库创建数据初始化
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PSU.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSU.EFCore
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.IdentityUser.Any())
            {
                return;
            }

            //AppUser user = new AppUser
            //{
            //    UserName = "Admin",
            //    Email = "admin@example.com",

            //};
            //context.IdentityUser.Add(user);
            //context.SaveChanges();

            //AppRole role = new AppRole
            //{

            //};
            //context.IdentityRole.Add(role);
            //context.SaveChanges();



        }
    }
}
