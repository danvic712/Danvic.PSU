//-----------------------------------------------------------------------
// <copyright file= "ApplicationDbContext.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/11 星期日 13:38:54
// Modified by:
// Description: 数据库连接上下文
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using PSU.Entity.Admission;
using PSU.Entity.Basic;
using PSU.Entity.Dormitory;
using PSU.Entity.Identity;
using PSU.Entity.School;
using PSU.Entity.SignUp;

namespace PSU.EFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        #region Admission

        /// <summary>
        /// 物品信息表
        /// </summary>
        public virtual DbSet<Goods> Goods { get; set; }

        /// <summary>
        /// 学生提问表
        /// </summary>
        public virtual DbSet<Question> Question { get; set; }

        /// <summary>
        /// 迎新车辆服务表
        /// </summary>
        public virtual DbSet<Service> Service { get; set; }

        /// <summary>
        /// 金额信息表
        /// </summary>
        public virtual DbSet<Tuition> Tuition { get; set; }

        #endregion

        #region Basic

        /// <summary>
        /// 网站公告表
        /// </summary>
        public virtual DbSet<Bulletin> Bulletin { get; set; }

        /// <summary>
        /// 网站登录日志表
        /// </summary>
        public virtual DbSet<Logging> Logging { get; set; }

        /// <summary>
        /// 账号操作记录表
        /// </summary>
        public virtual DbSet<Record> Record { get; set; }

        /// <summary>
        /// 地区信息表
        /// </summary>
        public virtual DbSet<Region> Region { get; set; }

        /// <summary>
        /// 教职工信息表
        /// </summary>
        public virtual DbSet<Staff> Staff { get; set; }

        /// <summary>
        /// 学生信息表
        /// </summary>
        public virtual DbSet<Student> Student { get; set; }

        #endregion

        #region Dormitory

        /// <summary>
        /// 寝室楼信息表
        /// </summary>
        public virtual DbSet<Building> Building { get; set; }

        /// <summary>
        /// 床位信息表
        /// </summary>
        public virtual DbSet<Bunk> Bunk { get; set; }

        /// <summary>
        /// 校区信息表
        /// </summary>
        public virtual DbSet<Campus> Campus { get; set; }

        /// <summary>
        /// 寝室信息表
        /// </summary>
        public virtual DbSet<Dorm> Dorm { get; set; }

        #endregion

        #region Identity

        public virtual DbSet<AppUser> IdentityUser { get; set; }

        public virtual DbSet<AppRole> IdentityRole { get; set; }

        #endregion

        #region School

        /// <summary>
        /// 学校信息表
        /// </summary>
        public virtual DbSet<College> Collage { get; set; }

        /// <summary>
        /// 院系信息表
        /// </summary>
        public virtual DbSet<Department> Department { get; set; }

        /// <summary>
        /// 专业信息表
        /// </summary>
        public virtual DbSet<Major> Major { get; set; }

        /// <summary>
        /// 专业班级表
        /// </summary>
        public virtual DbSet<MajorClass> MajorClass { get; set; }

        #endregion

        #region SignUp

        /// <summary>
        /// 选取卧具信息表
        /// </summary>
        public virtual DbSet<GoodsInfo> BeddingInfo { get; set; }

        /// <summary>
        /// 选取床铺信息表
        /// </summary>
        public virtual DbSet<BunkInfo> BunkInfo { get; set; }

        /// <summary>
        /// 已报名信息表
        /// </summary>
        public virtual DbSet<Register> Register { get; set; }

        /// <summary>
        /// 预定车辆服务信息表
        /// </summary>
        public virtual DbSet<ServiceInfo> ServiceInfo { get; set; }

        /// <summary>
        /// 选择制服信息表
        /// </summary>
        public virtual DbSet<SuitInfo> SuitInfo { get; set; }

        /// <summary>
        /// 新生缴费金额信息表
        /// </summary>
        public virtual DbSet<TuitionInfo> TuitionInfo { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Cancel Cascading Deletion




            //modelBuilder.Entity<Question>().HasRequired<Student>(s => s.Student).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<Question>().HasRequired<AppUser>(s => s.AskFor).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<Question>().HasRequired<AppUser>(s => s.Reply).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<Bulletin>().HasRequired<AppUser>(s => s.Publish).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<Student>().HasRequired<Region>(s => s.SProvince).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<Student>().HasRequired<Region>(s => s.SCity).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<Student>().HasRequired<Region>(s => s.SDistrict).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<Building>().HasRequired<Campus>(s => s.Campus).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<Bunk>().HasRequired<Student>(s => s.Student).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<Bunk>().HasRequired<Dorm>(s => s.Dorm).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<Campus>().HasRequired<Region>(s => s.CProvince).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<Campus>().HasRequired<Region>(s => s.CCity).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<Campus>().HasRequired<Region>(s => s.CDistrict).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<Dorm>().HasRequired<Building>(s => s.Building).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<AppUser>().HasRequired<Department>(s => s.UDepartment).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<AppUser>().HasRequired<Major>(s => s.UMajor).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<Department>().HasRequired<College>(s => s.Collage).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<Department>().HasRequired<Campus>(s => s.Campus).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<Major>().HasRequired<Department>(s => s.Department).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<Major>().HasRequired<Campus>(s => s.Campus).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<MajorClass>().HasRequired<Major>(s => s.Major).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<MajorClass>().HasRequired<AppUser>(s => s.Instructor).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<BeddingInfo>().HasRequired<Student>(s => s.Student).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<BeddingInfo>().HasRequired<Bedding>(s => s.Bedding).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<BunkInfo>().HasRequired<Student>(s => s.Student).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<BunkInfo>().HasRequired<Building>(s => s.Building).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<BunkInfo>().HasRequired<Dorm>(s => s.Dorm).WithMany().WillCascadeOnDelete(false);
            #endregion
        }
    }
}
