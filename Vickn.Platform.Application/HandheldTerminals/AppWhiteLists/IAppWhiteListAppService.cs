/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.AppWhiteLists
* 类 名  称 :      IAppWhiteListAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IAppWhiteListAppService.cs
* 描      述 :     应用白名单服务接口
* 创建时间 :     2018/2/5 15:11:41
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.HandheldTerminals.AppWhiteLists.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.HandheldTerminals.AppWhiteLists
{
     /// <summary>
    /// 应用白名单服务接口
    /// </summary>
    public interface IAppWhiteListAppService : IApplicationService
    {
        #region 应用白名单管理

		/// <summary>
        /// 根据查询条件获取应用白名单分页列表
        /// </summary>
        Task<PagedResultDto<AppWhiteListDto>> GetPagedAsync(GetAppWhiteListInput input);

		 /// <summary>
        /// 通过指定id获取应用白名单Dto信息
        /// </summary>
        Task<AppWhiteListDto> GetByIdAsync(EntityDto<long> input);

        /// <summary>
        /// 通过Id获取应用白名单信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<AppWhiteListForEdit> GetForEditAsync(NullableIdDto<long> input);

        /// <summary>
        /// 新增或更改应用白名单
        /// </summary>
        Task CreateOrUpdateAsync(AppWhiteListForEdit input);

        /// <summary>
        /// 新增应用白名单
        /// </summary>
        Task<AppWhiteListForEdit> CreateAsync(AppWhiteListForEdit input);

        /// <summary>
        /// 修改应用白名单
        /// </summary>
        Task UpdateAsync(AppWhiteListForEdit input);

        /// <summary>
        /// 删除应用白名单
        /// </summary>
        Task DeleteAsync(EntityDto<long> input);

        /// <summary>
        /// 批量删除应用白名单
        /// </summary>
        Task BatchDeleteAsync(List<long> input);

        /// <summary>
        /// 自定义检查应用白名单输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(AppWhiteListForEdit input);

        #endregion

    }
}
