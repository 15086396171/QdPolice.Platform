/*
* 命名空间 :     Vickn.Platform.DataDictionaries
* 类 名  称 :      IDataDictionaryAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IDataDictionaryAppService.cs
* 描      述 :     数据字典服务接口
* 创建时间 :     2017/6/12 16:41:31
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
    /// 数据字典服务接口
    /// </summary>
    public interface IDataDictionaryAppService : IApplicationService
    {
        #region 数据字典管理

		/// <summary>
        /// 根据查询条件获取数据字典分页列表
        /// </summary>
        Task<PagedResultDto<DataDictionaryDto>> GetPagedAsync(GetDataDictionaryInput input);

		 /// <summary>
        /// 通过指定id获取数据字典Dto信息
        /// </summary>
        Task<DataDictionaryDto> GetByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 通过Id获取数据字典信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<DataDictionaryForEdit> GetForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 新增或更改数据字典
        /// </summary>
        Task CreateOrUpdateAsync(DataDictionaryForEdit input);

        /// <summary>
        /// 新增数据字典
        /// </summary>
        Task<DataDictionaryForEdit> CreateAsync(DataDictionaryForEdit input);

        /// <summary>
        /// 修改数据字典
        /// </summary>
        Task UpdateAsync(DataDictionaryForEdit input);

        /// <summary>
        /// 删除数据字典
        /// </summary>
        Task DeleteAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除数据字典
        /// </summary>
        Task BatchDeleteAsync(List<int> input);

        /// <summary>
        /// 自定义检查数据字典输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(DataDictionaryForEdit input);

        #endregion

    }
}
