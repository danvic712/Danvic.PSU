//-----------------------------------------------------------------------
// <copyright file= "DbInitializer.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/26 星期一 16:36:03
// Modified by:
// Description: 数据库创建数据初始化
//-----------------------------------------------------------------------
using PSU.Entity.Basic;
using PSU.Utility.System;
using System;
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

            var salt = Guid.NewGuid().ToString();

            IdentityUser admin = new IdentityUser
            {
                Name = "管理员姓名",
                Account = "Administrator",
                AccountType = 0,
                Age = 0,
                Birthday = new DateTime(),
                Salt = salt,
                Password = MD5Utility.Sign("123456789", salt),
                Gender = true,
                IsEnabled = true,
                Email = "administrator@jixia.com",
                HomePage = "Administrator",
                IdNumber = "0",
                DepartmentId = 0,
                Department = "管理员部门"

            };

            context.IdentityUser.Add(admin);
            context.SaveChanges();

        }
    }
}
