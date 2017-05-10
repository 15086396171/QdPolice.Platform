/*
* 命名空间 :     NanNingSSOMS.BLL.Services.PbManagementV3
* 类 名  称 :     ChangeWorkV3Service
* 版      本 :      v1.0.0.0
* 文 件  名 :     ChangeWorkV3Service.cs
* 描      述 :      
* 创建时间 :     2016-07-22 11:34:41
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Vickn.Platform.Dtos;
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
