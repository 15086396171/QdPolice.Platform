/*
* 命名空间 :     Vickn.Platform.Schedules.SchedulingPosts
* 类 名  称 :      SchedulingPostAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     SchedulingPostAppService.cs
* 描      述 :     岗位设置服务
* 创建时间 :     2018/5/3 15:40:50
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
using Vickn.Platform.Schedules.SchedulingPosts.Authorization;
using Vickn.Platform.Schedules.SchedulingPosts.Dtos;

namespace Vickn.Platform.Schedules.SchedulingPosts
{
	/// <summary>
    /// 岗位设置服务
    /// </summary>
	[AbpAuthorize(SchedulingPostAppPermissions.SchedulingPost)]
    public class SchedulingPostAppService : PlatformAppServiceBase, ISchedulingPostAppService
    {
	    private readonly IRepository<SchedulingPost,long> _schedulingPostRepository;
	  	private readonly SchedulingPostManager _schedulingPostManager;

	    /// <summary>
        /// 初始化岗位设置服务实例
        /// </summary>
        public SchedulingPostAppService(IRepository<SchedulingPost, long> schedulingPostRepository,SchedulingPostManager schedulingPostManager)
        {
            _schedulingPostRepository = schedulingPostRepository;
            _schedulingPostManager = schedulingPostManager;
        }

        #region 岗位设置管理

		/// <summary>
        /// 根据查询条件获取岗位设置分页列表
        /// </summary>
        public async Task<PagedResultDto<SchedulingPostDto>> GetPagedAsync(GetSchedulingPostInput input)
		{
			 var query = _schedulingPostRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件
            query = query.Where(p => p.PostName.Contains(input.FilterText));

            var schedulingPostCount = await query.CountAsync();

            var schedulingPosts = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var schedulingPostDtos = schedulingPosts.MapTo<List<SchedulingPostDto>>();
            return new PagedResultDto<SchedulingPostDto>(
            schedulingPostCount,
            schedulingPostDtos
            );
		}

		/// <summary>
        /// 通过指定id获取岗位设置Dto信息
        /// </summary>
        public async Task<SchedulingPostDto> GetByIdAsync(EntityDto<long> input)
		{
		    var entity = await _schedulingPostRepository.GetAsync(input.Id);
            return entity.MapTo<SchedulingPostDto>();
		}

        /// <summary>
        /// 通过Id获取岗位设置信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<SchedulingPostForEdit> GetForEditAsync(NullableIdDto<long> input)
		{
			SchedulingPostEditDto schedulingPostEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _schedulingPostRepository.GetAsync(input.Id.Value);
                schedulingPostEditDto = entity.MapTo<SchedulingPostEditDto>();
            }
            else
            {
                schedulingPostEditDto = new SchedulingPostEditDto();
            }
            return new SchedulingPostForEdit { SchedulingPostEditDto = schedulingPostEditDto };
		}

        /// <summary>
        /// 新增或更改岗位设置
        /// </summary>
		[AbpAuthorize(SchedulingPostAppPermissions.SchedulingPost_CreateSchedulingPost,SchedulingPostAppPermissions.SchedulingPost_EditSchedulingPost)]
        public async Task CreateOrUpdateAsync(SchedulingPostForEdit input)
		{
			 if (input.SchedulingPostEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
		}

        /// <summary>
        /// 新增岗位设置
        /// </summary>
		[AbpAuthorize(SchedulingPostAppPermissions.SchedulingPost_CreateSchedulingPost)]
        public async Task<SchedulingPostForEdit> CreateAsync(SchedulingPostForEdit input)
		{
			//TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.SchedulingPostEditDto.MapTo<SchedulingPost>();

            entity = await _schedulingPostRepository.InsertAsync(entity);
            return new SchedulingPostForEdit { SchedulingPostEditDto = entity.MapTo<SchedulingPostEditDto>() };
		}

        /// <summary>
        /// 修改岗位设置
        /// </summary>
		[AbpAuthorize(SchedulingPostAppPermissions.SchedulingPost_EditSchedulingPost)]
        public async Task UpdateAsync(SchedulingPostForEdit input)
		{
		    //TODO: 更新前的逻辑判断，是否允许更新

			var entity = await _schedulingPostRepository.GetAsync(input.SchedulingPostEditDto.Id.Value);
            input.SchedulingPostEditDto.MapTo(entity);

            await _schedulingPostRepository.UpdateAsync(entity);
		}

        /// <summary>
        /// 删除岗位设置
        /// </summary>
		[AbpAuthorize(SchedulingPostAppPermissions.SchedulingPost_DeleteSchedulingPost)]
        public async Task DeleteAsync(EntityDto<long> input)
		{
			//TODO: 删除前的逻辑判断，是否允许删除

            await _schedulingPostRepository.DeleteAsync(input.Id);
		}

        /// <summary>
        /// 批量删除岗位设置
        /// </summary>
		[AbpAuthorize(SchedulingPostAppPermissions.SchedulingPost_DeleteSchedulingPost)]
        public async Task BatchDeleteAsync(List<long> input)
		{
		    //TODO: 批量删除前的逻辑判断，是否允许删除

            await _schedulingPostRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        /// <summary>
        /// 自定义检查岗位设置输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(SchedulingPostForEdit input)
		{	
			//TODO: 自定义逻辑判断是否有逻辑错误

			return new CustomerModelStateValidationDto() {HasModelError = false};
		}

        #endregion

    }
}
