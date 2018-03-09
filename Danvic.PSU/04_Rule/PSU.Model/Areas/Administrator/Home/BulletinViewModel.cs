//-----------------------------------------------------------------------
// <copyright file= "BulletinViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/28 星期三 16:29:25
// Modified by:
// Description: Administrator-Home-公告列表视图模型
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace PSU.Model.Areas.Administrator.Home
{
    public class BulletinViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 公告标题
        /// </summary>
        public string STitle { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public string SDateTime { get; set; }

        /// <summary>
        /// 公告类型
        /// </summary>
        public short SType { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 查询结果对象集合
        /// </summary>
        public List<ReturnData> BulletinList { get; set; }

        #endregion
    }

    /// <summary>
    /// 返回数据对象类
    /// </summary>
    public class ReturnData
    {
        #region Table

        /// <summary>
        /// 公告Id
        /// 此处使用string传递防止进制转换
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 公告标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 公告内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 公告类型
        /// </summary>
        public short Type { get; set; }

        public string TypeStr
        {
            get
            {
                string str = string.Empty;
                switch (Type)
                {
                    case 1:
                        str = "新闻公告";
                        break;
                    case 2:
                        str = "学校政策";
                        break;
                    default:
                        str = "";
                        break;
                }
                return str;
            }
        }

        /// <summary>
        /// 针对用户
        /// </summary>
        public short Target { get; set; }

        public string TargetStr
        {
            get
            {
                string str = string.Empty;

                switch (Target)
                {
                    case 0:
                        str = "全部用户";
                        break;
                    case 1:
                        str = "教职工用户";
                        break;
                    case 2:
                        str = "学生用户";
                        break;
                    default:
                        str = "";
                        break;
                }

                return str;
            }
        }

        /// <summary>
        /// 发布时间
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// 发布人
        /// </summary>
        public string Publisher { get; set; }

        #endregion
    }
}
