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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Instructor;
using PSU.Model.Areas;
using PSU.Model.Areas.Instructor.User;
using PSU.Repository;
using PSU.Repository.Areas.Instructor;

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

        /// <summary>
        /// 获取我的班级信息
        /// </summary>
        /// <param name="id">班级编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<ClassEditViewModel> GetClassAsync(long id, ApplicationDbContext context)
        {
            var webModel = new ClassEditViewModel();
            try
            {
                var model = await UserRepository.GetClassAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.IsEnabled = (EnumType.Enable)(model.IsEnabled ? 1 : 0);
                webModel.Name = model.Name;
                webModel.QQ = model.QQ;
                webModel.Wechat = model.Wechat;
                webModel.DepartmentId = model.DepartmentId.ToString();
                webModel.DepartmentName = model.DepartmentName;
                webModel.InstructorId = model.InstructorId.ToString();
                webModel.InstructorName = model.InstructorName;
                webModel.MajorCode = model.MajorCode.ToString();
                webModel.MajorName = model.MajorName;
                webModel.SessionNum = model.SessionNum + "级";
            }
            catch (Exception ex)
            {
                _logger.LogError("获取我的班级数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 搜索我的班级数据
        /// </summary>
        /// <param name="webModel">班级列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<ClassViewModel> SearchClassAsync(ClassViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await UserRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<ClassData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new ClassData
                    {
                        Id = item.Id.ToString(),
                        Name = item.Name,
                        Department = item.DepartmentName,
                        QQNumber = !string.IsNullOrEmpty(item.QQ) ? item.QQ : " ",
                        Wechat = !string.IsNullOrEmpty(item.Wechat) ? item.Wechat : " ",
                        SessionNum = item.SessionNum + "级",
                        MajorName = item.MajorName,
                        MajorCode = item.MajorCode,
                    }));
                }

                webModel.ClassList = dataList;
                webModel.Total = await UserRepository.GetListCountAsync(webModel, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取我的班级列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 更新班级数据
        /// </summary>
        /// <param name="webModel">班级编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<bool> UpdateClassAsync(ClassEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update Class Data
                UserRepository.UpdateEntityAsync(webModel, context);

                //Add Operate Information
                var operate = string.Format("修改我的班级信息，专业班级编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync("MajorClass", "UserDomain", "UpdateClassAsync", operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

                var index = await context.SaveChangesAsync();

                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("更新我的班级失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion

        #region Profile Interface Service Implement

        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<ProfileViewModel> GetProfileAsync(long id, ApplicationDbContext context)
        {
            var webModel = new ProfileViewModel();
            try
            {
                var model = await PSURepository.GetUserByIdAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.Name = model.Name;
                webModel.Address = model.Address;
                webModel.Age = model.Age;
                webModel.CreateTime = model.CreatedOn.ToString();
                webModel.Email = model.Email;
                webModel.Gender = model.Gender;
                webModel.Phone = model.Phone;
                webModel.Account = model.Account;
                webModel.Department = model.Department;
                webModel.QQ = model.QQ.ToString();
                webModel.Wechat = model.Wechat;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取用户个人数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 更新个人信息
        /// </summary>
        /// <param name="webModel">个人信息页视图Model</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public async Task<bool> UpdateProfileAsync(ProfileViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update IdentityUser Data
                UserRepository.UpdateAsync(webModel, context);

                //Add Operate Information
                var operate = string.Format("修改个人信息，账户编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync("IdentityUser", "UserDomain", "UpdateProfileAsync", operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

                var index = await context.SaveChangesAsync();

                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("更新个人信息失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion
    }
}
