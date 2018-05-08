/*
* 命名空间 :     Vickn.Platform.PbManagement.PbTitles
* 类 名  称 :      PbTitleAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbTitleAppService.cs
* 描      述 :     排班标题服务
* 创建时间 :     2018/5/6 14:40:39
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
using Vickn.Platform.PbManagement.PbTitles.Authorization;
using Vickn.Platform.PbManagement.PbTitles.Dtos;

namespace Vickn.Platform.PbManagement.PbTitles
{
	/// <summary>
    /// 排班标题服务
    /// </summary>
	[AbpAuthorize(PbTitleAppPermissions.PbTitle)]
    public class PbTitleAppService : PlatformAppServiceBase, IPbTitleAppService
    {
	    private readonly IRepository<PbTitle,int> _pbTitleRepository;
	  	private readonly PbTitleManager _pbTitleManager;

	    /// <summary>
        /// 初始化排班标题服务实例
        /// </summary>
        public PbTitleAppService(IRepository<PbTitle, int> pbTitleRepository,PbTitleManager pbTitleManager)
        {
            _pbTitleRepository = pbTitleRepository;
            _pbTitleManager = pbTitleManager;
        }

        #region 排班标题管理

		/// <summary>
        /// 根据查询条件获取排班标题分页列表
        /// </summary>
        public async Task<PagedResultDto<PbTitleDto>> GetPagedAsync(GetPbTitleInput input)
		{
			 var query = _pbTitleRepository.GetAll();

            query = query.Where(p => p.Title.Contains(input.FilterText));

            //TODO:根据传入的参数添加过滤条件

            var pbTitleCount = await query.CountAsync();

            var pbTitles = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var pbTitleDtos = pbTitles.MapTo<List<PbTitleDto>>();
            return new PagedResultDto<PbTitleDto>(
            pbTitleCount,
            pbTitleDtos
            );
		}

		/// <summary>
        /// 通过指定id获取排班标题Dto信息
        /// </summary>
        public async Task<PbTitleDto> GetByIdAsync(EntityDto<int> input)
		{
		    var entity = await _pbTitleRepository.GetAsync(input.Id);
            return entity.MapTo<PbTitleDto>();
		}

        /// <summary>
        /// 通过Id获取排班标题信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<PbTitleForEdit> GetForEditAsync(NullableIdDto<int> input)
		{
			PbTitleEditDto pbTitleEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _pbTitleRepository.GetAsync(input.Id.Value);
                pbTitleEditDto = entity.MapTo<PbTitleEditDto>();
            }
            else
            {
                pbTitleEditDto = new PbTitleEditDto()
                {
                    Month = DateTime.Now.Date
                };
            }
            return new PbTitleForEdit { PbTitleEditDto = pbTitleEditDto };
		}

        /// <summary>
        /// 新增或更改排班标题
        /// </summary>
		[AbpAuthorize(PbTitleAppPermissions.PbTitle_CreatePbTitle,PbTitleAppPermissions.PbTitle_EditPbTitle)]
        public async Task CreateOrUpdateAsync(PbTitleForEdit input)
		{
			 if (input.PbTitleEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
		}

        /// <summary>
        /// 新增排班标题
        /// </summary>
		[AbpAuthorize(PbTitleAppPermissions.PbTitle_CreatePbTitle)]
        public async Task<PbTitleForEdit> CreateAsync(PbTitleForEdit input)
		{
			//TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.PbTitleEditDto.MapTo<PbTitle>();

            entity = await _pbTitleRepository.InsertAsync(entity);
            return new PbTitleForEdit { PbTitleEditDto = entity.MapTo<PbTitleEditDto>() };
		}

        /// <summary>
        /// 修改排班标题
        /// </summary>
		[AbpAuthorize(PbTitleAppPermissions.PbTitle_EditPbTitle)]
        public async Task UpdateAsync(PbTitleForEdit input)
		{
		    //TODO: 更新前的逻辑判断，是否允许更新

			var entity = await _pbTitleRepository.GetAsync(input.PbTitleEditDto.Id.Value);
            input.PbTitleEditDto.MapTo(entity);

            await _pbTitleRepository.UpdateAsync(entity);
		}

        /// <summary>
        /// 删除排班标题
        /// </summary>
		[AbpAuthorize(PbTitleAppPermissions.PbTitle_DeletePbTitle)]
        public async Task DeleteAsync(EntityDto<int> input)
		{
			//TODO: 删除前的逻辑判断，是否允许删除

            await _pbTitleRepository.DeleteAsync(input.Id);
		}

        /// <summary>
        /// 批量删除排班标题
        /// </summary>
		[AbpAuthorize(PbTitleAppPermissions.PbTitle_DeletePbTitle)]
        public async Task BatchDeleteAsync(List<int> input)
		{
		    //TODO: 批量删除前的逻辑判断，是否允许删除

            await _pbTitleRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        /// <summary>
        /// 自定义检查排班标题输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(PbTitleForEdit input)
		{	
			//TODO: 自定义逻辑判断是否有逻辑错误

			return new CustomerModelStateValidationDto() {HasModelError = false};
		}

        #endregion

    }
}
