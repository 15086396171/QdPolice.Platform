/*
* 命名空间 :     Vickn.Platform.DataDictionaries
* 类 名  称 :      DataDictionaryAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     DataDictionaryAppService.cs
* 描      述 :     数据字典服务
* 创建时间 :     2017/6/12 16:41:32
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
    /// 数据字典服务
    /// </summary>
    [AbpAuthorize(DataDictionaryAppPermissions.DataDictionary)]
    public class DataDictionaryAppService : PlatformAppServiceBase, IDataDictionaryAppService
    {
        private readonly IRepository<DataDictionary, int> _dataDictionaryRepository;
        private readonly DataDictionaryManager _dataDictionaryManager;

        /// <summary>
        /// 初始化数据字典服务实例
        /// </summary>
        public DataDictionaryAppService(IRepository<DataDictionary, int> dataDictionaryRepository, DataDictionaryManager dataDictionaryManager)
        {
            _dataDictionaryRepository = dataDictionaryRepository;
            _dataDictionaryManager = dataDictionaryManager;
        }

        #region 数据字典管理

        /// <summary>
        /// 根据字典键名获取键值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ListResultDto<DataDictionaryItem>> GetDataDictionaryItemsByDicName(GetDataDictoryItemsByDicKeyInput input)
        {
            var dataDictionary = await _dataDictionaryRepository.FirstOrDefaultAsync(p => p.Key == input.DicKey);
            return new ListResultDto<DataDictionaryItem>(dataDictionary.DataDictionaryItems.MapTo<List<DataDictionaryItem>>());
        }

        /// <summary>
        /// 根据查询条件获取数据字典分页列表
        /// </summary>
        public async Task<PagedResultDto<DataDictionaryDto>> GetPagedAsync(GetDataDictionaryInput input)
        {
            var query = _dataDictionaryRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件

            query = query.WhereIf(!input.DisplayName.IsNullOrEmpty(), p => p.DisplayName.Contains(input.DisplayName));

            var dataDictionaryCount = await query.CountAsync();

            var dataDictionarys = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var dataDictionaryDtos = dataDictionarys.MapTo<List<DataDictionaryDto>>();
            return new PagedResultDto<DataDictionaryDto>(
            dataDictionaryCount,
            dataDictionaryDtos
            );
        }

        /// <summary>
        /// 通过指定id获取数据字典Dto信息
        /// </summary>
        public async Task<DataDictionaryDto> GetByIdAsync(EntityDto<int> input)
        {
            var entity = await _dataDictionaryRepository.GetAsync(input.Id);
            return entity.MapTo<DataDictionaryDto>();
        }

        /// <summary>
        /// 通过Id获取数据字典信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<DataDictionaryForEdit> GetForEditAsync(NullableIdDto<int> input)
        {
            DataDictionaryEditDto dataDictionaryEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _dataDictionaryRepository.GetAsync(input.Id.Value);
                dataDictionaryEditDto = entity.MapTo<DataDictionaryEditDto>();
            }
            else
            {
                dataDictionaryEditDto = new DataDictionaryEditDto();
            }
            return new DataDictionaryForEdit { DataDictionaryEditDto = dataDictionaryEditDto };
        }

        /// <summary>
        /// 新增或更改数据字典
        /// </summary>
        public async Task CreateOrUpdateAsync(DataDictionaryForEdit input)
        {
            if (input.DataDictionaryEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
        }

        /// <summary>
        /// 新增数据字典
        /// </summary>
		[AbpAuthorize(DataDictionaryAppPermissions.DataDictionary_CreateDataDictionary)]
        public async Task<DataDictionaryForEdit> CreateAsync(DataDictionaryForEdit input)
        {
            //TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.DataDictionaryEditDto.MapTo<DataDictionary>();

            entity = await _dataDictionaryRepository.InsertAsync(entity);
            return new DataDictionaryForEdit { DataDictionaryEditDto = entity.MapTo<DataDictionaryEditDto>() };
        }

        /// <summary>
        /// 修改数据字典
        /// </summary>
		[AbpAuthorize(DataDictionaryAppPermissions.DataDictionary_EditDataDictionary)]
        public async Task UpdateAsync(DataDictionaryForEdit input)
        {
            //TODO: 更新前的逻辑判断，是否允许更新

            var entity = await _dataDictionaryRepository.GetAsync(input.DataDictionaryEditDto.Id.Value);
            input.DataDictionaryEditDto.MapTo(entity);

            await _dataDictionaryRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除数据字典
        /// </summary>
		[AbpAuthorize(DataDictionaryAppPermissions.DataDictionary_DeleteDataDictionary)]
        public async Task DeleteAsync(EntityDto<int> input)
        {
            //TODO: 删除前的逻辑判断，是否允许删除

            await _dataDictionaryRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除数据字典
        /// </summary>
		[AbpAuthorize(DataDictionaryAppPermissions.DataDictionary_DeleteDataDictionary)]
        public async Task BatchDeleteAsync(List<int> input)
        {
            //TODO: 批量删除前的逻辑判断，是否允许删除

            await _dataDictionaryRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        /// <summary>
        /// 自定义检查数据字典输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(DataDictionaryForEdit input)
        {
            //TODO: 自定义逻辑判断是否有逻辑错误

            if (
                _dataDictionaryRepository.FirstOrDefault(
                    p => p.Key == input.DataDictionaryEditDto.Key && p.Id != input.DataDictionaryEditDto.Id) != null)
                return new CustomerModelStateValidationDto()
                {
                    HasModelError = true,
                    Key = "DataDictionaryEditDto.Key",
                    ErrorMessage = "键名不能重复"
                };

            return new CustomerModelStateValidationDto() { HasModelError = false };
        }

        #endregion

    }
}
