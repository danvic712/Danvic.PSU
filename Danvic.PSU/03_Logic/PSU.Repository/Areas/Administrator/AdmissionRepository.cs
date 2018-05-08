//-----------------------------------------------------------------------
// <copyright file= "AdmissionRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/2 星期一 15:11:50
// Modified by:
// Description: Administrator-Admission-功能实现仓储
//-----------------------------------------------------------------------
using LinqKit;
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.Admission;
using PSU.Model.Areas.Administrator.Admission;
using PSU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Repository.Areas.Administrator
{
    public class AdmissionRepository
    {
        #region Service API

        /// <summary>
        /// 删除迎新服务信息
        /// </summary>
        /// <param name="id">院系编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task DeleteServiceAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Service.FirstOrDefaultAsync(i => i.Id == id);

            context.Remove(model);
        }

        /// <summary>
        /// 获取迎新服务信息
        /// </summary>
        /// <param name="id">问题编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Service> GetServiceAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Service.AsNoTracking().Where(i => i.Id == id).FirstOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 根据搜索条件获取迎新服务信息
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Service>> GetListAsync(ServiceViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SAddress) && string.IsNullOrEmpty(webModel.SDate))
            {
                return await context.Set<Service>().AsNoTracking().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                IQueryable<Service> services = context.Service.AsQueryable();

                var predicate = PredicateBuilder.New<Service>();

                //迎新服务名称
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //迎新服务地点
                if (!string.IsNullOrEmpty(webModel.SAddress))
                {
                    predicate = predicate.And(i => i.Address == webModel.SAddress);
                }

                //迎新服务时间
                if (!string.IsNullOrEmpty(webModel.SDate))
                {
                    predicate = predicate.And(i => i.StartTime <= Convert.ToDateTime(webModel.SDate) && i.EndTime >= Convert.ToDateTime(webModel.SDate));
                }

                return await services.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 根据搜索条件获取迎新服务信息列表数目
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(ServiceViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SAddress) && string.IsNullOrEmpty(webModel.SDate))
            {
                var list = await context.Set<Service>().AsNoTracking().OrderByDescending(i => i.CreatedOn).ToListAsync();
                return list.Count();
            }
            else
            {
                IQueryable<Service> services = context.Service.AsQueryable();

                var predicate = PredicateBuilder.New<Service>();

                //迎新服务名称
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //迎新服务地点
                if (!string.IsNullOrEmpty(webModel.SAddress))
                {
                    predicate = predicate.And(i => i.Address == webModel.SAddress);
                }

                //迎新服务时间
                if (!string.IsNullOrEmpty(webModel.SDate))
                {
                    predicate = predicate.And(i => i.StartTime <= Convert.ToDateTime(webModel.SDate) && i.EndTime >= Convert.ToDateTime(webModel.SDate));
                }

                var list = await services.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
            }
        }

        /// <summary>
        /// 新增院系信息
        /// </summary>
        /// <param name="webModel">院系编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Service> InsertAsync(ServiceEditViewModel webModel, ApplicationDbContext context)
        {
            Service model = InsertModel(webModel);

            await context.Service.AddAsync(model);

            return model;
        }

        /// <summary>
        /// 更新院系信息
        /// </summary>
        /// <param name="webModel">院系编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateAsync(ServiceEditViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.Service.FirstOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));

            if (model == null)
            {
                return;
            }

            model = UpdateModel(webModel, model);
        }

        #endregion

        #region Goods API

        /// <summary>
        /// 删除物品信息
        /// </summary>
        /// <param name="id">物品编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task DeleteGoodsAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Goods.FirstOrDefaultAsync(i => i.Id == id);

            context.Remove(model);
        }

        /// <summary>
        /// 根据搜索条件获取物品信息
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Goods>> GetListAsync(GoodsViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SId) && webModel.SEnable == -1)
            {
                return await context.Set<Goods>().AsNoTracking().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                IQueryable<Goods> goods = context.Goods.AsQueryable();

                var predicate = PredicateBuilder.New<Goods>();

                //物品名称
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //物品编号
                if (!string.IsNullOrEmpty(webModel.SId))
                {
                    predicate = predicate.And(i => i.Id == Convert.ToInt64(webModel.SId));
                }

                //是否启用
                if (webModel.SEnable != -1)
                {
                    bool flag = webModel.SEnable == 1;
                    predicate = predicate.And(i => i.IsEnabled == flag);
                }

                return await goods.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 根据搜索条件获取物品信息列表数目
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(GoodsViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SName) && string.IsNullOrEmpty(webModel.SId) && webModel.SEnable == -1)
            {
                var list = await context.Set<Goods>().AsNoTracking().OrderByDescending(i => i.CreatedOn).ToListAsync();
                return list.Count();
            }
            else
            {
                IQueryable<Goods> goods = context.Goods.AsQueryable();

                var predicate = PredicateBuilder.New<Goods>();

                //物品名称
                if (!string.IsNullOrEmpty(webModel.SName))
                {
                    predicate = predicate.And(i => i.Name == webModel.SName);
                }

                //物品编号
                if (!string.IsNullOrEmpty(webModel.SId))
                {
                    predicate = predicate.And(i => i.Id == Convert.ToInt64(webModel.SId));
                }

                //是否启用
                if (webModel.SEnable != -1)
                {
                    bool flag = webModel.SEnable == 1;
                    predicate = predicate.And(i => i.IsEnabled == flag);
                }

                var list = await goods.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
            }
        }

        /// <summary>
        /// 获取物品信息
        /// </summary>
        /// <param name="id">物品编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Goods> GetGoodsAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Goods.AsNoTracking().Where(i => i.Id == id).FirstOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 新增物品信息
        /// </summary>
        /// <param name="webModel">编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Goods> InsertAsync(GoodsEditViewModel webModel, ApplicationDbContext context)
        {
            Goods model = InsertModel(webModel);

            await context.Goods.AddAsync(model);

            return model;
        }

        /// <summary>
        /// 更新物品信息
        /// </summary>
        /// <param name="webModel">编辑页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateAsync(GoodsEditViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.Goods.FirstOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));

            if (model == null)
            {
                return;
            }

            model = UpdateModel(webModel, model);
        }

        #endregion

        #region Question API

        /// <summary>
        /// 获取提问信息
        /// </summary>
        /// <param name="id">问题编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Question> GetQuestionAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Question.AsNoTracking().Where(i => i.Id == id).FirstOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 根据学生疑问信息搜索数据
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Question>> GetListAsync(QuestionViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SAskFor) && string.IsNullOrEmpty(webModel.SDateTime) && webModel.IsReply == -1)
            {
                return await context.Set<Question>().AsNoTracking().Skip(webModel.Start).Take(webModel.Limit).OrderByDescending(i => i.AskTime).ToListAsync();
            }
            else
            {
                IQueryable<Question> questions = context.Question.AsQueryable();

                var predicate = PredicateBuilder.New<Question>();

                //提问对象姓名
                if (!string.IsNullOrEmpty(webModel.SAskFor))
                {
                    predicate = predicate.And(i => i.AskForName.Contains(webModel.SAskFor));
                }

                //提问时间
                if (!string.IsNullOrEmpty(webModel.SDateTime))
                {
                    predicate = predicate.And(i => i.AskTime.ToString("yyyy-MM-dd") == webModel.SDateTime);
                }

                //是否回复
                if (webModel.IsReply != -1)
                {
                    bool flag = webModel.IsReply == 1;
                    predicate = predicate.And(i => i.IsReply == flag);
                }

                return await questions.AsExpandable().Where(predicate).ToListAsync();
            }
        }

        /// <summary>
        /// 根据学生疑问信息搜索数据列表数目
        /// </summary>
        /// <param name="webModel">列表页视图模型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(QuestionViewModel webModel, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(webModel.SAskFor) && string.IsNullOrEmpty(webModel.SDateTime) && webModel.IsReply == -1)
            {
                var list = await context.Set<Question>().AsNoTracking().OrderByDescending(i => i.AskTime).ToListAsync();
                return list.Count();
            }
            else
            {
                IQueryable<Question> questions = context.Question.AsQueryable();

                var predicate = PredicateBuilder.New<Question>();

                //提问对象姓名
                if (!string.IsNullOrEmpty(webModel.SAskFor))
                {
                    predicate = predicate.And(i => i.AskForName.Contains(webModel.SAskFor));
                }

                //提问时间
                if (!string.IsNullOrEmpty(webModel.SDateTime))
                {
                    predicate = predicate.And(i => i.AskTime.ToString("yyyy-MM-dd") == webModel.SDateTime);
                }

                //是否回复
                if (webModel.IsReply != -1)
                {
                    bool flag = webModel.IsReply == 1;
                    predicate = predicate.And(i => i.IsReply == flag);
                }

                var list = await questions.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
            }
        }

        /// <summary>
        /// 回复疑问信息
        /// </summary>
        /// <param name="webModel">疑问信息回复页视图Model</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void ReplyQuestionAsync(QuestionReplyViewModel webModel, ApplicationDbContext context)
        {
            var model = await context.Question.FirstOrDefaultAsync(i => i.Id == Convert.ToInt64(webModel.Id));

            if (model == null)
            {
                return;
            }

            //Update
            model.IsReply = true;
            model.ReplyContent = webModel.ReplyContent;
            model.ReplyFK = CurrentUser.UserOID;
            model.ReplyId = CurrentUser.UserId;
            model.ReplyName = CurrentUser.UserName;
            model.ReplyTime = DateTime.Now;
        }

        #endregion

        #region Method-Insert

        /// <summary>
        /// Insert Service Model
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        private static Service InsertModel(ServiceEditViewModel webModel)
        {
            return new Service
            {
                Address = webModel.Address,
                CreatedBy = CurrentUser.UserOID,
                CreatedId = CurrentUser.UserId,
                CreatedName = CurrentUser.UserName,
                Description = webModel.Description,
                EndTime = Convert.ToDateTime(webModel.EndTime),
                Name = webModel.Name,
                Place = webModel.Place,
                StartTime = Convert.ToDateTime(webModel.StartTime),
                IsEnabled = (int)webModel.IsEnabled == 1,
            };
        }

        /// <summary>
        /// Insert Goods Model
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        private static Goods InsertModel(GoodsEditViewModel webModel)
        {
            return new Goods
            {
                CreatedBy = CurrentUser.UserOID,
                CreatedId = CurrentUser.UserId,
                CreatedName = CurrentUser.UserName,
                Description = webModel.Description,
                Name = webModel.Name,
                ImageSrc = webModel.ImageSrc,
                Size = webModel.Size,
                IsEnabled = (int)webModel.IsEnabled == 1,
            };
        }

        #endregion

        #region Method-Update

        /// <summary>
        /// Update Service Model
        /// </summary>
        /// <param name="webModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private static Service UpdateModel(ServiceEditViewModel webModel, Service model)
        {
            model.Address = webModel.Address;
            model.Description = webModel.Description;
            model.EndTime = Convert.ToDateTime(webModel.EndTime);
            model.Name = webModel.Name;
            model.Place = webModel.Place;
            model.StartTime = Convert.ToDateTime(webModel.StartTime);
            model.IsEnabled = (int)webModel.IsEnabled == 1;
            model.ModifiedOn = DateTime.Now;
            model.ModifiedId = CurrentUser.UserId;
            model.ModifiedBy = CurrentUser.UserOID;
            model.ModifiedName = CurrentUser.UserName;

            return model;
        }

        /// <summary>
        /// Update Goods Model
        /// </summary>
        /// <param name="webModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private static Goods UpdateModel(GoodsEditViewModel webModel, Goods model)
        {
            model.Size = webModel.Size;
            model.ImageSrc = webModel.ImageSrc;
            model.Description = webModel.Description;
            model.Name = webModel.Name;
            model.IsEnabled = (int)webModel.IsEnabled == 1;
            model.ModifiedOn = DateTime.Now;
            model.ModifiedId = CurrentUser.UserId;
            model.ModifiedBy = CurrentUser.UserOID;
            model.ModifiedName = CurrentUser.UserName;

            return model;
        }

        #endregion
    }
}
