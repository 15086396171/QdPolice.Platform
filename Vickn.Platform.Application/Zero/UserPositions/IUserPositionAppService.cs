/*
* 命名空间 :     Vickn.Platform.Zero.UserPositions
* 类 名  称 :      IUserPositionAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IUserPositionAppService.cs
* 描      述 :     职位信息服务接口
* 创建时间 :     2018/5/16 9:57:53
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.Zero.UserPositions.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.Zero.UserPositions
{
     /// <summary>
    /// 职位信息服务接口
    /// </summary>
    public interface IUserPositionAppService : IApplicationService
    {
        #region 职位信息管理

		/// <summary>
        /// 根据查询条件获取职位信息分页列表
        /// </summary>
        Task<PagedResultDto<UserPositionDto>> GetPagedAsync(GetUserPositionInput input);

		 /// <summary>
        /// 通过指定id获取职位信息Dto信息
        /// </summary>
        Task<UserPositionDto> GetByIdAsync(EntityDto<long> input);

        /// <summary>
        /// 通过Id获取职位信息信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<UserPositionForEdit> GetForEditAsync(NullableIdDto<long> input);

        /// <summary>
        /// 新增或更改职位信息
        /// </summary>
        Task CreateOrUpdateAsync(UserPositionForEdit input);

        /// <summary>
        /// 新增职位信息
        /// </summary>
        Task<UserPositionForEdit> CreateAsync(UserPositionForEdit input);

        /// <summary>
        /// 修改职位信息
        /// </summary>
        Task UpdateAsync(UserPositionForEdit input);

        /// <summary>
        /// 删除职位信息
        /// </summary>
        Task DeleteAsync(EntityDto<long> input);

        /// <summary>
        /// 批量删除职位信息
        /// </summary>
        Task BatchDeleteAsync(List<long> input);

        /// <summary>
        /// 自定义检查职位信息输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(UserPositionForEdit input);

        /// <summary>
        /// 获取所有职位信息
        /// </summary>
        /// <returns></returns>
        Task<List<UserPositionDto>> GetAllListAsync();

        #endregion

    }
}
