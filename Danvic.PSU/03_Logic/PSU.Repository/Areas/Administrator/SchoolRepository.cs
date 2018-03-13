//-----------------------------------------------------------------------
// <copyright file= "SchoolRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-11 20:59:20
// Modified by:
// Description: Administrator-School-首页功能实现仓储
//-----------------------------------------------------------------------
using LinqKit;
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.Dormitory;
using PSU.Entity.School;
using PSU.Model.Areas.Administrator.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Repository.Areas.Administrator
{
    public class SchoolRepository
    {
        #region Information API

        /// <summary>
        /// 获取学校信息
        /// </summary>
        /// <param name="id">学校编号</param>
        /// <param name="_context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<College> GetEntityAsync(long id, ApplicationDbContext _context)
        {
            var model = await _context.Collage.Where(i => i.Id == id).SingleOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 获取校区相关信息
        /// </summary>
        /// <param name="id">学校编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Campus>> GetListAsync(long id, ApplicationDbContext context)
        {
            return await context.Campus.Where(i => i.CollegeId == id).ToListAsync();
        }

        /// <summary>
        /// 新增学校信息
        /// </summary>
        /// <param name="webModel">学校信息页面视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<College> InsertAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            College model = ConvertToCollegeEntity(webModel);
            await context.Collage.AddAsync(model);

            return model;
        }

        /// <summary>
        /// 新增校区信息
        /// Todo：校区从信息页剥离出来，单独弹窗添加
        /// </summary>
        /// <param name="webModel">学校信息页面视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void InsertCampusAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            //Get College Information
            long id = Convert.ToInt64(webModel.Id);
            var college = await GetEntityAsync(id, context);
            string oid = college.CollegeOID;

            //Add Campus Information
            if (webModel.CampusList != null && webModel.CampusList.Any())
            {
                foreach (var item in webModel.CampusList)
                {
                    var model = ConvertToCampusEntity(id, oid, item);

                    //Get Region Information
                    var province = await PSURepository.GetRegionAsync(Convert.ToInt64(item.ProvinceId), context);
                    var city = await PSURepository.GetRegionAsync(Convert.ToInt64(item.CityId), context);
                    var district = await PSURepository.GetRegionAsync(Convert.ToInt64(item.DistrictId), context);

                    model.ProvinceId = province.Id;
                    model.Province = province.Name;
                    model.ProvinceFK = province.RegionOID;
                    model.CityId = city.Id;
                    model.City = city.Name;
                    model.CityFK = city.RegionOID;
                    model.DistrictId = district.Id;
                    model.District = district.Name;
                    model.DistrictFK = district.RegionOID;

                    await context.Campus.AddAsync(model);
                };
            }
        }

        /// <summary>
        /// 更新学校信息
        /// </summary>
        /// <param name="webModel">学校信息页面视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.Collage.SingleOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));
            model = ConvertToCollegeEntity(webModel, false);
        }

        /// <summary>
        /// 更新校区信息
        /// </summary>
        /// <param name="webModel">学校信息页面视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateCampusAsync(InformationViewModel webModel, ApplicationDbContext context)
        {

        }

        #endregion

        #region Department API

        /// <summary>
        /// 根据搜索条件获取院系信息
        /// </summary>
        /// <param name="webModel">院系列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Department>> GetListAsync(DepartmentViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SId) && string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.STel))
            {
                return await context.Set<Department>().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                IQueryable<Department> departments = context.Department.AsQueryable();

                var predicate = PredicateBuilder.New<Department>();

                //院系编号
                if (!string.IsNullOrEmpty(webModel.SId))
                {
                    predicate = predicate.And(i => i.Id == Convert.ToInt64(webModel.SId));
                }

                //院系名称
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //院系联系方式
                if (!string.IsNullOrEmpty(webModel.STel))
                {
                    predicate = predicate.And(i => i.Tel == webModel.STel);
                }

                return await departments.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 删除院系信息
        /// </summary>
        /// <param name="id">院系编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task DeleteAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Department.SingleOrDefaultAsync(i => i.Id == id);

            context.Remove(model);
        }

        /// <summary>
        /// 获取院系信息
        /// </summary>
        /// <param name="id">院系编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Department> GetDepartmentAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Department.Where(i => i.Id == id).SingleOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 新增院系信息
        /// </summary>
        /// <param name="webModel">院系编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Department> InsertDepartmentAsync(DepartmentEditViewModel webModel, ApplicationDbContext context)
        {
            var model = ConvertToDepartmentEntity(webModel);
            await context.Department.AddAsync(model);

            return model;
        }

        /// <summary>
        /// 更新院系信息
        /// </summary>
        /// <param name="webModel">院系编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateDepartmentAsync(DepartmentEditViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.Department.SingleOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));

            if (model == null)
            {
                return;
            }

            model = ConvertToDepartmentEntity(webModel, false);
        }

        #endregion

        #region Major API

        #endregion

        #region Method

        /// <summary>
        /// View Model => College Entity
        /// </summary>
        /// <param name="webModel">学校信息页视图模型</param>
        /// <param name="isInsert">是否为添加操作</param>
        /// <returns></returns>
        private static College ConvertToCollegeEntity(InformationViewModel webModel, bool isInsert = true)
        {
            var model = new College
            {
                Code = webModel.Code,
                Description = webModel.Description,
                Email = webModel.Email,
                Motto = webModel.Motto,
                Name = webModel.Name,
                NameEN = webModel.NameEN,
                QQ = webModel.QQ,
                SetUpTime = webModel.SetUpTime,
                ImageSrc = webModel.ImageSrc,
                Image = webModel.Image,
                WebSite = webModel.WebSite,
                Introduction = webModel.Introduction,
                IsEnabled = true,
                Wechat = webModel.Wechat,
                Weibo = webModel.Weibo,
            };

            if (isInsert)
            {
                model.CreatedBy = "20171111111";
                model.CreatedName = "我是测试创建人";
            }
            else
            {
                model.ModifiedOn = DateTime.Now;
                model.ModifiedBy = "201712121212121";
                model.ModifiedName = "我是修改测试人";
            }

            return model;
        }

        /// <summary>
        /// View Model => Campus Entity
        /// </summary>
        /// <param name="id">学校编号</param>
        /// <param name="oid">学校信息主键</param>
        /// <param name="campus">校区信息</param>
        /// <param name="isInsert">是否插入数据</param>
        /// <returns></returns>
        private static Campus ConvertToCampusEntity(long id, string oid, CampusInfo campus, bool isInsert = true)
        {
            var model = new Campus
            {
                Address = campus.Address,
                CollegeId = id,
                CollegeFK = oid,
                ZipCode = campus.ZipCode,
                Tel = campus.CampusTel,
                Name = campus.CampusName,
                IsEnabled = true
            };

            if (isInsert)
            {
                model.CreatedBy = "20171111111";
                model.CreatedName = "我是测试创建人";
            }
            else
            {
                model.ModifiedOn = DateTime.Now;
                model.ModifiedBy = "201712121212121";
                model.ModifiedName = "我是修改测试人";
            }

            return model;
        }

        /// <summary>
        /// View Model => Department Entity
        /// </summary>
        /// <param name="webModel">院系编辑页视图模型</param>
        /// <param name="isInsert">是否新增数据</param>
        /// <returns></returns>
        private static Department ConvertToDepartmentEntity(DepartmentEditViewModel webModel, bool isInsert = true)
        {
            var model = new Department
            {
                Address = webModel.Address,
                Weibo = webModel.Weibo,
                Wechat = webModel.Wechat,
                Tel = webModel.Tel,
                QQ = webModel.QQ,
                Name = webModel.Name,
                IsBranch = false,
                Email = webModel.Email,
                Introduction = webModel.Introduction,
                IsEnabled = webModel.IsEnabled
            };

            if (isInsert)
            {
                model.CreatedBy = "20171111111";
                model.CreatedName = "我是测试创建人";
            }
            else
            {
                model.ModifiedOn = DateTime.Now;
                model.ModifiedBy = "201712121212121";
                model.ModifiedName = "我是修改测试人";
            }

            return model;
        }

        #endregion
    }
}
