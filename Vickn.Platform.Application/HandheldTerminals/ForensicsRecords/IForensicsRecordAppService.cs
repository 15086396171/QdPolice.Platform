/*
* 命名空间 :     Vickn.Platform.HandheldTerminals
* 类 名  称 :      IForensicsRecordAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IForensicsRecordAppService.cs
* 描      述 :     取证记录服务接口
* 创建时间 :     2018/2/5 17:40:10
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.HandheldTerminals.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.HandheldTerminals
{
     /// <summary>
    /// 取证记录服务接口
    /// </summary>
    public interface IForensicsRecordAppService : IApplicationService
    {
        #region 取证记录管理

		/// <summary>
        /// 根据查询条件获取取证记录分页列表
        /// </summary>
        Task<PagedResultDto<ForensicsRecordDto>> GetPagedAsync(GetForensicsRecordInput input);
		
        /// <summary>
        /// 新增取证记录
        /// </summary>
        Task<ForensicsRecordForEdit> CreateAsync(ForensicsRecordForEdit input);

        /// <summary>
        /// 根据Id获取
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ForensicsRecordDto> GetByIdAsync(EntityDto<long> input);

        #endregion

    }
}
