//-----------------------------------------------------------------------
// <copyright file= "BasicDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/4 星期三 14:20:05
// Modified by:
// Description: Administrator-Basic控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.Basic;
using PSU.Repository;
using PSU.Repository.Areas.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Administrator
{
    public class BasicDomain : IBasicService
    {
        #region Initialize

        private readonly ILogger _logger;

        public BasicDomain(ILogger<BasicDomain> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Profile Interface Service Implement

        /// <summary>
        /// 获取用户个人信息
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<ProfileViewModel> GetUserProfileAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新用户个人信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> UpdateUserProfileAsync(ProfileViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Staff Interface Service Implement

        /// <summary>
        ///删除教职工信息
        /// </summary>
        /// <param name="id">教职工编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> DeleteStaffAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取教职工信息
        /// </summary>
        /// <param name="id">教职工编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<StaffEditViewModel> GetStaffAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增教职工信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> InsertStaffAsync(StaffEditViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 搜索教职工信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<StaffViewModel> SearchStaffAsync(StaffViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await BasicRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<StaffData>();

                if (list != null && list.Any())
                {
                    foreach (var item in list)
                    {
                        var appUser = await PSURepository.GetUserAsync(item.IdentityUserFK, context);

                        var staff = new StaffData
                        {
                            Id = item.Id.ToString(),
                            Name = item.Name,
                            Gender = item.Gender,
                            Account = appUser.UserName,
                            Phone = appUser.PhoneNumber,
                            Department = item.Department
                        };

                        dataList.Add(staff);
                    }
                }

                webModel.StaffList = dataList;
                webModel.Total = await BasicRepository.GetListCountAsync(webModel, context);

            }
            catch (Exception ex)
            {
                _logger.LogError("获取教职工信息列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 更新教职工信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> UpdateStaffAsync(StaffEditViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Student Interface Service Implement

        /// <summary>
        ///删除学生信息
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> DeleteStudentAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<StudentEditViewModel> GetStudentAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增学生信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> InsertStudentAsync(StudentEditViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 搜索学生信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<StudentViewModel> SearchStudentAsync(StudentViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await BasicRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<StudentData>();

                if (list != null && list.Any())
                {
                    foreach (var item in list)
                    {
                        var appUser = await PSURepository.GetUserAsync(item.IdentityUserFK, context);

                        var student = new StudentData
                        {
                            Id = item.Id.ToString(),
                            Name = item.Name,
                            Gender = item.Gender,
                            Account = appUser.UserName,
                            Phone = appUser.PhoneNumber,
                            Department = item.Department,
                            MajorClass = item.MajorClass
                        };

                        dataList.Add(student);
                    }
                }

                webModel.StudentList = dataList;
                webModel.Total = await BasicRepository.GetListCountAsync(webModel, context);

            }
            catch (Exception ex)
            {
                _logger.LogError("获取学生信息列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> UpdateStudentAsync(StudentEditViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
