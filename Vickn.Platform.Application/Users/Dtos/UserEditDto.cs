﻿
// 项目展示地址:"http://www.ddxc.org/"
// 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-01-17T22:21:09. All Rights Reserved.
//<生成时间>2017-01-17T22:21:09</生成时间>
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using Vickn.PlatfForm.Utils;
using Vickn.Platform.Users;

namespace Vickn.Platform.Users.Dtos
{
    /// <summary>
    /// 用户管理编辑用Dto
    /// </summary>
    [AutoMap(typeof(User))]
    public class UserEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public long? Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        [Required]
        [MaxLength(8)]
        public string Name { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        [DisplayName("显示名")]
        public string Surname { get; set; }

        /// <summary>
        /// 电话号码.
        /// </summary>
        [DisplayName("电话号码.")]
        [Required]
        [MaxLength(20)]
        [RegularExpression(RegularConst.PhoneRegularExpression,ErrorMessage = RegularConst.PhoneErrorMsg)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("登录名")]
        public string UserName { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        [DisplayName("电子邮件")]
        [Required]
        [RegularExpression(RegularConst.EmailRegularExpression,ErrorMessage = RegularConst.EmailErrorMsg)]
        public string EmailAddress { get; set; }

        [DisplayName("是否启用")]
        public bool IsActive { get; set; }

    }
}
