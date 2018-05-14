/*
* 命名空间 :     Vickn.Platform.PbManagement.ChangWorks
* 类 名  称 :      ChangeWorkAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     ChangeWorkAppService.cs
* 描      述 :     换班服务
* 创建时间 :     2018/5/14 9:16:05
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
using Vickn.Platform.PbManagement.ChangeWorks.Authorization;
using Vickn.Platform.PbManagement.ChangeWorks.Dtos;
using Vickn.Platform.PbManagement.ChangeWorks.Authorization;

namespace Vickn.Platform.PbManagement.ChangeWorks
{
	/// <summary>
    /// 换班服务
    /// </summary>
	[AbpAuthorize(ChangeWorkAppPermissions.ChangeWork)]
    public class ChangeWorkAppService : PlatformAppServiceBase, IChangeWorkAppService
    {
	    private readonly IRepository<ChangeWork,long> _changeWorkRepository;
	  	private readonly ChangeWorkManager _changeWorkManager;

	    /// <summary>
        /// 初始化换班服务实例
        /// </summary>
        public ChangeWorkAppService(IRepository<ChangeWork, long> changeWorkRepository,ChangeWorkManager changeWorkManager)
        {
            _changeWorkRepository = changeWorkRepository;
            _changeWorkManager = changeWorkManager;
        }

        #region 换班管理

		/// <summary>
        /// 根据查询条件获取换班分页列表
        /// </summary>
        public async Task<PagedResultDto<ChangeWorkDto>> GetPagedAsync(GetChangeWorkInput input)
		{
			 var query = _changeWorkRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件

            var changeWorkCount = await query.CountAsync();

            var changeWorks = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var changeWorkDtos = changeWorks.MapTo<List<ChangeWorkDto>>();
            return new PagedResultDto<ChangeWorkDto>(
            changeWorkCount,
            changeWorkDtos
            );
		}

		/// <summary>
        /// 通过指定id获取换班Dto信息
        /// </summary>
        public async Task<ChangeWorkDto> GetByIdAsync(EntityDto<long> input)
		{
		    var entity = await _changeWorkRepository.GetAsync(input.Id);
            return entity.MapTo<ChangeWorkDto>();
		}

        /// <summary>
        /// 通过Id获取换班信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<ChangeWorkForEdit> GetForEditAsync(NullableIdDto<long> input)
		{
			ChangeWorkEditDto changeWorkEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _changeWorkRepository.GetAsync(input.Id.Value);
                changeWorkEditDto = entity.MapTo<ChangeWorkEditDto>();
            }
            else
            {
                changeWorkEditDto = new ChangeWorkEditDto();
            }
            return new ChangeWorkForEdit { ChangeWorkEditDto = changeWorkEditDto };
		}

        /// <summary>
        /// 新增或更改换班
        /// </summary>
		[AbpAuthorize(ChangeWorkAppPermissions.ChangeWork_CreateChangeWork,ChangeWorkAppPermissions.ChangeWork_EditChangeWork)]
        public async Task CreateOrUpdateAsync(ChangeWorkForEdit input)
		{
			 if (input.ChangeWorkEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
		}

        /// <summary>
        /// 新增换班
        /// </summary>
		[AbpAuthorize(ChangeWorkAppPermissions.ChangeWork_CreateChangeWork)]
        public async Task<ChangeWorkForEdit> CreateAsync(ChangeWorkForEdit input)
		{
			//TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.ChangeWorkEditDto.MapTo<ChangeWork>();

            entity = await _changeWorkRepository.InsertAsync(entity);
            return new ChangeWorkForEdit { ChangeWorkEditDto = entity.MapTo<ChangeWorkEditDto>() };
		}

        /// <summary>
        /// 修改换班
        /// </summary>
		[AbpAuthorize(ChangeWorkAppPermissions.ChangeWork_EditChangeWork)]
        public async Task UpdateAsync(ChangeWorkForEdit input)
		{
		    //TODO: 更新前的逻辑判断，是否允许更新

			var entity = await _changeWorkRepository.GetAsync(input.ChangeWorkEditDto.Id.Value);
            input.ChangeWorkEditDto.MapTo(entity);

            await _changeWorkRepository.UpdateAsync(entity);
		}

        /// <summary>
        /// 删除换班
        /// </summary>
		[AbpAuthorize(ChangeWorkAppPermissions.ChangeWork_DeleteChangeWork)]
        public async Task DeleteAsync(EntityDto<long> input)
		{
			//TODO: 删除前的逻辑判断，是否允许删除

            await _changeWorkRepository.DeleteAsync(input.Id);
		}

        /// <summary>
        /// 批量删除换班
        /// </summary>
		[AbpAuthorize(ChangeWorkAppPermissions.ChangeWork_DeleteChangeWork)]
        public async Task BatchDeleteAsync(List<long> input)
		{
		    //TODO: 批量删除前的逻辑判断，是否允许删除

            await _changeWorkRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        /// <summary>
        /// 自定义检查换班输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(ChangeWorkForEdit input)
		{	
			//TODO: 自定义逻辑判断是否有逻辑错误

			return new CustomerModelStateValidationDto() {HasModelError = false};
		}

        #endregion

    }
}
