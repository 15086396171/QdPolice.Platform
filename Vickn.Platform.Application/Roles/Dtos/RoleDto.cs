/*
* 命名空间 :     Vickn.Platform.Authorization.Roles.Dtos
* 类 名  称 :     GetRoleInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetRoleInput.cs
* 描      述 :     角色管理Dto
* 创建时间 :     2017/2/20 15:47:01
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Vickn.Platform.Authorization.Roles;

namespace Vickn.Platform.Roles.Dtos
{
    /// <summary>
    /// 角色管理Dto
    /// </summary>
    [AutoMap(typeof(Role))]
    public class RoleDto : EntityDto<int>
    {
        /// <summary>
        /// 角色显示名
        /// </summary>
		[DisplayName("角色显示名")]
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// 是否静态角色
        /// </summary>
		[DisplayName("是否静态角色")]
        public bool IsStatic { get; set; }

        /// <summary>
        /// 是否默认角色
        /// </summary>
		[DisplayName("是否默认角色")]
        public bool IsDefault { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
		[DisplayName("角色名")]
        [Required]
        public string Name { get; set; }

    }
}
