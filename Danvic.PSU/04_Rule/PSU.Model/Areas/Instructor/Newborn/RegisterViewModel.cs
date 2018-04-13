//-----------------------------------------------------------------------
// <copyright file= "RegisterViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/4/12 星期四 19:48:21
// Modified by:
// Description: Instructor-Newborn-报名数据列表页面 View Model
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace PSU.Model.Areas.Instructor.Newborn
{
    public class RegisterViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 专业班级
        /// </summary>
        public string SMajorClass { get; set; }

        /// <summary>
        /// 到校时间
        /// </summary>
        public string SDate { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 新生报名数据列表
        /// </summary>
        public List<RegisterData> RegisterList { get; set; }

        #endregion
    }

    /// <summary>
    /// 新生报名数据
    /// </summary>
    public class RegisterData
    {
        #region Table

        /// <summary>
        /// 学号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属院系
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 专业班级
        /// </summary>
        public string MajorClass { get; set; }

        /// <summary>
        /// 来校方式
        /// 1:火车;2:客车;3:飞机;4:自驾;5:客船;6:其它
        /// </summary>
        public short Way { get; set; }

        public string WayStr
        {
            get
            {
                var str = "";
                if (Way == 1)
                    str = "火车";
                else if (Way == 2)
                    str = "客车";
                else if (Way == 3)
                    str = "飞机";
                else if (Way == 4)
                    str = "自驾";
                else if (Way == 5)
                    str = "客船";
                else if (Way == 6)
                    str = "其它";
                return str;
            }
        }

        /// <summary>
        /// 预计到达时间
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 到达地点
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        #endregion
    }
}
