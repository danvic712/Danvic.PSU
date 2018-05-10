//-----------------------------------------------------------------------
// <copyright file= "RegisterRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-06 22:58:33
// Modified by:
// Description: Student-Register-功能实现仓储
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.SignUp;
using PSU.Model.Areas.Student;
using PSU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSU.Repository.Areas.Student
{
    public class RegisterRepository
    {
        #region Information-API

        /// <summary>
        /// 获取报名信息
        /// </summary>
        /// <param name="id">报名编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Register> GetEntityAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Register.AsNoTracking().Where(i => i.StudentId == id).FirstOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 新增教职工信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Register> InsertAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            //Get Foreign Key Association Table Information
            //
            var user = await context.IdentityUser.AsNoTracking().Where(i => i.Id == CurrentUser.UserId).FirstOrDefaultAsync();

            //return error 
            if (user == null)
            {
                return new Register
                {
                    Id = -1
                };
            }

            var model = InsertModel(webModel);

            model.Department = user.Department;
            model.DepartmentId = user.DepartmentId;
            model.Instructor = user.InstructorName;
            model.InstructorId = user.InstructorId;
            model.MajorClass = user.MajorClass;
            model.MajorClassId = user.MajorClassId;
            model.Name = user.Name;
            model.StudentId = user.Id;

            await context.Register.AddAsync(model);

            return model;
        }

        #endregion

        #region Method-Insert

        /// <summary>
        /// Insert Register Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        private static Register InsertModel(InformationViewModel webModel)
        {
            return new Register
            {
                ArriveTime = Convert.ToDateTime(webModel.ArriveTime),
                DateTime = DateTime.Now,
                ExpressId = webModel.ExpressId,
                IsExpress = webModel.IsExpress,
                Place = webModel.Place,
                Remark = webModel.Remark,
                Way = webModel.Way
            };
        }

        #endregion
    }
}
