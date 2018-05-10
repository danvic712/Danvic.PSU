//-----------------------------------------------------------------------
// <copyright file= "UserDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-06 22:48:02
// Modified by:
// Description: Student-User控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Student;
using PSU.Model.Areas.Student;
using PSU.Repository;
using PSU.Repository.Areas.Student;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Student
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

        #region Profile Interface Service Implement

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<ProfileViewModel> GetStudentAsync(long id, ApplicationDbContext context)
        {
            var webModel = new ProfileViewModel();
            try
            {
                var model = await PSURepository.GetUserByIdAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.Address = model.Address;
                webModel.Age = model.Age;
                webModel.Birthday = model.Birthday.ToString("yyyy-MM-dd HH:mm:ss");
                webModel.City = model.City;
                webModel.CityId = model.CityId;
                webModel.DepartmentName = model.Department;
                webModel.District = model.District;
                webModel.DistrictId = model.DistrictId;
                webModel.Email = model.Email;
                webModel.EndDate = model.EndDate.ToString("yyyy-MM");
                webModel.StartDate = model.StartDate.ToString("yyyy-MM");
                webModel.TicketId = model.TicketId.ToString();
                webModel.HighSchool = model.HighSchool;
                webModel.Hobbies = model.Hobbies;
                webModel.MajorClass = model.MajorClass;
                webModel.Province = model.Province;
                webModel.ProvinceId = model.ProvinceId;
                webModel.Winning = model.Winning;
                webModel.Name = model.Name;
                webModel.QQ = model.QQ.ToString();
                webModel.Wechat = model.Wechat;
                webModel.Gender = model.Gender;
                webModel.IdNumber = model.IdNumber;
                webModel.Phone = model.Phone;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取学生数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> UpdateStudentAsync(ProfileViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update student Data
                UserRepository.UpdateAsync(webModel, context);

                //Add Operate Information
                var operate = string.Format("修改个人信息，学生编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync("IdentityUser", "UserDomain", "UpdateStudentAsync", operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

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
