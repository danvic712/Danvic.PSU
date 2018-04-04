//-----------------------------------------------------------------------
// <copyright file= "DormitoryRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/23 星期五 16:58:27
// Modified by:
// Description: Administrator-Dormitory-首页功能实现仓储
//-----------------------------------------------------------------------
using LinqKit;
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.Dormitory;
using PSU.Model.Areas.Administrator.Dormitory;
using PSU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Repository.Areas.Administrator
{
    public class DormitoryRepository
    {
        #region Building API

        /// <summary>
        /// 删除宿舍楼数据
        /// </summary>
        /// <param name="id">宿舍楼编号</param>
        /// <param name="context">数据库上下文对象</param>
        public static async Task DeleteAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Building.FirstOrDefaultAsync(i => i.Id == id);

            context.Remove(model);
        }

        /// <summary>
        /// 根据搜索条件获取宿舍楼列表
        /// </summary>
        /// <param name="webModel">宿舍楼列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Building>> GetListAsync(BuildingViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SId) && webModel.SType == 0 && webModel.SEnable == 9)
            {
                return await context.Set<Building>().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                IQueryable<Building> buildings = context.Building.AsQueryable();

                var predicate = PredicateBuilder.New<Building>();

                //宿舍楼编号
                if (!string.IsNullOrEmpty(webModel.SId))
                {
                    predicate = predicate.And(i => i.Id == Convert.ToInt64(webModel.SId));
                }

                //宿舍楼类型
                if (webModel.SType != 0)
                {
                    predicate = predicate.And(i => i.Type == webModel.SType);
                }

                //宿舍楼是否启用
                if (webModel.SEnable != 9)
                {
                    bool flag = webModel.SEnable == 1;
                    predicate = predicate.And(i => i.IsEnabled == flag);
                }

                return await buildings.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 新增寝室楼信息
        /// </summary>
        /// <param name="webModel">编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Building> InsertAsync(BuildingEditViewModel webModel, ApplicationDbContext context)
        {
            var model = new Building
            {
                Name = webModel.Name,
                Floor = webModel.Floor,
                Type = Convert.ToInt16(webModel.Type),
                IsEnabled = (int)webModel.IsEnabled == 1,
                CreatedBy = CurrentUser.UserId,
                CreatedName = CurrentUser.UserName
            };
            await context.Building.AddAsync(model);

            return model;
        }

        /// <summary>
        /// 更新寝室楼信息
        /// </summary>
        /// <param name="webModel">编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateAsync(BuildingEditViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.Building.FirstOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));

            if (model == null)
            {
                return;
            }

            model.Name = webModel.Name;
            model.Floor = webModel.Floor;
            model.Type = Convert.ToInt16(webModel.Type);
            model.IsEnabled = (int)webModel.IsEnabled == 1;
            model.ModifiedOn = DateTime.Now;
            model.ModifiedBy = CurrentUser.UserId;
            model.ModifiedName = CurrentUser.UserName;
        }

        /// <summary>
        /// 获取寝室楼信息
        /// </summary>
        /// <param name="id">寝室楼编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Building> GetBuildingAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Building.Where(i => i.Id == id).FirstOrDefaultAsync();
            return model;
        }

        #endregion

        #region Bunk

        /// <summary>
        /// 删除宿舍类型数据
        /// </summary>
        /// <param name="id">宿舍类型编号</param>
        /// <param name="context">数据库上下文对象</param>
        public static async Task DeleteBunkAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Bunk.FirstOrDefaultAsync(i => i.Id == id);

            context.Remove(model);
        }

        /// <summary>
        /// 根据搜索条件获取宿舍类型列表
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Bunk>> GetListAsync(BunkViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SDirection) && webModel.SEnable == -1)
            {
                return await context.Set<Bunk>().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                IQueryable<Bunk> bunks = context.Bunk.AsQueryable();

                var predicate = PredicateBuilder.New<Bunk>();

                //宿舍类型名称
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //宿舍朝向
                if (!string.IsNullOrEmpty(webModel.SDirection))
                {
                    predicate = predicate.And(i => i.Toward == webModel.SDirection);
                }

                //宿舍类型是否启用
                if (webModel.SEnable != -1)
                {
                    bool flag = webModel.SEnable == 1;
                    predicate = predicate.And(i => i.IsEnabled == flag);
                }

                return await bunks.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 新增宿舍类型信息
        /// </summary>
        /// <param name="webModel">编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Bunk> InsertAsync(BunkEditViewModel webModel, ApplicationDbContext context)
        {
            var model = new Bunk
            {
                CreatedBy = CurrentUser.UserId,
                CreatedName = CurrentUser.UserName
            };
            await context.Bunk.AddAsync(model);

            return model;
        }

        /// <summary>
        /// 更新宿舍类型信息
        /// </summary>
        /// <param name="webModel">编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateAsync(BunkEditViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.Bunk.FirstOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));

            if (model == null)
            {
                return;
            }

            model.ModifiedOn = DateTime.Now;
            model.ModifiedBy = CurrentUser.UserId;
            model.ModifiedName = CurrentUser.UserName;
        }

        /// <summary>
        /// 获取宿舍类型信息
        /// </summary>
        /// <param name="id">宿舍类型编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Bunk> GetBunkAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Bunk.Where(i => i.Id == id).FirstOrDefaultAsync();
            return model;
        }

        #endregion

        #region Information API

        /// <summary>
        /// 删除宿舍数据
        /// </summary>
        /// <param name="id">宿舍编号</param>
        /// <param name="context">数据库上下文对象</param>
        public static async Task DeleteDormAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Dorm.FirstOrDefaultAsync(i => i.Id == id);

            context.Remove(model);
        }

        /// <summary>
        /// 根据搜索条件获取寝室列表
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Dorm>> GetListAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && webModel.SType == 0 && webModel.SFloor == -1)
            {
                return await context.Set<Dorm>().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                IQueryable<Dorm> dorms = context.Dorm.AsQueryable();

                var predicate = PredicateBuilder.New<Dorm>();

                //宿舍楼编号
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //宿舍楼类型
                if (webModel.SType != 0)
                {
                    predicate = predicate.And(i => i.Type == webModel.SType);
                }

                //宿舍楼是否启用
                if (webModel.SFloor != -1)
                {
                    predicate = predicate.And(i => i.Floor == webModel.SFloor);
                }

                return await dorms.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 新增寝室信息
        /// </summary>
        /// <param name="webModel">编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Dorm> InsertAsync(InformationEditViewModel webModel, ApplicationDbContext context)
        {
            var model = new Dorm
            {
                CreatedBy = CurrentUser.UserId,
                CreatedName = CurrentUser.UserName
            };
            await context.Dorm.AddAsync(model);

            return model;
        }

        /// <summary>
        /// 更新寝室信息
        /// </summary>
        /// <param name="webModel">编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateAsync(InformationEditViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.Dorm.FirstOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));

            if (model == null)
            {
                return;
            }

            model.ModifiedOn = DateTime.Now;
            model.ModifiedBy = CurrentUser.UserId;
            model.ModifiedName = CurrentUser.UserName;
        }

        /// <summary>
        /// 获取寝室信息
        /// </summary>
        /// <param name="id">寝室编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Dorm> GetDormAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Dorm.Where(i => i.Id == id).FirstOrDefaultAsync();
            return model;
        }

        #endregion

        #region Method
        #endregion
    }
}
