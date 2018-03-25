//-----------------------------------------------------------------------
// <copyright file= "HomeRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/27 星期二 16:28:03
// Modified by:
// Description: Administrator-Home-首页功能实现仓储
//-----------------------------------------------------------------------
using LinqKit;
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSU.Entity.Admission;
using PSU.Utility.Web;

namespace PSU.Repository.Areas.Administrator
{
    public class HomeRepository
    {
        #region Index API

        /// <summary>
        /// 获取折线图Json字符串数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<string> GetChartInfo(ApplicationDbContext context)
        {
            //Data Source
            var list = await context.Register.ToListAsync();

            //Get Last 7 Day Date
            var now = DateTime.Now;
            var week = Enumerable.Range(-6, 7)
                .Select(x => new
                {
                    day = now.AddDays(x)
                });

            //Get Result Data
            var result = week.GroupJoin(list,
                w => new
                {
                    day = w.day.ToString("yyyy-MM-dd")
                },
                data => new
                {
                    day = data.DateTime.ToString("yyyy-MM-dd")
                },
                (p, g) => new
                {
                    day = p.day.ToString("yyyy-MM-dd"),
                    count = g.Count()
                }
                );

            return JsonUtility.ToJson(result);
        }

        /// <summary>
        /// 获取饼图Json字符串数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<string> GetPieInfo(ApplicationDbContext context)
        {
            //Data Source
            var list = await context.Student.ToListAsync();
            //Get Result Data
            var result = "";
            return JsonUtility.ToJson(result);
        }

        /// <summary>
        /// 获取今日报名人数
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static int GetTodayEnrollmentCount(ApplicationDbContext context)
        {
            return context.Register.Select(i => i.DateTime.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd")).ToList().Count();
        }

        /// <summary>
        /// 获取昨日报名人数
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static int GetYesterdayEnrollmentCount(ApplicationDbContext context)
        {
            return context.Register.Select(i => i.DateTime.ToString("yyyyMMdd") == DateTime.Now.AddDays(-1).ToString("yyyyMMdd")).ToList().Count();
        }

        /// <summary>
        /// 获取问题总数
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static int GetQuestionCount(ApplicationDbContext context)
        {
            return context.Question.ToList().Count();
        }

        /// <summary>
        /// 获取已完成报名比例
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static double GetProportion(ApplicationDbContext context)
        {
            if (context.Student.ToList().Count() != 0)
            {
                return Convert.ToDouble((context.Register.ToList().Count() / context.Student.ToList().Count()) * 100);
            }
            return 0;
        }

        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<List<Bulletin>> GetBulletinList(ApplicationDbContext context)
        {
            return await context.Bulletin.OrderByDescending(i => i.CreatedOn).Take(5).ToListAsync();
        }

        /// <summary>
        /// 获取问题列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<List<Question>> GetQuestionList(ApplicationDbContext context)
        {
            return await context.Question.OrderByDescending(i => i.AskTime).Take(5).ToListAsync();
        }

        #endregion

        #region Bulletin API

        /// <summary>
        /// 删除公告数据
        /// </summary>
        /// <param name="id">公告编号</param>
        /// <param name="context">数据库上下文对象</param>
        public static async Task DeleteAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Bulletin.SingleOrDefaultAsync(i => i.Id == id);

            context.Remove(model);
        }

        /// <summary>
        /// 获取公告信息
        /// </summary>
        /// <param name="id">公告编号</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Bulletin> GetEntityAsync(long id, ApplicationDbContext context)
        {
            var model = await context.Bulletin.Where(i => i.Id == id).SingleOrDefaultAsync();
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
                return await context.Set<Bulletin>().Skip(start).Take(limit).OrderByDescending(i => i.CreatedOn).ToListAsync();
            var bulletins = context.Bulletin.AsQueryable();

            var predicate = PredicateBuilder.New<Bulletin>();

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

        /// <summary>
        /// 新增公告数据
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="target">针对用户</param>
        /// <param name="type">公告类型</param>
        /// <param name="content">公告内容</param>
        /// <param name="context">数据库上下文对象</param>
        /// <returns></returns>
        public static async Task<Bulletin> InsertAsync(string title, short target, short type, string content, ApplicationDbContext context)
        {
            var model = new Bulletin
            {
                Title = title,
                Content = content,
                Type = type,
                Target = target,
                CreatedBy = "20180202124532",
                CreatedName = "测试用户姓名"
            };

            await context.Bulletin.AddAsync(model);

            return model;
        }
        /// <summary>
        /// 更新公告数据
        /// </summary>
        /// <param name="id">公告编号</param>
        /// <param name="title">标题</param>
        /// <param name="target">针对用户</param>
        /// <param name="type">类型</param>
        /// <param name="content">内容</param>
        /// <param name="context">数据库上下文对象</param>
        public static async void UpdateAsync(long id, string title, short target, short type, string content, ApplicationDbContext context)
        {
            var model = await context.Bulletin.SingleOrDefaultAsync(i => i.Id == id);

            if (model == null)
            {
                return;
            }

            model.Title = title;
            model.Target = target;
            model.Type = type;
            model.Content = content;
            model.ModifiedBy = "20181234567";
            model.ModifiedName = "我是修改人姓名";
            model.ModifiedOn = DateTime.Now;
        }
        #endregion
    }
}
