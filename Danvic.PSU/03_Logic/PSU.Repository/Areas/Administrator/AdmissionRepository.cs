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
                    predicate = predicate.And(i => i.Place == webModel.SAddress);
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
                    predicate = predicate.And(i => i.Place == webModel.SAddress);
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

        #endregion

        #region Goods API

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
    }
}
