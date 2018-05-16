/*
* 命名空间 :     Vickn.Platform.Zero.UserPositions
* 类 名  称 :      UserPositionAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     UserPositionAppService.cs
* 描      述 :     职位信息服务
* 创建时间 :     2018/5/16 9:57:55
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;

using Vickn.Platform.Dtos;
using Vickn.Platform.PbManagement.Positions.Dtos;
using Vickn.Platform.Zero.UserPositions.Authorization;
using Vickn.Platform.Zero.UserPositions.Dtos;

namespace Vickn.Platform.Zero.UserPositions
{
	/// <summary>
    /// 职位信息服务
    /// </summary>
	[AbpAuthorize(UserPositionAppPermissions.UserPosition)]
    public class UserPositionAppService : PlatformAppServiceBase, IUserPositionAppService
    {
	    private readonly IRepository<UserPosition,long> _userPositionRepository;
	  	private readonly UserPositionManager _userPositionManager;

	    /// <summary>
        /// 初始化职位信息服务实例
        /// </summary>
        public UserPositionAppService(IRepository<UserPosition, long> userPositionRepository,UserPositionManager userPositionManager)
        {
            _userPositionRepository = userPositionRepository;
            _userPositionManager = userPositionManager;
        }

        #region 职位信息管理

		/// <summary>
        /// 根据查询条件获取职位信息分页列表
        /// </summary>
        public async Task<PagedResultDto<UserPositionDto>> GetPagedAsync(GetUserPositionInput input)
		{
			 var query = _userPositionRepository.GetAll();

		    query = query.Where(p => p.PositionName.Contains(input.FilterText));

            //TODO:根据传入的参数添加过滤条件

            var userPositionCount = await query.CountAsync();

            var userPositions = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var userPositionDtos = userPositions.MapTo<List<UserPositionDto>>();
            return new PagedResultDto<UserPositionDto>(
            userPositionCount,
            userPositionDtos
            );
		}

		/// <summary>
        /// 通过指定id获取职位信息Dto信息
        /// </summary>
        public async Task<UserPositionDto> GetByIdAsync(EntityDto<long> input)
		{
		    var entity = await _userPositionRepository.GetAsync(input.Id);
            return entity.MapTo<UserPositionDto>();
		}

        /// <summary>
        /// 通过Id获取职位信息信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<UserPositionForEdit> GetForEditAsync(NullableIdDto<long> input)
		{
			UserPositionEditDto userPositionEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _userPositionRepository.GetAsync(input.Id.Value);
                userPositionEditDto = entity.MapTo<UserPositionEditDto>();
            }
            else
            {
                userPositionEditDto = new UserPositionEditDto();
            }
            return new UserPositionForEdit { UserPositionEditDto = userPositionEditDto };
		}

        /// <summary>
        /// 新增或更改职位信息
        /// </summary>
		[AbpAuthorize(UserPositionAppPermissions.UserPosition_CreateUserPosition,UserPositionAppPermissions.UserPosition_EditUserPosition)]
        public async Task CreateOrUpdateAsync(UserPositionForEdit input)
		{
			 if (input.UserPositionEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
		}

        /// <summary>
        /// 新增职位信息
        /// </summary>
		[AbpAuthorize(UserPositionAppPermissions.UserPosition_CreateUserPosition)]
        public async Task<UserPositionForEdit> CreateAsync(UserPositionForEdit input)
		{
			//TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.UserPositionEditDto.MapTo<UserPosition>();

            entity = await _userPositionRepository.InsertAsync(entity);
            return new UserPositionForEdit { UserPositionEditDto = entity.MapTo<UserPositionEditDto>() };
		}

        /// <summary>
        /// 修改职位信息
        /// </summary>
		[AbpAuthorize(UserPositionAppPermissions.UserPosition_EditUserPosition)]
        public async Task UpdateAsync(UserPositionForEdit input)
		{
		    //TODO: 更新前的逻辑判断，是否允许更新

			var entity = await _userPositionRepository.GetAsync(input.UserPositionEditDto.Id.Value);
            input.UserPositionEditDto.MapTo(entity);

            await _userPositionRepository.UpdateAsync(entity);
		}

        /// <summary>
        /// 删除职位信息
        /// </summary>
		[AbpAuthorize(UserPositionAppPermissions.UserPosition_DeleteUserPosition)]
        public async Task DeleteAsync(EntityDto<long> input)
		{
			//TODO: 删除前的逻辑判断，是否允许删除

            await _userPositionRepository.DeleteAsync(input.Id);
		}

        /// <summary>
        /// 批量删除职位信息
        /// </summary>
		[AbpAuthorize(UserPositionAppPermissions.UserPosition_DeleteUserPosition)]
        public async Task BatchDeleteAsync(List<long> input)
		{
		    //TODO: 批量删除前的逻辑判断，是否允许删除

            await _userPositionRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        /// <summary>
        /// 自定义检查职位信息输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(UserPositionForEdit input)
		{	
			//TODO: 自定义逻辑判断是否有逻辑错误

			return new CustomerModelStateValidationDto() {HasModelError = false};
		}

        /// <summary>
        /// 获取所有职位信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserPositionDto>> GetAllListAsync()
        {
            var query = await _userPositionRepository.GetAllListAsync();
            var positionList = query.MapTo<List<UserPositionDto>>();
            return positionList;
        }

        #endregion

    }
}
