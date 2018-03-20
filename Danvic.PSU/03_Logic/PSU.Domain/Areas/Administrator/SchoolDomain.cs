//-----------------------------------------------------------------------
// <copyright file= "SchoolDomain.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-11 20:51:44
// Modified by:
// Description: Administrator-School控制器邻域功能接口实现
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.School;
using PSU.Repository;
using PSU.Repository.Areas.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Domain.Areas.Administrator
{
    public class SchoolDomain : ISchoolService
    {
        #region Initialize

        private readonly ILogger _logger;

        public SchoolDomain(ILogger<SchoolDomain> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Department Interface Service Implement

        /// <summary>
        /// 搜索部门/院系信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<DepartmentViewModel> SearchDepartmentAsync(DepartmentViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await SchoolRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<DepartmentData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new DepartmentData
                    {
                        Id = item.Id.ToString(),
                        Name = item.Name,
                        Email = item.Email,
                        Tel = item.Tel,
                        Wechat = item.Wechat
                    }));
                }

                webModel.DepartmentList = dataList;

            }
            catch (Exception ex)
            {
                _logger.LogError("获取院系列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 新增部门/院系信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> InsertDepartmentAsync(DepartmentEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Add the Department Data
                var model = await SchoolRepository.InsertAsync(webModel, context);

                //Make the transaction commit
                var index = await context.SaveChangesAsync();

                return index == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError("创建新部门/院系失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取部门/院系信息
        /// </summary>
        /// <param name="id">部门/院系编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<DepartmentEditViewModel> GetDepartmentAsync(long id, ApplicationDbContext context)
        {
            var webModel = new DepartmentEditViewModel();
            try
            {
                var model = await SchoolRepository.GetAsync(id, context);
                webModel.Id = model.Id.ToString();
                webModel.IsBranch = (Branch)(model.IsBranch ? 1 : 0);
                webModel.Address = model.Address;
                webModel.Email = model.Email;
                webModel.Introduction = model.Introduction;
                webModel.IsEnabled = (Enable)(model.IsEnabled ? 1 : 0);
                webModel.Name = model.Name;
                webModel.QQ = model.QQ;
                webModel.Tel = model.Tel;
                webModel.Wechat = model.Wechat;
                webModel.Weibo = model.Weibo;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取部门/院系数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        ///删除部门/院系信息
        /// </summary>
        /// <param name="id">部门/院系编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> DeleteDepartmentAsync(long id, ApplicationDbContext context)
        {
            try
            {
                //Delete Department Data
                await SchoolRepository.DeleteAsync(id, context);

                //Add Operate Information
                var operate = string.Format("删除部门/院系数据，部门/院系Id:{0}", id);
                PSURepository.InsertRecordAsync(operate, (short)PSURepository.OperateCode.Delete, id, context);

                var index = await context.SaveChangesAsync();
                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("删除部门/院系失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新取部门/院系信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> UpdateDepartmentAsync(DepartmentEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update Department Data
                SchoolRepository.UpdateAsync(webModel, context);

                //Add Operate Information
                var operate = string.Format("修改部门/院系信息，部门/院系编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync(operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

                var index = await context.SaveChangesAsync();

                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("更新部门/院系失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion

        #region Major Class Interface Service Implement

        /// <summary>
        /// 搜索专业班级信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<MajorClassViewModel> SearchMajorClassAsync(MajorClassViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增专业班级信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> InsertMajorClassAsync(MajorClassEditViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取专业班级信息
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<MajorClassEditViewModel> GetMajorClassAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除专业班级信息
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> DeleteMajorClassAsync(long id, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新专业班级数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public Task<bool> UpdateMajorClassAsync(MajorClassEditViewModel webModel, ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
