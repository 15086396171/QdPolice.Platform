/*
* 命名空间 :     Vickn.Platform.PbManagement.ChangWorks
* 类 名  称 :      IChangeWorkAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IChangeWorkAppService.cs
* 描      述 :     换班服务接口
* 创建时间 :     2018/5/14 9:16:04
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.PbManagement.ChangeWorks.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.PbManagement.ChangeWorks
{
    /// <summary>
    /// 换班服务接口
    /// </summary>
    public interface IChangeWorkAppService : IApplicationService
    {
        #region 换班管理

        /// <summary>
        /// 根据查询条件获取换班分页列表
        /// </summary>
        Task<PagedResultDto<ChangeWorkDto>> GetPagedAsync(GetChangeWorkInput input);

        /// <summary>
        /// 通过指定id获取换班Dto信息
        /// </summary>
        Task<ChangeWorkDto> GetByIdAsync(EntityDto<long> input);

        /// <summary>
        /// 通过Id获取换班信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<ChangeWorkForEdit> GetForEditAsync(NullableIdDto<long> input);

        /// <summary>
        /// 新增或更改换班
        /// </summary>
        Task CreateOrUpdateAsync(ChangeWorkForEdit input);

        /// <summary>
        /// 新增换班
        /// </summary>
        Task<ChangeWorkForEdit> CreateAsync(ChangeWorkForEdit input);

        /// <summary>
        /// 修改换班
        /// </summary>
        Task UpdateAsync(ChangeWorkForEdit input);



        /// <summary>
        /// 删除换班
        /// </summary>
        Task DeleteAsync(EntityDto<long> input);

        /// <summary>
        /// 批量删除换班
        /// </summary>
        Task BatchDeleteAsync(List<long> input);

        /// <summary>
        /// 自定义检查换班输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(ChangeWorkForEdit input);

        /// <summary>
        /// app获取换班数据
        /// </summary>
        Task<AppChangeWorkEditDto> AppGetChangeWorkDto();




        #endregion

        #region 业务逻辑处理

        /// <summary>
        /// 领导同意换班
        /// </summary>
        Task LeaderAgreeChangeWorkAsync(ChangeWorkForEdit input);

        /// <summary>
        /// 领导不同意换班
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task LeaderNotAgreeChangeWorkAsync(ChangeWorkForEdit input);

        #endregion

    }
}
