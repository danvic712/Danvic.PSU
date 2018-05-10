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
using static PSU.Model.Areas.EnumType;

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
        public async Task<ProfileViewModel> GetUserProfileAsync(long id, ApplicationDbContext context)
        {
            var webModel = new ProfileViewModel();
            try
            {
                var model = await BasicRepository.GetProfileAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.Name = model.Name;
                webModel.Address = model.Address;
                webModel.Age = model.Age;
                webModel.CreateTime = model.CreatedOn.ToString();
                webModel.Email = model.Email;
                webModel.Gender = model.Gender;
                webModel.Phone = model.Phone;
                webModel.Account = model.Account;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取用户个人数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 更新用户个人信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> UpdateUserProfileAsync(ProfileViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update IdentityUser Data
                BasicRepository.UpdateAsync(webModel, context);

                //Add Operate Information
                var operate = string.Format("修改管理员信息，管理员编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync("IdentityUser", "BasicDomain", "UpdateUserProfileAsync", operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

                var index = await context.SaveChangesAsync();

                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("更新管理员信息失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion

        #region Staff Interface Service Implement

        /// <summary>
        ///删除教职工信息
        /// </summary>
        /// <param name="id">教职工编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> DeleteStaffAsync(long id, ApplicationDbContext context)
        {
            try
            {
                //Delete staff Data
                await BasicRepository.DeleteStaffAsync(id, context);

                //Add Operate Information
                var operate = string.Format("删除教职工数据，教职工编号:{0}", id);
                PSURepository.InsertRecordAsync("IdentityUser", "BasicDomain", "DeleteStaffAsync", operate, (short)PSURepository.OperateCode.Delete, id, context);

                var index = await context.SaveChangesAsync();
                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("删除教职工失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取教职工信息
        /// </summary>
        /// <param name="id">教职工编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<StaffEditViewModel> GetStaffAsync(long id, ApplicationDbContext context)
        {
            var webModel = new StaffEditViewModel();
            try
            {
                var model = await PSURepository.GetUserByIdAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.IsEnabled = (Enable)(model.IsEnabled ? 1 : 0);
                webModel.Name = model.Name;
                webModel.QQ = model.QQ.ToString();
                webModel.Wechat = model.Wechat;
                webModel.DepartmentId = model.DepartmentId;
                webModel.DepartmentName = model.Department;
                webModel.Account = model.Account;
                webModel.Address = model.Address;
                webModel.Age = model.Age;
                webModel.Email = model.Email;
                webModel.Gender = model.Gender;
                webModel.IdNumber = model.IdNumber;
                webModel.IsMaster = model.IsMaster;
                webModel.Password = model.Password;
                webModel.Phone = model.Phone;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取教职工数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 新增教职工信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> InsertStaffAsync(StaffEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Add the staff Data
                var model = await BasicRepository.InsertAsync(webModel, context);

                if (model.Id == -1)
                {
                    return false;
                }

                //Make the transaction commit
                var index = await context.SaveChangesAsync();

                return index == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError("创建新职工失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
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
                        var staff = new StaffData
                        {
                            Id = item.Id.ToString(),
                            Name = item.Name,
                            Gender = item.Gender,
                            Account = item.Account,
                            Phone = item.Phone,
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
        public async Task<bool> UpdateStaffAsync(StaffEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update staff Data
                BasicRepository.UpdateAsync(webModel, context);

                //Add Operate Information
                var operate = string.Format("修改教职工信息，教职工编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync("IdentityUser", "BasicDomain", "UpdateStaffAsync", operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

                var index = await context.SaveChangesAsync();

                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("更新教职工失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion

        #region Student Interface Service Implement

        /// <summary>
        ///删除学生信息
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> DeleteStudentAsync(long id, ApplicationDbContext context)
        {
            try
            {
                //Delete staff Data
                await BasicRepository.DeleteStaffAsync(id, context);

                //Add Operate Information
                var operate = string.Format("删除学生数据，学生编号:{0}", id);
                PSURepository.InsertRecordAsync("IdentityUser", "BasicDomain", "DeleteStudentAsync", operate, (short)PSURepository.OperateCode.Delete, id, context);

                var index = await context.SaveChangesAsync();
                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("删除学生失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<StudentEditViewModel> GetStudentAsync(long id, ApplicationDbContext context)
        {
            var webModel = new StudentEditViewModel();
            try
            {
                var model = await PSURepository.GetUserByIdAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.Account = model.Account;
                webModel.Address = model.Address;
                webModel.Age = model.Age;
                webModel.Birthday = model.Birthday.ToString("yyyy-MM-dd");
                webModel.City = model.City;
                webModel.CityId = model.CityId;
                webModel.DepartmentId = model.DepartmentId;
                webModel.DepartmentName = model.Department;
                webModel.District = model.District;
                webModel.DistrictId = model.DistrictId;
                webModel.Email = model.Email;
                webModel.EndDate = model.EndDate.ToString("yyyy-MM-dd");
                webModel.StartDate = model.StartDate.ToString("yyyy-MM-dd");
                webModel.TicketId = model.TicketId.ToString();
                webModel.HighSchool = model.HighSchool;
                webModel.Hobbies = model.Hobbies;
                webModel.MajorClass = model.MajorClass;
                webModel.MajorClassId = model.MajorClassId;
                webModel.Province = model.Province;
                webModel.ProvinceId = model.ProvinceId;
                webModel.Winning = model.Winning;
                webModel.IsEnabled = (Enable)(model.IsEnabled ? 1 : 0);
                webModel.Name = model.Name;
                webModel.QQ = model.QQ.ToString();
                webModel.Wechat = model.Wechat;
                webModel.Gender = model.Gender;
                webModel.IdNumber = model.IdNumber;
                webModel.Password = model.Password;
                webModel.Phone = model.Phone;

            }
            catch (Exception ex)
            {
                _logger.LogError("获取学生数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 新增学生信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> InsertStudentAsync(StudentEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Add the student Data
                var model = await BasicRepository.InsertAsync(webModel, context);

                if (model.Id == -1)
                {
                    return false;
                }

                //Make the transaction commit
                var index = await context.SaveChangesAsync();

                return index == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError("创建新职工失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
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
                        var student = new StudentData
                        {
                            Id = item.Id.ToString(),
                            Name = item.Name,
                            Gender = item.Gender,
                            Account = item.Account,
                            Phone = item.Phone,
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
        public async Task<bool> UpdateStudentAsync(StudentEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update student Data
                BasicRepository.UpdateAsync(webModel, context);

                //Add Operate Information
                var operate = string.Format("修改学生信息，学生编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync("IdentityUser", "BasicDomain", "UpdateStudentAsync", operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

                var index = await context.SaveChangesAsync();

                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("更新学生失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion

        #region Common Interface Service Implement

        /// <summary>
        /// 判断当前用户名是否存在
        /// </summary>
        /// <param name="account"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<bool> CheckAccountAsync(string account, ApplicationDbContext context)
        {
            var model = await PSURepository.GetUserByAccountAsync(account, context);
            return model != null;
        }

        /// <summary>
        /// 获取编辑页面部门下拉列表
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文</param>
        /// <returns></returns>
        public async Task<StaffEditViewModel> GetDropDownListAsync(StaffEditViewModel webModel, ApplicationDbContext context)
        {
            //Get Source Data
            var departmentList = await BasicRepository.GetDepartmentList(context);

            if (departmentList != null && departmentList.Any())
            {
                webModel.DepartmentList = departmentList.Select(item => new DepartmentDropDown
                {
                    Id = item.Id.ToString(),
                    Name = item.Name
                }).ToList();
            }

            return webModel;
        }

        /// <summary>
        /// 获取编辑页面下拉列表
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文</param>
        /// <returns></returns>
        public async Task<StudentEditViewModel> GetDropDownListAsync(StudentEditViewModel webModel, ApplicationDbContext context)
        {
            //Get Source Data
            //
            var departmentList = await BasicRepository.GetDepartmentList(context);
            var majorclassList = await BasicRepository.GetMajorClassList(context);

            if (departmentList != null && departmentList.Any())
            {
                webModel.DepartmentList = departmentList.Select(item => new DepartmentDropDown
                {
                    Id = item.Id.ToString(),
                    Name = item.Name
                }).ToList();
            }

            if (majorclassList != null && majorclassList.Any())
            {
                webModel.MajorClassList = majorclassList.Select(item => new MajorClassDropDown
                {
                    Id = item.Id.ToString(),
                    Name = item.Name
                }).ToList();
            }

            return webModel;
        }

        #endregion
    }
}
