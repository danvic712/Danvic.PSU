//-----------------------------------------------------------------------
// <copyright file= "DbInitializer.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/26 星期一 16:36:03
// Modified by:
// Description: 数据库创建数据初始化
//-----------------------------------------------------------------------
using PSU.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSU.EFCore
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.IdentityUser.Any())
                return;

            //AppUser user = new AppUser
            //{
            //    UserName = "Admin",
            //    Email = "admin@example.com",

            //};
            //context.IdentityUser.Add(user);
            //context.SaveChanges();




            InitializerRole(context);

        }

        /// <summary>
        /// 初始化角色信息
        /// </summary>
        /// <param name="context"></param>
        private static void InitializerRole(ApplicationDbContext context)
        {
            var admin = new AppRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrator"
            };

            var instructor = new AppRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Instructor"
            };

            var student = new AppRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Student"
            };

            var list = new List<AppRole> { admin, instructor, student };

            context.IdentityRole.AddRange(list);
            context.SaveChanges();
        }
    }
}
