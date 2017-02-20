﻿/*
* 命名空间 :     Vickn.Platform.Authorization.Roles
* 类 名  称 :      RoleAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     RoleAppService.cs
* 描      述 :     角色服务
* 创建时间 :     2017/2/20 15:47:02
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Vickn.Platform.Authorization.Roles;
using Vickn.Platform.Authorization.Roles.Authorization;
using Vickn.Platform.Dtos;
using Vickn.Platform.Roles.Dtos;

namespace Vickn.Platform.Roles
{
	/// <summary>
    /// 角色服务
    /// </summary>
    public class RoleAppService : PlatformAppServiceBase, IRoleAppService
    {
	    private readonly IRepository<Role,int> _roleRepository;
	  	private readonly RoleManager _roleManager;
	    private readonly IPermissionManager _permissionManager;

	    /// <summary>
        /// 初始化角色服务实例
        /// </summary>
        public RoleAppService(IRepository<Role, int> roleRepository,RoleManager roleManager,IPermissionManager permissionManager)
        {
            _roleRepository = roleRepository;
            _roleManager = roleManager;
	        _permissionManager = permissionManager;
        }

        #region 角色管理

	    /// <summary>
	    /// 更新角色权限
	    /// </summary>
	    /// <param name="input"></param>
	    /// <returns></returns>
	    public async Task UpdateRolePermissionsAsync(UpdateRolePermissionsInput input)
        {
            var role = await _roleManager.GetRoleByIdAsync(input.RoleId);
            var grantedPermissions = _permissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }

        /// <summary>
        /// 根据查询条件获取角色分页列表
        /// </summary>
        public async Task<PagedResultDto<RoleDto>> GetPagedAsync(GetRoleInput input)
		{
			 var query = _roleRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件

            var roleCount = await query.CountAsync();

            var roles = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var roleDtos = roles.MapTo<List<RoleDto>>();
            return new PagedResultDto<RoleDto>(
            roleCount,
            roleDtos
            );
		}

        /// <summary>
        /// 通过Id获取角色信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<RoleEditDto> GetForEditAsync(NullableIdDto<int> input)
		{
			RoleEditDto roleEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _roleRepository.GetAsync(input.Id.Value);
                roleEditDto = entity.MapTo<RoleEditDto>();
            }
            else
            {
                roleEditDto = new RoleEditDto();
            }
            return roleEditDto;
		}

        /// <summary>
        /// 通过指定id获取角色Dto信息
        /// </summary>
        public async Task<RoleDto> GetByIdAsync(EntityDto<int> input)
		{
		    var entity = await _roleRepository.GetAsync(input.Id);
            return entity.MapTo<RoleDto>();
		}

        /// <summary>
        /// 新增或更改角色
        /// </summary>
        public async Task CreateOrUpdateAsync(RoleEditDto input)
		{
			 if (input.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
		}

        /// <summary>
        /// 新增角色
        /// </summary>
        public async Task<RoleEditDto> CreateAsync(RoleEditDto input)
		{
			//TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Role>();

            entity = await _roleRepository.InsertAsync(entity);
            return entity.MapTo<RoleEditDto>();
		}

        /// <summary>
        /// 更新角色
        /// </summary>
        public async Task UpdateAsync(RoleEditDto input)
		{
		    //TODO: 更新前的逻辑判断，是否允许更新

			var entity = await _roleRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _roleRepository.UpdateAsync(entity);
		}

        /// <summary>
        /// 删除角色
        /// </summary>
        public async Task DeleteAsync(EntityDto<int> input)
		{
			//TODO: 删除前的逻辑判断，是否允许删除

            await _roleRepository.DeleteAsync(input.Id);
		}

        /// <summary>
        /// 批量删除角色
        /// </summary>
        public async Task BatchDeleteAsync(List<int> input)
		{
		    //TODO: 批量删除前的逻辑判断，是否允许删除
            var adminRole = await _roleRepository.FirstOrDefaultAsync(p => p.Name == StaticRoleNames.Tenants.Admin);
            input.Remove(adminRole.Id);
            await _roleRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        /// <summary>
        /// 自定义检查角色输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(RoleEditDto input)
		{	
			//TODO: 自定义逻辑判断是否有逻辑错误

			return new CustomerModelStateValidationDto() {HasModelError = false};
		}

        #endregion

    }
}
