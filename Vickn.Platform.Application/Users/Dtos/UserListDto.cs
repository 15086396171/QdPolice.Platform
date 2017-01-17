
// 项目展示地址:"http://www.ddxc.org/"
// 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
//<Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-01-17T22:21:10. All Rights Reserved.
//<生成时间>2017-01-17T22:21:10</生成时间>
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Vickn.Platform.Users;

namespace Vickn.Platform.Users.Dtos
{
    /// <summary>
    /// 用户管理列表Dto
    /// </summary>
    [AutoMapFrom(typeof(User))]
    public class UserListDto : EntityDto<long>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("用户名")]
        public string UserName { get; set; }
        /// <summary>
        /// 显示名
        /// </summary>
        [DisplayName("显示名")]
        public string Surname { get; set; }
        /// <summary>
        /// 是否邮件确认
        /// </summary>
        [DisplayName("是否邮件确认")]
        public bool IsEmailConfirmed { get; set; }
        /// <summary>
        /// 锁定解锁时间
        /// </summary>
        [DisplayName("锁定解锁时间")]
        public DateTime? LockoutEndDateUtc { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        [DisplayName("是否锁定")]
        public bool IsLockoutEnabled { get; set; }
        /// <summary>
        /// 电话号码.
        /// </summary>
        [DisplayName("电话号码.")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DisplayName("是否启用")]
        public bool IsActive { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        [DisplayName("电子邮件")]
        public string EmailAddress { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        [DisplayName("上次登录时间")]
        public DateTime? LastLoginTime { get; set; }
    }
}
