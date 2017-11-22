/*
* 命名空间 :     Vickn.Platform.FileRecords
* 类 名  称 :      IFileRecordAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IFileRecordAppService.cs
* 描      述 :     文件记录服务接口
* 创建时间 :     2017/8/13 22:00:25
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.FileRecords.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.FileRecords
{
     /// <summary>
    /// 文件记录服务接口
    /// </summary>
    public interface IFileRecordAppService : IApplicationService
    {
        #region 文件记录管理

		/// <summary>
        /// 根据查询条件获取文件记录分页列表
        /// </summary>
        Task<PagedResultDto<FileRecordDto>> GetPagedAsync(GetFileRecordInput input);

		 /// <summary>
        /// 通过指定id获取文件记录Dto信息
        /// </summary>
        Task<FileRecordDto> GetByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 通过Id获取文件记录信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<FileRecordForEdit> GetForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 新增或更改文件记录
        /// </summary>
        Task CreateOrUpdateAsync(FileRecordForEdit input);

        /// <summary>
        /// 新增文件记录
        /// </summary>
        Task<FileRecordForEdit> CreateAsync(FileRecordForEdit input);

        /// <summary>
        /// 修改文件记录
        /// </summary>
        Task UpdateAsync(FileRecordForEdit input);

        /// <summary>
        /// 删除文件记录
        /// </summary>
        Task DeleteAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除文件记录
        /// </summary>
        Task BatchDeleteAsync(List<int> input);

        /// <summary>
        /// 自定义检查文件记录输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(FileRecordForEdit input);

        #endregion

    }
}
