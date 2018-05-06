/*
* 命名空间 :     Vickn.Platform.PbManagement.Positions
* 类 名  称 :      PositionAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionAppService.cs
* 描      述 :     岗位服务
* 创建时间 :     2018/5/6 14:16:44
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
using Vickn.Platform.PbManagement.Positions.Authorization;
using Vickn.Platform.PbManagement.Positions.Dtos;

namespace Vickn.Platform.PbManagement.Positions
{
	/// <summary>
    /// 岗位服务
    /// </summary>
	[AbpAuthorize(PositionAppPermissions.Position)]
    public class PositionAppService : PlatformAppServiceBase, IPositionAppService
    {
	    private readonly IRepository<Position,int> _positionRepository;
	  	private readonly PositionManager _positionManager;

	    /// <summary>
        /// 初始化岗位服务实例
        /// </summary>
        public PositionAppService(IRepository<Position, int> positionRepository,PositionManager positionManager)
        {
            _positionRepository = positionRepository;
            _positionManager = positionManager;
        }

        #region 岗位管理

		/// <summary>
        /// 根据查询条件获取岗位分页列表
        /// </summary>
        public async Task<PagedResultDto<PositionDto>> GetPagedAsync(GetPositionInput input)
		{
			 var query = _positionRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件

            var positionCount = await query.CountAsync();

            var positions = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var positionDtos = positions.MapTo<List<PositionDto>>();
            return new PagedResultDto<PositionDto>(
            positionCount,
            positionDtos
            );
		}

		/// <summary>
        /// 通过指定id获取岗位Dto信息
        /// </summary>
        public async Task<PositionDto> GetByIdAsync(EntityDto<int> input)
		{
		    var entity = await _positionRepository.GetAsync(input.Id);
            return entity.MapTo<PositionDto>();
		}

        /// <summary>
        /// 通过Id获取岗位信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<PositionForEdit> GetForEditAsync(NullableIdDto<int> input)
		{
			PositionEditDto positionEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _positionRepository.GetAsync(input.Id.Value);
                positionEditDto = entity.MapTo<PositionEditDto>();
            }
            else
            {
                positionEditDto = new PositionEditDto();
            }
            return new PositionForEdit { PositionEditDto = positionEditDto };
		}

        /// <summary>
        /// 新增或更改岗位
        /// </summary>
		[AbpAuthorize(PositionAppPermissions.Position_CreatePosition,PositionAppPermissions.Position_EditPosition)]
        public async Task CreateOrUpdateAsync(PositionForEdit input)
		{
			 if (input.PositionEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
		}

        /// <summary>
        /// 新增岗位
        /// </summary>
		[AbpAuthorize(PositionAppPermissions.Position_CreatePosition)]
        public async Task<PositionForEdit> CreateAsync(PositionForEdit input)
		{
			//TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.PositionEditDto.MapTo<Position>();

            entity = await _positionRepository.InsertAsync(entity);
            return new PositionForEdit { PositionEditDto = entity.MapTo<PositionEditDto>() };
		}

        /// <summary>
        /// 修改岗位
        /// </summary>
		[AbpAuthorize(PositionAppPermissions.Position_EditPosition)]
        public async Task UpdateAsync(PositionForEdit input)
		{
		    //TODO: 更新前的逻辑判断，是否允许更新

			var entity = await _positionRepository.GetAsync(input.PositionEditDto.Id.Value);
            input.PositionEditDto.MapTo(entity);

            await _positionRepository.UpdateAsync(entity);
		}

        /// <summary>
        /// 删除岗位
        /// </summary>
		[AbpAuthorize(PositionAppPermissions.Position_DeletePosition)]
        public async Task DeleteAsync(EntityDto<int> input)
		{
			//TODO: 删除前的逻辑判断，是否允许删除

            await _positionRepository.DeleteAsync(input.Id);
		}

        /// <summary>
        /// 批量删除岗位
        /// </summary>
		[AbpAuthorize(PositionAppPermissions.Position_DeletePosition)]
        public async Task BatchDeleteAsync(List<int> input)
		{
		    //TODO: 批量删除前的逻辑判断，是否允许删除

            await _positionRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        /// <summary>
        /// 自定义检查岗位输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(PositionForEdit input)
		{	
			//TODO: 自定义逻辑判断是否有逻辑错误

			return new CustomerModelStateValidationDto() {HasModelError = false};
		}

        #endregion

    }
}
