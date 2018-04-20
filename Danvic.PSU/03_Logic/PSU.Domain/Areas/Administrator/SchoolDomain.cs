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
using PSU.Model.Areas;

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
                PSURepository.InsertRecordAsync("Department", "SchoolDomain", "DeleteDepartmentAsync", operate, (short)PSURepository.OperateCode.Delete, id, context);

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
                webModel.IsBranch = (EnumType.Branch)(model.IsBranch ? 1 : 0);
                webModel.Address = model.Address;
                webModel.Email = model.Email;
                webModel.Introduction = model.Introduction;
                webModel.IsEnabled = (EnumType.Enable)(model.IsEnabled ? 1 : 0);
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
                        Wechat = item.Wechat,
                        IsBranch = item.IsBranch
                    }));
                }

                webModel.DepartmentList = dataList;
                webModel.Total = await SchoolRepository.GetListCountAsync(webModel, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取院系列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 更新部门/院系信息
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
                PSURepository.InsertRecordAsync("Department", "SchoolDomain", "UpdateDepartmentAsync", operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

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
        /// 删除专业班级信息
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> DeleteMajorClassAsync(long id, ApplicationDbContext context)
        {
            try
            {
                //Delete Major Class Data
                await SchoolRepository.DeleteMajorClassAsync(id, context);

                //Add Operate Information
                var operate = string.Format("删除专业班级数据，专业班级Id:{0}", id);
                PSURepository.InsertRecordAsync("MajorClass", "SchoolDomain", "DeleteMajorClassAsync", operate, (short)PSURepository.OperateCode.Delete, id, context);

                var index = await context.SaveChangesAsync();
                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("删除专业班级失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取编辑页面下拉列表
        /// </summary>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<MajorClassEditViewModel> GetDropDownListAsync(MajorClassEditViewModel webModel, ApplicationDbContext context)
        {
            //Get Source Data
            var departmentList = await SchoolRepository.GetDepartmentList(context);
            var staffList = await SchoolRepository.GetStaffList(context);

            if (departmentList != null && departmentList.Any())
            {
                webModel.DepartmentList = departmentList.Select(item => new DepartmentDropDown
                {
                    Id = item.Id.ToString(),
                    Name = item.Name
                }).ToList();
            }

            if (staffList != null && staffList.Any())
            {
                webModel.StaffList = staffList.Select(item => new StaffDropDown
                {
                    Id = item.Id.ToString(),
                    Name = item.Name
                }).ToList();
            }

            return webModel;
        }

        /// <summary>
        /// 获取专业班级信息
        /// </summary>
        /// <param name="id">专业班级编号</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<MajorClassEditViewModel> GetMajorClassAsync(long id, ApplicationDbContext context)
        {
            var webModel = new MajorClassEditViewModel();
            try
            {
                var model = await SchoolRepository.GetMajorClassAsync(id, context);
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
                webModel.SessionNum = model.SessionNum;
            }
            catch (Exception ex)
            {
                _logger.LogError("获取专业班级数据失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 新增专业班级信息
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> InsertMajorClassAsync(MajorClassEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Add the MajorClass Data
                var model = await SchoolRepository.InsertAsync(webModel, context);

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
                _logger.LogError("创建新专业班级失败：{0},\r\n内部错误详细信息:{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        /// <summary>
        /// 搜索专业班级信息
        /// </summary>
        /// <param name="webModel">列表页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<MajorClassViewModel> SearchMajorClassAsync(MajorClassViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Source Data List
                var list = await SchoolRepository.GetListAsync(webModel, context);

                //Return Data List
                var dataList = new List<MajorClassData>();

                if (list != null && list.Any())
                {
                    dataList.AddRange(list.Select(item => new MajorClassData
                    {
                        Id = item.Id.ToString(),
                        Name = item.Name,
                        SessionNum = item.SessionNum + "级",
                        IsEnabled = item.IsEnabled,
                        MajorName = item.MajorName,
                        MajorCode = item.MajorCode,
                        InstructorName = item.InstructorName
                    }));
                }

                webModel.MajorClassList = dataList;
                webModel.Total = await SchoolRepository.GetListCountAsync(webModel, context);
            }
            catch (Exception ex)
            {
                _logger.LogError("获取专业班级列表失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
            }
            return webModel;
        }

        /// <summary>
        /// 更新专业班级数据
        /// </summary>
        /// <param name="webModel">编辑页视图Model</param>
        /// <param name="context">数据库连接上下文对象</param>
        /// <returns></returns>
        public async Task<bool> UpdateMajorClassAsync(MajorClassEditViewModel webModel, ApplicationDbContext context)
        {
            try
            {
                //Update Major Class Data
                SchoolRepository.UpdateAsync(webModel, context);

                //Add Operate Information
                var operate = string.Format("修改专业班级信息，专业班级编号:{0}", webModel.Id);
                PSURepository.InsertRecordAsync("MajorClass", "SchoolDomain", "UpdateMajorClassAsync", operate, (short)PSURepository.OperateCode.Update, Convert.ToInt64(webModel.Id), context);

                var index = await context.SaveChangesAsync();

                return index == 2;
            }
            catch (Exception ex)
            {
                _logger.LogError("更新专业班级失败：{0},\r\n内部错误信息：{1}", ex.Message, ex.InnerException.Message);
                return false;
            }
        }

        #endregion
    }
}
