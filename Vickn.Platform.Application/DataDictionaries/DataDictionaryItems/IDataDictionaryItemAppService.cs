/*
* 命名空间 :     Vickn.Platform.DataDictionaries
* 类 名  称 :      IDataDictionaryItemAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IDataDictionaryItemAppService.cs
* 描      述 :     数据字典项服务接口
* 创建时间 :     2017/6/12 16:57:19
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.DataDictionaries.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.DataDictionaries
{
     /// <summary>
    /// 数据字典项服务接口
    /// </summary>
    public interface IDataDictionaryItemAppService : IApplicationService
    {
        #region 数据字典项管理

		/// <summary>
        /// 根据查询条件获取数据字典项分页列表
        /// </summary>
        Task<PagedResultDto<DataDictionaryItemDto>> GetPagedAsync(GetDataDictionaryItemInput input);

		 /// <summary>
        /// 通过指定id获取数据字典项Dto信息
        /// </summary>
        Task<DataDictionaryItemDto> GetByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 通过Id获取数据字典项信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<DataDictionaryItemForEdit> GetForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 新增或更改数据字典项
        /// </summary>
        Task CreateOrUpdateAsync(DataDictionaryItemForEdit input);

        /// <summary>
        /// 新增数据字典项
        /// </summary>
        Task<DataDictionaryItemForEdit> CreateAsync(DataDictionaryItemForEdit input);

        /// <summary>
        /// 修改数据字典项
        /// </summary>
        Task UpdateAsync(DataDictionaryItemForEdit input);

        /// <summary>
        /// 删除数据字典项
        /// </summary>
        Task DeleteAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除数据字典项
        /// </summary>
        Task BatchDeleteAsync(List<int> input);

        /// <summary>
        /// 自定义检查数据字典项输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(DataDictionaryItemForEdit input);

        #endregion

    }
}
