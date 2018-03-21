//-----------------------------------------------------------------------
// <copyright file= "EnumType.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/21 星期三 16:12:47
// Modified by:
// Description: 枚举类
//-----------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace PSU.Model.Areas
{
    public class EnumType
    {
        #region Enum

        /// <summary>
        /// 公告类型
        /// </summary>
        public enum BulletinType
        {
            [Display(Name = "请选择")]
            NotSelected = 0,
            [Display(Name = "新闻公告")]
            NewsBulletin = 1,
            [Display(Name = "学校政策")]
            PreferentialPolicy = 2
        }

        /// <summary>
        /// 公告针对目标
        /// </summary>
        public enum BulletinTarget
        {
            [Display(Name = "请选择")]
            NotSelected = 0,
            [Display(Name = "全部用户")]
            All = 1,
            [Display(Name = "教职工用户")]
            Staff = 2,
            [Display(Name = "学生用户")]
            Student = 3
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        public enum Enable
        {
            [Display(Name = "不启用")]
            NotUse = 0,
            [Display(Name = "启用")]
            Use = 1,
        }

        /// <summary>
        /// 是否为部门
        /// </summary>
        public enum Branch
        {
            [Display(Name = "否")]
            False = 0,
            [Display(Name = "是")]
            True = 1,
        }

        #endregion
    }
}
