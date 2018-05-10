//-----------------------------------------------------------------------
// <copyright file= "RegisterDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-06 22:59:19
// Modified by:
// Description: Student-Register控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Student;
using PSU.Model.Areas.Student;
using PSU.Repository;
using PSU.Repository.Areas.Student;
using PSU.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Student
{
    public class RegisterDomain : IRegisterService
    {
        #region Initialize

        private readonly ILogger _logger;

        public RegisterDomain(ILogger<RegisterDomain> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Information Interface Service Implement

        /// <summary>
        /// 查找当前用户报名信息
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<InformationViewModel> GetInformationAsync(long id, ApplicationDbContext context)
        {
            var webModel = new InformationViewModel();
            try
            {
                //Get register Data
                var register = await RegisterRepository.GetEntityAsync(id, context);

                if (register != null)
                {
                    webModel.ArriveTime = register.ArriveTime.ToString("yyyy-MM-dd");
                    webModel.ExpressId = register.ExpressId;
                    webModel.Id = register.Id.ToString();
                    webModel.IsExpress = register.IsExpress;
                    webModel.Place = register.Place;
                    webModel.Remark = register.Remark;
                    webModel.Way = register.Way;
                }

                var user = await PSURepository.GetUserByIdAsync(CurrentUser.UserId, context);

                webModel.SId = user.Id.ToString();
                webModel.Department = user.Department;
                webModel.MajorClass = user.MajorClass;
                webModel.Name = user.Name;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取用户报名数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 新增当前用户报名信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> InsertInformationAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Add the register Data
                var model = await RegisterRepository.InsertAsync(webModel, context);

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
                _logger.LogError("创建报名信息失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion

        #region Booking Interface Service Implement

        /// <summary>
        /// 查找当前学生服务预定信息
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<BookingViewModel> GetBookingAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增当前用户服务预定信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> InsertBookingAsync(BookingViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Goods Interface Service Implement

        /// <summary>
        /// 查找当前学生物品选择信息
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<GoodsViewModel> GetGoodsAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增当前用户物品选择信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> InsertGoodsAsync(GoodsViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Dormitory Interface Service Implement

        /// <summary>
        /// 查找当前学生寝室选择信息
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<DormitoryViewModel> GetDormitoryAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增当前用户寝室选择信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> InsertDormitoryAsync(DormitoryViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
