/*
* 命名空间 :     Vickn.Platform.Schedules.PlatoonGroups
* 类 名  称 :      PlatoonGroupAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     PlatoonGroupAppService.cs
* 描      述 :     排班组服务
* 创建时间 :     2018/5/3 17:22:53
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
using Vickn.Platform.Schedules.PlatoonGroups.Authorization;
using Vickn.Platform.Schedules.PlatoonGroups.Dtos;

namespace Vickn.Platform.Schedules.PlatoonGroups
{
	/// <summary>
    /// 排班组服务
    /// </summary>
	[AbpAuthorize(PlatoonGroupAppPermissions.PlatoonGroup)]
    public class PlatoonGroupAppService : PlatformAppServiceBase, IPlatoonGroupAppService
    {
	    private readonly IRepository<PlatoonGroup,long> _platoonGroupRepository;
	  	
	    /// <summary>
        /// 初始化排班组服务实例
        /// </summary>
        public PlatoonGroupAppService(IRepository<PlatoonGroup, long> platoonGroupRepository)
        {
            _platoonGroupRepository = platoonGroupRepository;
           
        }

        #region 排班组管理

		/// <summary>
        /// 根据查询条件获取排班组分页列表
        /// </summary>
        public async Task<PagedResultDto<PlatoonGroupDto>> GetPagedAsync(GetPlatoonGroupInput input)
		{
			 var query = _platoonGroupRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件

            var platoonGroupCount = await query.CountAsync();

            var platoonGroups = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var platoonGroupDtos = platoonGroups.MapTo<List<PlatoonGroupDto>>();
            return new PagedResultDto<PlatoonGroupDto>(
            platoonGroupCount,
            platoonGroupDtos
            );
		}

		/// <summary>
        /// 通过指定id获取排班组Dto信息
        /// </summary>
        public async Task<PlatoonGroupDto> GetByIdAsync(EntityDto<long> input)
		{
		    var entity = await _platoonGroupRepository.GetAsync(input.Id);
            return entity.MapTo<PlatoonGroupDto>();
		}

        /// <summary>
        /// 通过Id获取排班组信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<PlatoonGroupForEdit> GetForEditAsync(NullableIdDto<long> input)
		{
			PlatoonGroupEditDto platoonGroupEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _platoonGroupRepository.GetAsync(input.Id.Value);
                platoonGroupEditDto = entity.MapTo<PlatoonGroupEditDto>();
            }
            else
            {
                platoonGroupEditDto = new PlatoonGroupEditDto();
            }
            return new PlatoonGroupForEdit { PlatoonGroupEditDto = platoonGroupEditDto };
		}

        /// <summary>
        /// 新增或更改排班组
        /// </summary>
		[AbpAuthorize(PlatoonGroupAppPermissions.PlatoonGroup_CreatePlatoonGroup,PlatoonGroupAppPermissions.PlatoonGroup_EditPlatoonGroup)]
        public async Task CreateOrUpdateAsync(PlatoonGroupForEdit input)
		{
			 if (input.PlatoonGroupEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
		}

        /// <summary>
        /// 新增排班组
        /// </summary>
		[AbpAuthorize(PlatoonGroupAppPermissions.PlatoonGroup_CreatePlatoonGroup)]
        public async Task<PlatoonGroupForEdit> CreateAsync(PlatoonGroupForEdit input)
		{
			//TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.PlatoonGroupEditDto.MapTo<PlatoonGroup>();

            entity = await _platoonGroupRepository.InsertAsync(entity);
            return new PlatoonGroupForEdit { PlatoonGroupEditDto = entity.MapTo<PlatoonGroupEditDto>() };
		}

        /// <summary>
        /// 修改排班组
        /// </summary>
		[AbpAuthorize(PlatoonGroupAppPermissions.PlatoonGroup_EditPlatoonGroup)]
        public async Task UpdateAsync(PlatoonGroupForEdit input)
		{
		    //TODO: 更新前的逻辑判断，是否允许更新

			var entity = await _platoonGroupRepository.GetAsync(input.PlatoonGroupEditDto.Id.Value);
            input.PlatoonGroupEditDto.MapTo(entity);

            await _platoonGroupRepository.UpdateAsync(entity);
		}

        /// <summary>
        /// 删除排班组
        /// </summary>
		[AbpAuthorize(PlatoonGroupAppPermissions.PlatoonGroup_DeletePlatoonGroup)]
        public async Task DeleteAsync(EntityDto<long> input)
		{
			//TODO: 删除前的逻辑判断，是否允许删除

            await _platoonGroupRepository.DeleteAsync(input.Id);
		}

        /// <summary>
        /// 批量删除排班组
        /// </summary>
		[AbpAuthorize(PlatoonGroupAppPermissions.PlatoonGroup_DeletePlatoonGroup)]
        public async Task BatchDeleteAsync(List<long> input)
		{
		    //TODO: 批量删除前的逻辑判断，是否允许删除

            await _platoonGroupRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        /// <summary>
        /// 自定义检查排班组输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(PlatoonGroupForEdit input)
		{	
			//TODO: 自定义逻辑判断是否有逻辑错误

			return new CustomerModelStateValidationDto() {HasModelError = false};
		}

        #endregion

    }
}
