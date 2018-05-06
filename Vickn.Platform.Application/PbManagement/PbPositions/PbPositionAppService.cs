/*
* 命名空间 :     Vickn.Platform.PbManagement.PbPositions
* 类 名  称 :      PbPositionAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbPositionAppService.cs
* 描      述 :     排班岗位服务
* 创建时间 :     2018/5/6 15:05:52
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
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;

using Vickn.Platform.Dtos;
using Vickn.Platform.PbManagement.PbPositions.Authorization;
using Vickn.Platform.PbManagement.PbPositions.Dtos;

namespace Vickn.Platform.PbManagement.PbPositions
{
    /// <summary>
    /// 排班岗位服务
    /// </summary>
    [AbpAuthorize(PbPositionAppPermissions.PbPosition)]
    public class PbPositionAppService : PlatformAppServiceBase, IPbPositionAppService
    {
        private readonly IRepository<PbPosition, int> _pbPositionRepository;
        private readonly PbPositionManager _pbPositionManager;

        /// <summary>
        /// 初始化排班岗位服务实例
        /// </summary>
        public PbPositionAppService(IRepository<PbPosition, int> pbPositionRepository, PbPositionManager pbPositionManager)
        {
            _pbPositionRepository = pbPositionRepository;
            _pbPositionManager = pbPositionManager;
        }

        #region 排班岗位管理

        /// <summary>
        /// 根据查询条件获取排班岗位分页列表
        /// </summary>
        public async Task<PagedResultDto<PbPositionDto>> GetPagedAsync(GetPbPositionInput input)
        {
            var query = _pbPositionRepository.GetAll().Where(p => p.PbTitleId == input.PbTitleId);

            if (!query.Any())
            {
                await _pbPositionManager.GeneratePoPositions(input.PbTitleId);
                await UnitOfWorkManager.Current.SaveChangesAsync();
            }

            query = _pbPositionRepository.GetAll().Where(p => p.PbTitleId == input.PbTitleId);
            //TODO:根据传入的参数添加过滤条件

            var pbPositionCount = await query.CountAsync();

            var pbPositions = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var pbPositionDtos = pbPositions.MapTo<List<PbPositionDto>>();
            return new PagedResultDto<PbPositionDto>(
            pbPositionCount,
            pbPositionDtos
            );
        }

        /// <summary>
        /// 通过指定id获取排班岗位Dto信息
        /// </summary>
        public async Task<PbPositionDto> GetByIdAsync(EntityDto<int> input)
        {
            var entity = await _pbPositionRepository.GetAsync(input.Id);
            return entity.MapTo<PbPositionDto>();
        }

        /// <summary>
        /// 通过Id获取排班岗位信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<PbPositionForEdit> GetForEditAsync(NullableIdDto<int> input)
        {
            PbPositionEditDto pbPositionEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _pbPositionRepository.GetAsync(input.Id.Value);
                pbPositionEditDto = entity.MapTo<PbPositionEditDto>();
            }
            else
            {
                pbPositionEditDto = new PbPositionEditDto();
            }
            return new PbPositionForEdit { PbPositionEditDto = pbPositionEditDto };
        }

        /// <summary>
        /// 新增或更改排班岗位
        /// </summary>
		[AbpAuthorize(PbPositionAppPermissions.PbPosition_CreatePbPosition, PbPositionAppPermissions.PbPosition_EditPbPosition)]
        public async Task CreateOrUpdateAsync(PbPositionForEdit input)
        {
            if (input.PbPositionEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
        }

        /// <summary>
        /// 新增排班岗位
        /// </summary>
		[AbpAuthorize(PbPositionAppPermissions.PbPosition_CreatePbPosition)]
        public async Task<PbPositionForEdit> CreateAsync(PbPositionForEdit input)
        {
            //TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.PbPositionEditDto.MapTo<PbPosition>();

            entity = await _pbPositionRepository.InsertAsync(entity);
            return new PbPositionForEdit { PbPositionEditDto = entity.MapTo<PbPositionEditDto>() };
        }

        /// <summary>
        /// 修改排班岗位
        /// </summary>
		[AbpAuthorize(PbPositionAppPermissions.PbPosition_EditPbPosition)]
        public async Task UpdateAsync(PbPositionForEdit input)
        {
            //TODO: 更新前的逻辑判断，是否允许更新

            var entity = await _pbPositionRepository.GetAsync(input.PbPositionEditDto.Id.Value);
            input.PbPositionEditDto.MapTo(entity);

            await _pbPositionRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除排班岗位
        /// </summary>
		[AbpAuthorize(PbPositionAppPermissions.PbPosition_DeletePbPosition)]
        public async Task DeleteAsync(EntityDto<int> input)
        {
            //TODO: 删除前的逻辑判断，是否允许删除

            await _pbPositionRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除排班岗位
        /// </summary>
		[AbpAuthorize(PbPositionAppPermissions.PbPosition_DeletePbPosition)]
        public async Task BatchDeleteAsync(List<int> input)
        {
            //TODO: 批量删除前的逻辑判断，是否允许删除

            await _pbPositionRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        /// <summary>
        /// 自定义检查排班岗位输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(PbPositionForEdit input)
        {
            //TODO: 自定义逻辑判断是否有逻辑错误

            return new CustomerModelStateValidationDto() { HasModelError = false };
        }

        #endregion

    }
}
