//-----------------------------------------------------------------------
// <copyright file= "HomeRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 20:00:45
// Modified by:
// Description: Student-Home-功能实现仓储
//-----------------------------------------------------------------------
using LinqKit;
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.Admission;
using PSU.Entity.Basic;
using PSU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSU.Repository.Areas.Student
{
    public class HomeRepository
    {
        #region  API-Init

        /// <summary>
        /// 获取同一城市的人
        /// </summary>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetSameCityCountAsync(ApplicationDbContext context)
        {
            var user = await PSURepository.GetUserByIdAsync(CurrentUser.UserId, context);
            return context.IdentityUser.AsNoTracking().Where(i => i.AccountType == 2 && i.CityId == user.CityId && i.Id != user.Id).ToList().Count();
        }

        /// <summary>
        /// 获取提问问题个数
        /// </summary>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static int GetQuestionCountAsync(ApplicationDbContext context)
        {
            return context.Question.AsNoTracking().Select(i => i.SId == CurrentUser.UserId).ToList().Count();
        }

        /// <summary>
        /// 获取未完成的报名事项
        /// </summary>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetTodoCountAsync(ApplicationDbContext context)
        {
            int index = 4;

            //报名信息
            var register = await context.Register.AsNoTracking().FirstOrDefaultAsync(i => i.StudentId == CurrentUser.UserId);
            if (register != null)
            {
                index--;
            }

            //预定服务
            var service = await context.ServiceInfo.AsNoTracking().FirstOrDefaultAsync(i => i.StudentId == CurrentUser.UserId);
            if (service != null)
            {
                index--;
            }

            //预定服务
            var goods = await context.GoodsInfo.AsNoTracking().FirstOrDefaultAsync(i => i.StudentId == CurrentUser.UserId);
            if (goods != null)
            {
                index--;
            }

            //预定服务
            var bunk = await context.BunkInfo.AsNoTracking().FirstOrDefaultAsync(i => i.StudentId == CurrentUser.UserId);
            if (bunk != null)
            {
                index--;
            }

            return index;
        }

        /// <summary>
        /// 获取班级人数
        /// </summary>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetClassCountAsync(ApplicationDbContext context)
        {
            var user = await PSURepository.GetUserByIdAsync(CurrentUser.UserId, context);
            return context.IdentityUser.AsNoTracking().Select(i => i.MajorClassId == user.MajorClassId).ToList().Count();
        }

        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<Bulletin> GetBulletinInfo(ApplicationDbContext context)
        {
            return await context.Bulletin.AsNoTracking().Where(i => i.Target == 1 || i.Target == 3).OrderByDescending(i => i.CreatedOn).FirstOrDefaultAsync();
        }

        #endregion

        #region API-Ask

        /// <summary>
        /// 新增提问信息
        /// </summary>
        /// <param name="content">提问内容</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Question> InsertAsync(string content, ApplicationDbContext context)
        {
            var user = await PSURepository.GetUserByIdAsync(CurrentUser.UserId, context);
            var instructor = await PSURepository.GetUserByIdAsync(user.InstructorId, context);

            if (user == null || instructor == null)
            {
                return new Question
                {
                    Id = -1
                };
            }

            Question model = InsertModel(user, instructor, content);

            await context.Question.AddAsync(model);

            return model;
        }

        #endregion

        #region API-Bulletin

        /// <summary>
        /// 获取公告信息
        /// </summary>
        /// <param name="id">公告编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Bulletin> GetEntityAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Bulletin.AsNoTracking().Where(i => i.Id == id).FirstOrDefaultAsync();
            return model;
        }

        /// <summary>
        /// 根据搜索条件获取公告列表
        /// </summary>
        /// <param name="limit">每页显示条数</param>
        /// <param name="page">当前页</param>
        /// <param name="start">每页开始记录条数</param>
        /// <param name="title">公告标题</param>
        /// <param name="datetime">发布日期</param>
        /// <param name="type">公告类型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<List<Bulletin>> GetListAsync(int limit, int page, int start, string title, string datetime, short type, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(datetime) && type == 0)
            {
                return await context.Set<Bulletin>().AsNoTracking().Where(i => i.Target == 1 || i.Target == 3).Skip(start).Take(limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            }
            else
            {
                var bulletins = context.Bulletin.AsQueryable();

                var predicate = PredicateBuilder.New<Bulletin>();

                //针对学生用户
                predicate = predicate.And(i => i.Target == 1 || i.Target == 3);

                if (!string.IsNullOrEmpty(title))
                {
                    predicate = predicate.And(i => i.Title.Contains(title.Trim()));
                }

                if (!string.IsNullOrEmpty(datetime))
                {
                    predicate = predicate.And(i => i.CreatedOn.ToString("yyyy-MM-dd").Equals(datetime));
                }

                if (type != 0)
                {
                    predicate = predicate.And(i => i.Type == type);
                }

                return await bulletins.AsExpandable().Where(predicate).ToListAsync();
            }

        }

        /// <summary>
        /// 根据搜索条件获取公告列表数目
        /// </summary>
        /// <param name="limit">每页显示条数</param>
        /// <param name="page">当前页</param>
        /// <param name="start">每页开始记录条数</param>
        /// <param name="title">公告标题</param>
        /// <param name="datetime">发布日期</param>
        /// <param name="type">公告类型</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<int> GetListCountAsync(int limit, int page, int start, string title, string datetime, short type, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(datetime) && type == 0)
            {
                var list = await context.Set<Bulletin>().AsNoTracking().Where(i => i.Target == 1 || i.Target == 3).OrderByDescending(i => i.CreatedOn).ToListAsync();
                return list.Count();
            }
            else
            {
                var bulletins = context.Bulletin.AsQueryable();

                var predicate = PredicateBuilder.New<Bulletin>();

                //针对学生用户
                predicate = predicate.And(i => i.Target == 1 || i.Target == 3);

                if (!string.IsNullOrEmpty(title))
                {
                    predicate = predicate.And(i => i.Title.Contains(title.Trim()));
                }

                if (!string.IsNullOrEmpty(datetime))
                {
                    predicate = predicate.And(i => i.CreatedOn.ToString("yyyy-MM-dd").Equals(datetime));
                }

                if (type != 0)
                {
                    predicate = predicate.And(i => i.Type == type);
                }

                var list = await bulletins.AsExpandable().Where(predicate).ToListAsync();
                return list.Count();
            }
        }

        #endregion

        #region Method-Insert

        /// <summary>
        /// Insert Question Entity
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private static Question InsertModel(IdentityUser user, IdentityUser instructor, string content)
        {
            return new Question
            {
                AskForFK = instructor.IdentityUserOID,
                AskForId = instructor.Id,
                AskForName = instructor.Name,
                AskTime = DateTime.Now,
                Content = content,
                IsReply = false,
                SId = user.Id,
                StudentFK = user.IdentityUserOID,
                StuName = user.Name
            };
        }

        #endregion
    }
}
