/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.AppWhiteLists
* 类 名  称 :      AppWhiteListAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     AppWhiteListAppService.cs
* 描      述 :     应用白名单服务
* 创建时间 :     2018/2/5 15:11:42
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
using Vickn.Platform.HandheldTerminals.AppWhiteLists.Authorization;
using Vickn.Platform.HandheldTerminals.AppWhiteLists.Dtos;

namespace Vickn.Platform.HandheldTerminals.AppWhiteLists
{
    /// <summary>
    /// 应用白名单服务
    /// </summary>
    [AbpAuthorize(AppWhiteListAppPermissions.AppWhiteList)]
    public class AppWhiteListAppService : PlatformAppServiceBase, IAppWhiteListAppService
    {
        private readonly IRepository<AppWhiteList, long> _appWhiteListRepository;
        private readonly AppWhiteListManager _appWhiteListManager;

        /// <summary>
        /// 初始化应用白名单服务实例
        /// </summary>
        public AppWhiteListAppService(IRepository<AppWhiteList, long> appWhiteListRepository, AppWhiteListManager appWhiteListManager)
        {
            _appWhiteListRepository = appWhiteListRepository;
            _appWhiteListManager = appWhiteListManager;
        }

        #region 应用白名单管理

        /// <summary>
        /// 根据查询条件获取应用白名单分页列表
        /// </summary>
        public async Task<PagedResultDto<AppWhiteListDto>> GetPagedAsync(GetAppWhiteListInput input)
        {
            var query = _appWhiteListRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件

            query = query.WhereIf(!input.FilterText.IsNullOrEmpty(), p => p.Name.Contains(input.FilterText) ||
                                                                          p.PackageName.Contains(input.FilterText));

            var appWhiteListCount = await query.CountAsync();

            var appWhiteLists = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var appWhiteListDtos = appWhiteLists.MapTo<List<AppWhiteListDto>>();
            return new PagedResultDto<AppWhiteListDto>(
            appWhiteListCount,
            appWhiteListDtos
            );
        }

        /// <summary>
        /// 通过指定id获取应用白名单Dto信息
        /// </summary>
        public async Task<AppWhiteListDto> GetByIdAsync(EntityDto<long> input)
        {
            var entity = await _appWhiteListRepository.GetAsync(input.Id);
            return entity.MapTo<AppWhiteListDto>();
        }

        /// <summary>
        /// 通过Id获取应用白名单信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<AppWhiteListForEdit> GetForEditAsync(NullableIdDto<long> input)
        {
            AppWhiteListEditDto appWhiteListEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _appWhiteListRepository.GetAsync(input.Id.Value);
                appWhiteListEditDto = entity.MapTo<AppWhiteListEditDto>();
            }
            else
            {
                appWhiteListEditDto = new AppWhiteListEditDto();
            }
            return new AppWhiteListForEdit { AppWhiteListEditDto = appWhiteListEditDto };
        }

        /// <summary>
        /// 新增或更改应用白名单
        /// </summary>
		[AbpAuthorize(AppWhiteListAppPermissions.AppWhiteList_CreateAppWhiteList, AppWhiteListAppPermissions.AppWhiteList_EditAppWhiteList)]
        public async Task CreateOrUpdateAsync(AppWhiteListForEdit input)
        {
            if (input.AppWhiteListEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
        }

        /// <summary>
        /// 新增应用白名单
        /// </summary>
		[AbpAuthorize(AppWhiteListAppPermissions.AppWhiteList_CreateAppWhiteList)]
        public async Task<AppWhiteListForEdit> CreateAsync(AppWhiteListForEdit input)
        {
            //TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.AppWhiteListEditDto.MapTo<AppWhiteList>();

            entity = await _appWhiteListRepository.InsertAsync(entity);
            return new AppWhiteListForEdit { AppWhiteListEditDto = entity.MapTo<AppWhiteListEditDto>() };
        }

        /// <summary>
        /// 修改应用白名单
        /// </summary>
		[AbpAuthorize(AppWhiteListAppPermissions.AppWhiteList_EditAppWhiteList)]
        public async Task UpdateAsync(AppWhiteListForEdit input)
        {
            //TODO: 更新前的逻辑判断，是否允许更新

            var entity = await _appWhiteListRepository.GetAsync(input.AppWhiteListEditDto.Id.Value);
            input.AppWhiteListEditDto.MapTo(entity);

            await _appWhiteListRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除应用白名单
        /// </summary>
		[AbpAuthorize(AppWhiteListAppPermissions.AppWhiteList_DeleteAppWhiteList)]
        public async Task DeleteAsync(EntityDto<long> input)
        {
            //TODO: 删除前的逻辑判断，是否允许删除

            await _appWhiteListRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除应用白名单
        /// </summary>
		[AbpAuthorize(AppWhiteListAppPermissions.AppWhiteList_DeleteAppWhiteList)]
        public async Task BatchDeleteAsync(List<long> input)
        {
            //TODO: 批量删除前的逻辑判断，是否允许删除

            await _appWhiteListRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        /// <summary>
        /// 自定义检查应用白名单输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(AppWhiteListForEdit input)
        {
            //TODO: 自定义逻辑判断是否有逻辑错误

            return new CustomerModelStateValidationDto() { HasModelError = false };
        }

        #endregion

    }
}
