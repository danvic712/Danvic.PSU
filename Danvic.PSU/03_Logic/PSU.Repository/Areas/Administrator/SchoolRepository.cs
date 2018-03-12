//-----------------------------------------------------------------------
// <copyright file= "SchoolRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-11 20:59:20
// Modified by:
// Description: Administrator-School-首页功能实现仓储
//-----------------------------------------------------------------------
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
            var list = await context.Campus.Where(i => i.CollegeId == Convert.ToInt64(webModel.Id)).ToListAsync();

            if (list != null && list.Any())
            {
                foreach (var item in list)
                {
                    var model = webModel.CampusList.SingleOrDefault(i => i.Id == item.Id.ToString());
                }
            }
        }

        #endregion

        #region Department API



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

        #endregion
    }
}
