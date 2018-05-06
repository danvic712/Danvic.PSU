//-----------------------------------------------------------------------
// <copyright file= "StatisticsRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-04-02 21:24:00
// Modified by:
// Description: Administrator-Statistics-功能实现仓储
//-----------------------------------------------------------------------
using LinqKit;
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.SignUp;
using PSU.Model.Areas.Administrator.Statistics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Repository.Areas.Administrator
{
    public class StatisticsRepository
    {
        #region Register API

        /// <summary>
        /// 根据搜索条件获取新生报名信息
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Register>> GetListAsync(RegisterViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SMajorClass) && string.IsNullOrEmpty(webModel.SDate))
            {
                return await context.Set<Register>().AsNoTracking().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.DateTime).ToListAsync();
            }
            else
            {
                IQueryable<Register> registers = context.Register.AsQueryable();

                var predicate = PredicateBuilder.New<Register>();

                //学生姓名
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //专业班级名称
                if (!string.IsNullOrEmpty(webModel.SMajorClass))
                {
                    predicate = predicate.And(i => i.MajorClass.Contains(webModel.SMajorClass));
                }

                //预计到校时间
                if (!string.IsNullOrEmpty(webModel.SDate))
                {
                    predicate = predicate.And(i => i.ArriveTime.ToString("yyyy-MM-dd") == webModel.SDate);
                }

                return await registers.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 根据搜索条件获取新生报名信息列表数目
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(RegisterViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SMajorClass) && string.IsNullOrEmpty(webModel.SDate))
            {
                var list = await context.Set<Register>().AsNoTracking().OrderByDescending(i => i.DateTime).ToListAsync();
                return list.Count();
            }
            else
            {
                IQueryable<Register> registers = context.Register.AsQueryable();

                var predicate = PredicateBuilder.New<Register>();

                //学生姓名
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //专业班级名称
                if (!string.IsNullOrEmpty(webModel.SMajorClass))
                {
                    predicate = predicate.And(i => i.MajorClass.Contains(webModel.SMajorClass));
                }

                //预计到校时间
                if (!string.IsNullOrEmpty(webModel.SDate))
                {
                    predicate = predicate.And(i => i.ArriveTime.ToString("yyyy-MM-dd") == webModel.SDate);
                }

                var list = await registers.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
            }
        }

        #endregion

        #region Goods API

        /// <summary>
        /// 根据搜索条件获取物品预定信息
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<GoodsInfo>> GetListAsync(GoodsViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SGoodsName) && string.IsNullOrEmpty(webModel.SDate))
            {
                return await context.Set<GoodsInfo>().AsNoTracking().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.ChosenTime).ToListAsync();
            }
            else
            {
                IQueryable<GoodsInfo> goodsInfos = context.GoodsInfo.AsQueryable();

                var predicate = PredicateBuilder.New<GoodsInfo>();

                //学生姓名
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.StudentName == webModel.SName);
                }

                //物品名称
                if (!string.IsNullOrEmpty(webModel.SGoodsName))
                {
                    predicate = predicate.And(i => i.GoodsName.Contains(webModel.SGoodsName));
                }

                //物品选择时间
                if (!string.IsNullOrEmpty(webModel.SDate))
                {
                    predicate = predicate.And(i => i.ChosenTime.ToString("yyyy-MM-dd") == webModel.SDate);
                }

                return await goodsInfos.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 根据搜索条件获取物品预定信息列表数目
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(GoodsViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SGoodsName) && string.IsNullOrEmpty(webModel.SDate))
            {
                var list = await context.Set<GoodsInfo>().AsNoTracking().OrderByDescending(i => i.ChosenTime).ToListAsync();
                return list.Count();
            }
            else
            {
                IQueryable<GoodsInfo> goodsInfos = context.GoodsInfo.AsQueryable();

                var predicate = PredicateBuilder.New<GoodsInfo>();

                //学生姓名
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.StudentName == webModel.SName);
                }

                //物品名称
                if (!string.IsNullOrEmpty(webModel.SGoodsName))
                {
                    predicate = predicate.And(i => i.GoodsName.Contains(webModel.SGoodsName));
                }

                //物品选择时间
                if (!string.IsNullOrEmpty(webModel.SDate))
                {
                    predicate = predicate.And(i => i.ChosenTime.ToString("yyyy-MM-dd") == webModel.SDate);
                }

                var list = await goodsInfos.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
            }
        }

        #endregion

        #region Dormitory API

        /// <summary>
        /// 根据搜索条件获取物品预定信息
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<BunkInfo>> GetListAsync(DormitoryViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SBuilding) && string.IsNullOrEmpty(webModel.SStudent))
            {
                return await context.Set<BunkInfo>().AsNoTracking().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.DateTime).ToListAsync();
            }
            else
            {
                IQueryable<BunkInfo> bunkInfos = context.BunkInfo.AsQueryable();

                var predicate = PredicateBuilder.New<BunkInfo>();

                //宿舍名称
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.DormName == webModel.SName);
                }

                //宿舍楼名称
                if (!string.IsNullOrEmpty(webModel.SBuilding))
                {
                    predicate = predicate.And(i => i.BuildingName.Contains(webModel.SBuilding));
                }

                //学生姓名
                if (!string.IsNullOrEmpty(webModel.SStudent))
                {
                    predicate = predicate.And(i => i.StudentName.Contains(webModel.SStudent));
                }

                return await bunkInfos.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 根据搜索条件获取物品预定信息列表数目
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(DormitoryViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SBuilding) && string.IsNullOrEmpty(webModel.SStudent))
            {
                var list = await context.Set<BunkInfo>().AsNoTracking().OrderByDescending(i => i.DateTime).ToListAsync();
                return list.Count();
            }
            else
            {
                IQueryable<BunkInfo> bunkInfos = context.BunkInfo.AsQueryable();

                var predicate = PredicateBuilder.New<BunkInfo>();

                //宿舍名称
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.DormName == webModel.SName);
                }

                //宿舍楼名称
                if (!string.IsNullOrEmpty(webModel.SBuilding))
                {
                    predicate = predicate.And(i => i.BuildingName.Contains(webModel.SBuilding));
                }

                //学生姓名
                if (!string.IsNullOrEmpty(webModel.SStudent))
                {
                    predicate = predicate.And(i => i.StudentName.Contains(webModel.SStudent));
                }

                var list = await bunkInfos.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
            }
        }

        #endregion

        #region Book API

        /// <summary>
        /// 根据搜索条件获取服务预定信息
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<ServiceInfo>> GetListAsync(BookViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SStudent) && string.IsNullOrEmpty(webModel.SDate))
            {
                return await context.Set<ServiceInfo>().AsNoTracking().Where(i => i.IsCancel == false).Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.ScheduledTime).ToListAsync();
            }
            else
            {
                IQueryable<ServiceInfo> serviceInfos = context.ServiceInfo.AsQueryable();

                var predicate = PredicateBuilder.New<ServiceInfo>();

                //迎新服务名称
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.ServiceName == webModel.SName);
                }

                //学生姓名
                if (!string.IsNullOrEmpty(webModel.SStudent))
                {
                    predicate = predicate.And(i => i.Name.Contains(webModel.SStudent));
                }

                //预定日期
                if (!string.IsNullOrEmpty(webModel.SStudent))
                {
                    predicate = predicate.And(i => i.ScheduledTime.ToString("yyyy-MM-dd") == webModel.SDate);
                }

                return await serviceInfos.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 根据搜索条件获取服务预定信息列表数目
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(BookViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SStudent) && string.IsNullOrEmpty(webModel.SDate))
            {
                var list = await context.Set<ServiceInfo>().AsNoTracking().Where(i => i.IsCancel == false).OrderByDescending(i => i.ScheduledTime).ToListAsync();
                return list.Count();
            }
            else
            {
                IQueryable<ServiceInfo> serviceInfos = context.ServiceInfo.AsQueryable();

                var predicate = PredicateBuilder.New<ServiceInfo>();

                //迎新服务名称
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.ServiceName == webModel.SName);
                }

                //学生姓名
                if (!string.IsNullOrEmpty(webModel.SStudent))
                {
                    predicate = predicate.And(i => i.Name.Contains(webModel.SStudent));
                }

                //预定日期
                if (!string.IsNullOrEmpty(webModel.SStudent))
                {
                    predicate = predicate.And(i => i.ScheduledTime.ToString("yyyy-MM-dd") == webModel.SDate);
                }

                var list = await serviceInfos.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
            }
        }

        /// <summary>
        /// 获取服务预定详细信息
        /// </summary>
        /// <param name="id">服务预定编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<ServiceInfo> GetEntityAsync(long id, ApplicationDbContext context)
        {
            var model = await context.ServiceInfo.AsNoTracking().Where(i => i.Id == id).FirstOrDefaultAsync();
            return model;
        }

        #endregion
    }
}
