//-----------------------------------------------------------------------
// <copyright file= "HomeRepository.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:32:10
// Modified by:
// Description: Instructor-Home-功能实现仓储
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using PSU.EFCore;
using PSU.Entity.Admission;
using PSU.Entity.Basic;
using PSU.Model.Areas.Instructor.Home;
using PSU.Utility;
using PSU.Utility.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSU.Repository.Areas.Instructor
{
    public class HomeRepository
    {
        #region Index API

        /// <summary>
        /// 获取折线图数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<List<LineChartData>> GetChartInfo(ApplicationDbContext context)
        {
            //Data Source
            var list = await context.Register.AsNoTracking().Where(i => i.InstructorId == CurrentUser.UserId).ToListAsync();

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
                (p, g) => new LineChartData
                {
                    Day = p.day.ToString("yyyy-MM-dd"),
                    Count = g.Count()
                }
                ).ToList();

            return result;
        }

        /// <summary>
        /// 获取饼图Json字符串数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<List<PieData>> GetPieInfo(ApplicationDbContext context)
        {
            //Data Source
            var list = await context.Student.AsNoTracking().Where(i => i.InstructorId == CurrentUser.UserId).ToListAsync();

            //Get Result Data
            var result = list.GroupBy(i => new { i.ProvinceId, i.Province })
                .Select(i => new PieData
                {
                    Province = i.Key.Province,
                    Count = i.Count()
                }).ToList();
            return result;
        }

        /// <summary>
        /// 获取今日报名人数
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static int GetTodayEnrollmentCount(ApplicationDbContext context)
        {
            return context.Register.AsNoTracking().Where(i => i.InstructorId == CurrentUser.UserId).Select(i => i.DateTime.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd")).ToList().Count();
        }

        /// <summary>
        /// 获取昨日报名人数
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static int GetYesterdayEnrollmentCount(ApplicationDbContext context)
        {
            return context.Register.AsNoTracking().Where(i => i.InstructorId == CurrentUser.UserId).Select(i => i.DateTime.ToString("yyyyMMdd") == DateTime.Now.AddDays(-1).ToString("yyyyMMdd")).ToList().Count();
        }

        /// <summary>
        /// 获取问题总数
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static int GetQuestionCount(ApplicationDbContext context)
        {
            return context.Question.AsNoTracking().Where(i => i.AskForId == CurrentUser.UserId).ToList().Count();
        }

        /// <summary>
        /// 获取已完成报名比例
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static double GetProportion(ApplicationDbContext context)
        {
            if (context.Student.AsNoTracking().Where(i => i.InstructorId == CurrentUser.UserId).ToList().Count() != 0)
            {
                return Convert.ToDouble((context.Register.AsNoTracking().Where(i => i.InstructorId == CurrentUser.UserId).ToList().Count() / context.Student.AsNoTracking().Where(i => i.InstructorId == CurrentUser.UserId).ToList().Count()) * 100);
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
            return await context.Bulletin.AsNoTracking().Where(i => i.Target == 0 || i.Target == 1).OrderByDescending(i => i.CreatedOn).Take(5).ToListAsync();
        }

        /// <summary>
        /// 获取问题列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<List<Question>> GetQuestionList(ApplicationDbContext context)
        {
            return await context.Question.AsNoTracking().Where(i => i.AskForId == CurrentUser.UserId && i.IsReply == false).OrderByDescending(i => i.AskTime).Take(5).ToListAsync();
        }

        #endregion
    }
}
