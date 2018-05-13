// 项目展示地址:"http://www.ddxc.org/"
// 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-01-17T22:21:11. All Rights Reserved.
//<生成时间>2017-01-17T22:21:11</生成时间>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Extensions;
using Vickn.Platform.DataDictionaries;
using Vickn.Platform.DataDictionaries.Dtos;
using Vickn.Platform.Users;

namespace Vickn.Platform.Users.Dtos
{
    /// <summary>
    /// 用于添加或编辑 用户管理时使用的DTO
    /// </summary>

    public class GetUserForEdit
    {
        /// <summary>
        /// User编辑状态的DTO
        /// </summary>
        public UserEditDto UserEditDto { get; set; }

        [DisplayName("角色")]
        public UserRoleDto[] UserRoleDtos { get; set; }


        /// <summary>
        /// 组织Id
        /// </summary>
        public long? OuId { get; set; }


        /// <summary>
        ///职位
        /// </summary>
        [DisplayName("登录名")]
        public ListResultDto<DataDictionaryItem> DataDictionaryItems { get; set; }
    }
}
