//-----------------------------------------------------------------------
// <copyright file= "UserRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-06 22:49:19
// Modified by:
// Description: Student-User-功能实现仓储
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.Basic;
using PSU.Model.Areas.Student;
using PSU.Utility;
using System;

namespace PSU.Repository.Areas.Student
{
    public class UserRepository
    {
        #region Profile-API

        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateAsync(ProfileViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.IdentityUser.FirstOrDefaultAsync(i => i.Id == CurrentUser.UserId);

            if (model == null)
            {
                return;
            }

            model = UpdateModel(webModel, model);
        }

        #endregion

        #region Method-Ipdate

        /// <summary>
        /// Update Identity Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private static IdentityUser UpdateModel(ProfileViewModel webModel, IdentityUser model)
        {
            model.Email = webModel.Email;
            model.Phone = webModel.Phone;
            model.Name = webModel.Name;
            model.Gender = webModel.Gender;
            model.IdNumber = webModel.IdNumber;
            model.Wechat = webModel.Wechat;
            model.QQ = Convert.ToInt64(webModel.QQ);
            model.Address = webModel.Address;
            model.Age = webModel.Age;
            model.Birthday = Convert.ToDateTime(webModel.Birthday);
            model.City = webModel.City;
            model.CityId = webModel.CityId;
            model.District = webModel.District;
            model.DistrictId = webModel.DistrictId;
            model.EndDate = Convert.ToDateTime(webModel.EndDate);
            model.HighSchool = webModel.HighSchool;
            model.Province = webModel.Province;
            model.ProvinceId = webModel.ProvinceId;
            model.Hobbies = webModel.Hobbies;
            model.StartDate = Convert.ToDateTime(webModel.StartDate);
            model.TicketId = Convert.ToInt64(webModel.TicketId);
            model.Winning = webModel.Winning;
            model.ModifiedOn = DateTime.Now;
            model.ModifiedId = CurrentUser.UserId;
            model.ModifiedBy = CurrentUser.UserOID;
            model.ModifiedName = CurrentUser.UserName;

            return model;
        }

        #endregion
    }
}
