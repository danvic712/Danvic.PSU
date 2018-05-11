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
                return await context.Set<Building>().AsNoTracking().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
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
        /// 根据搜索条件获取宿舍楼列表数目
        /// </summary>
        /// <param name="webModel">宿舍楼列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(BuildingViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SId) && webModel.SType == 0 && webModel.SEnable == 9)
            {
                var list = await context.Set<Building>().AsNoTracking().OrderByDescending(i => i.CreatedOn).ToListAsync();
                return list.Count();
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

                var list = await buildings.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
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
                CreatedBy = CurrentUser.UserOID,
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
            model.ModifiedBy = CurrentUser.UserOID;
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
            var model = await context.Building.AsNoTracking().Where(i => i.Id == id).FirstOrDefaultAsync();
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
                return await context.Set<Bunk>().AsNoTracking().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
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
        /// 根据搜索条件获取宿舍类型列表数目
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(BunkViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SDirection) && webModel.SEnable == -1)
            {
                var list = await context.Set<Bunk>().AsNoTracking().OrderByDescending(i => i.CreatedOn).ToListAsync();
                return list.Count();
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

                var list = await bunks.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
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
                IsEnabled = (int)webModel.IsEnabled == 1,
                ImageSrc = webModel.ImageSrc,
                Name = webModel.Name,
                Number = webModel.Number,
                Toward = webModel.Toward.ToString(),
                CreatedId = CurrentUser.UserId,
                CreatedBy = CurrentUser.UserOID,
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

            model.IsEnabled = (int)webModel.IsEnabled == 1;
            model.ImageSrc = webModel.ImageSrc;
            model.Name = webModel.Name;
            model.Number = webModel.Number;
            model.Toward = webModel.Toward.ToString();
            model.ModifiedOn = DateTime.Now;
            model.ModifiedId = CurrentUser.UserId;
            model.ModifiedBy = CurrentUser.UserOID;
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
            var model = await context.Bunk.AsNoTracking().Where(i => i.Id == id).FirstOrDefaultAsync();
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
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SType) && webModel.SFloor == -1)
            {
                return await context.Set<Dorm>().AsNoTracking().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
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
                if (!string.IsNullOrEmpty(webModel.SType))
                {
                    predicate = predicate.And(i => i.BunkName == webModel.SType);
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
        /// 根据搜索条件获取寝室列表数目
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(InformationViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SType) && webModel.SFloor == -1)
            {
                var list = await context.Set<Dorm>().AsNoTracking().OrderByDescending(i => i.CreatedOn).ToListAsync();
                return list.Count();
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
                if (!string.IsNullOrEmpty(webModel.SType))
                {
                    predicate = predicate.And(i => i.BunkName == webModel.SType);
                }

                //宿舍楼是否启用
                if (webModel.SFloor != -1)
                {
                    predicate = predicate.And(i => i.Floor == webModel.SFloor);
                }

                var list = await dorms.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
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
            //Get Foreign Key Association Table Information
            //
            var building = await context.Building.AsNoTracking().Where(i => i.Id == Convert.ToInt64(webModel.BuildingId)).FirstOrDefaultAsync();
            var bunk = await context.Bunk.AsNoTracking().Where(i => i.Id == Convert.ToInt64(webModel.BunkId)).FirstOrDefaultAsync();

            //return error 
            if (building == null || bunk == null)
            {
                return new Dorm
                {
                    Id = -1
                };
            }

            Dorm model = InsertModel(webModel);

            model.BuildingFK = building.BuildingOID;
            model.BuildingId = Convert.ToInt64(webModel.BuildingId);
            model.BuildingName = building.Name;
            model.Type = building.Type;

            model.BunkFK = bunk.BunkOID;
            model.BunkId = Convert.ToInt64(webModel.BunkId);
            model.BunkName = bunk.Name;

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

            UpdateModel(webModel, model);

            //Get Foreign Key Association Table Information
            //
            var building = await context.Building.AsNoTracking().Where(i => i.Id == Convert.ToInt64(webModel.BuildingId)).FirstOrDefaultAsync();
            var bunk = await context.Bunk.AsNoTracking().Where(i => i.Id == Convert.ToInt64(webModel.BunkId)).FirstOrDefaultAsync();

            //return error 
            if (building == null || bunk == null)
            {
                return;
            }

            model.BuildingFK = building.BuildingOID;
            model.BuildingId = Convert.ToInt64(webModel.BuildingId);
            model.BuildingName = building.Name;
            model.Type = building.Type;

            model.BunkFK = bunk.BunkOID;
            model.BunkId = Convert.ToInt64(webModel.BunkId);
            model.BunkName = bunk.Name;
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

        /// <summary>
        /// Insert Dorm Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        private static Dorm InsertModel(InformationEditViewModel webModel)
        {
            return new Dorm
            {
                Count = webModel.Count,
                CreatedId = CurrentUser.UserId,
                Floor = webModel.Floor,
                SelectedCount = 0,
                Name = webModel.Name,
                IsEnabled = (int)webModel.IsEnabled == 1,
                CreatedBy = CurrentUser.UserOID,
                CreatedName = CurrentUser.UserName
            };
        }

        /// <summary>
        /// Update Dorm Entity
        /// </summary>
        /// <param name="webModel"></param>
        /// <param name="model"></param>
        private static void UpdateModel(InformationEditViewModel webModel, Dorm model)
        {
            model.Count = webModel.Count;
            model.Floor = webModel.Floor;
            model.IsEnabled = (int)webModel.IsEnabled == 1;
            model.Name = webModel.Name;
            model.ModifiedOn = DateTime.Now;
            model.ModifiedId = CurrentUser.UserId;
            model.ModifiedBy = CurrentUser.UserOID;
            model.ModifiedName = CurrentUser.UserName;
        }

        /// <summary>
        /// 获取寝室楼下拉
        /// </summary>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Building>> GetBuildingList(ApplicationDbContext context)
        {
            return await context.Building.AsNoTracking().Where(i => i.IsEnabled == true).ToListAsync();
        }

        /// <summary>
        /// 获取寝室类型下拉
        /// </summary>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Bunk>> GetBunkList(ApplicationDbContext context)
        {
            return await context.Bunk.AsNoTracking().Where(i => i.IsEnabled == true).ToListAsync();
        }

        #endregion
    }
}
