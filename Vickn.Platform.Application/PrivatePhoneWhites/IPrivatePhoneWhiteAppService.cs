/*
* 命名空间 :     Vickn.Platform.PrivatePhoneWhites
* 类 名  称 :      IPrivatePhoneWhiteAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IPrivatePhoneWhiteAppService.cs
* 描      述 :     个人白名单服务接口
* 创建时间 :     2018/2/23 14:15:14
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.PrivatePhoneWhites.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.PrivatePhoneWhites
{
     /// <summary>
    /// 个人白名单服务接口
    /// </summary>
    public interface IPrivatePhoneWhiteAppService : IApplicationService
    {
        #region 个人白名单管理

		/// <summary>
        /// 根据查询条件获取个人白名单分页列表
        /// </summary>
        Task<PagedResultDto<PrivatePhoneWhiteDto>> GetPagedAsync(GetPrivatePhoneWhiteInput input);

		 /// <summary>
        /// 通过指定id获取个人白名单Dto信息
        /// </summary>
        Task<PrivatePhoneWhiteDto> GetByIdAsync(EntityDto<long> input);

        /// <summary>
        /// 通过Id获取个人白名单信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<PrivatePhoneWhiteForEdit> GetForEditAsync(NullableIdDto<long> input);

        /// <summary>
        /// 新增或更改个人白名单
        /// </summary>
        Task CreateOrUpdateAsync(PrivatePhoneWhiteForEdit input);

        /// <summary>
        /// 新增个人白名单
        /// </summary>
        Task<PrivatePhoneWhiteForEdit> CreateAsync(PrivatePhoneWhiteForEdit input);

        /// <summary>
        /// 修改个人白名单
        /// </summary>
        Task UpdateAsync(PrivatePhoneWhiteForEdit input);

        /// <summary>
        /// 删除个人白名单
        /// </summary>
        Task DeleteAsync(EntityDto<long> input);

        /// <summary>
        /// 批量删除个人白名单
        /// </summary>
        Task BatchDeleteAsync(List<long> input);

        /// <summary>
        /// 自定义检查个人白名单输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(PrivatePhoneWhiteForEdit input);

        #endregion

    }
}
