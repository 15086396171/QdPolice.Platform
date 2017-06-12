/*
* 命名空间 :     Vickn.Platform.DataDictionaries
* 类 名  称 :      DataDictionaryItemAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     DataDictionaryItemAppService.cs
* 描      述 :     数据字典项服务
* 创建时间 :     2017/6/12 16:57:19
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
using Vickn.Platform.DataDictionaries.Authorization;
using Vickn.Platform.DataDictionaries.Dtos;

namespace Vickn.Platform.DataDictionaries
{
	/// <summary>
    /// 数据字典项服务
    /// </summary>
	[AbpAuthorize(DataDictionaryItemAppPermissions.DataDictionaryItem)]
    public class DataDictionaryItemAppService : PlatformAppServiceBase, IDataDictionaryItemAppService
    {
	    private readonly IRepository<DataDictionaryItem,int> _dataDictionaryItemRepository;
	  	private readonly DataDictionaryItemManager _dataDictionaryItemManager;

	    /// <summary>
        /// 初始化数据字典项服务实例
        /// </summary>
        public DataDictionaryItemAppService(IRepository<DataDictionaryItem, int> dataDictionaryItemRepository,DataDictionaryItemManager dataDictionaryItemManager)
        {
            _dataDictionaryItemRepository = dataDictionaryItemRepository;
            _dataDictionaryItemManager = dataDictionaryItemManager;
        }

        #region 数据字典项管理

		/// <summary>
        /// 根据查询条件获取数据字典项分页列表
        /// </summary>
        public async Task<PagedResultDto<DataDictionaryItemDto>> GetPagedAsync(GetDataDictionaryItemInput input)
		{
			 var query = _dataDictionaryItemRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件

            var dataDictionaryItemCount = await query.CountAsync();

            var dataDictionaryItems = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var dataDictionaryItemDtos = dataDictionaryItems.MapTo<List<DataDictionaryItemDto>>();
            return new PagedResultDto<DataDictionaryItemDto>(
            dataDictionaryItemCount,
            dataDictionaryItemDtos
            );
		}

		/// <summary>
        /// 通过指定id获取数据字典项Dto信息
        /// </summary>
        public async Task<DataDictionaryItemDto> GetByIdAsync(EntityDto<int> input)
		{
		    var entity = await _dataDictionaryItemRepository.GetAsync(input.Id);
            return entity.MapTo<DataDictionaryItemDto>();
		}

        /// <summary>
        /// 通过Id获取数据字典项信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<DataDictionaryItemForEdit> GetForEditAsync(NullableIdDto<int> input)
		{
			DataDictionaryItemEditDto dataDictionaryItemEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _dataDictionaryItemRepository.GetAsync(input.Id.Value);
                dataDictionaryItemEditDto = entity.MapTo<DataDictionaryItemEditDto>();
            }
            else
            {
                dataDictionaryItemEditDto = new DataDictionaryItemEditDto();
            }
            return new DataDictionaryItemForEdit { DataDictionaryItemEditDto = dataDictionaryItemEditDto };
		}

        /// <summary>
        /// 新增或更改数据字典项
        /// </summary>
        public async Task CreateOrUpdateAsync(DataDictionaryItemForEdit input)
		{
			 if (input.DataDictionaryItemEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
		}

        /// <summary>
        /// 新增数据字典项
        /// </summary>
		[AbpAuthorize(DataDictionaryItemAppPermissions.DataDictionaryItem_CreateDataDictionaryItem)]
        public async Task<DataDictionaryItemForEdit> CreateAsync(DataDictionaryItemForEdit input)
		{
			//TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.DataDictionaryItemEditDto.MapTo<DataDictionaryItem>();

            entity = await _dataDictionaryItemRepository.InsertAsync(entity);
            return new DataDictionaryItemForEdit { DataDictionaryItemEditDto = entity.MapTo<DataDictionaryItemEditDto>() };
		}

        /// <summary>
        /// 修改数据字典项
        /// </summary>
		[AbpAuthorize(DataDictionaryItemAppPermissions.DataDictionaryItem_EditDataDictionaryItem)]
        public async Task UpdateAsync(DataDictionaryItemForEdit input)
		{
		    //TODO: 更新前的逻辑判断，是否允许更新

			var entity = await _dataDictionaryItemRepository.GetAsync(input.DataDictionaryItemEditDto.Id.Value);
            input.DataDictionaryItemEditDto.MapTo(entity);

            await _dataDictionaryItemRepository.UpdateAsync(entity);
		}

        /// <summary>
        /// 删除数据字典项
        /// </summary>
		[AbpAuthorize(DataDictionaryItemAppPermissions.DataDictionaryItem_DeleteDataDictionaryItem)]
        public async Task DeleteAsync(EntityDto<int> input)
		{
			//TODO: 删除前的逻辑判断，是否允许删除

            await _dataDictionaryItemRepository.DeleteAsync(input.Id);
		}

        /// <summary>
        /// 批量删除数据字典项
        /// </summary>
		[AbpAuthorize(DataDictionaryItemAppPermissions.DataDictionaryItem_DeleteDataDictionaryItem)]
        public async Task BatchDeleteAsync(List<int> input)
		{
		    //TODO: 批量删除前的逻辑判断，是否允许删除

            await _dataDictionaryItemRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        /// <summary>
        /// 自定义检查数据字典项输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(DataDictionaryItemForEdit input)
		{	
			//TODO: 自定义逻辑判断是否有逻辑错误

			return new CustomerModelStateValidationDto() {HasModelError = false};
		}

        #endregion

    }
}
