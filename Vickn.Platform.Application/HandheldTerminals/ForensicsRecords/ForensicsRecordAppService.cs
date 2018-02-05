/*
* 命名空间 :     Vickn.Platform.HandheldTerminals
* 类 名  称 :      ForensicsRecordAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     ForensicsRecordAppService.cs
* 描      述 :     取证记录服务
* 创建时间 :     2018/2/5 17:40:10
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
using Abp.IO;
using Abp.Linq.Extensions;
using Vickn.PlatfForm.Utils.Extensions;
using Vickn.Platform.Dtos;
using Vickn.Platform.HandheldTerminals.Authorization;
using Vickn.Platform.HandheldTerminals.Dtos;
using Vickn.Platform.MainTenance.AppFolders;

namespace Vickn.Platform.HandheldTerminals
{
    /// <summary>
    /// 取证记录服务
    /// </summary>
    [AbpAuthorize(ForensicsRecordAppPermissions.ForensicsRecord)]
    public class ForensicsRecordAppService : PlatformAppServiceBase, IForensicsRecordAppService
    {
        private readonly IRepository<ForensicsRecord, long> _forensicsRecordRepository;
        private readonly ForensicsRecordManager _forensicsRecordManager;
        private IAppFolders _appFolders;

        /// <summary>
        /// 初始化取证记录服务实例
        /// </summary>
        public ForensicsRecordAppService(IRepository<ForensicsRecord, long> forensicsRecordRepository, ForensicsRecordManager forensicsRecordManager, IAppFolders appFolders)
        {
            _forensicsRecordRepository = forensicsRecordRepository;
            _forensicsRecordManager = forensicsRecordManager;
            _appFolders = appFolders;
        }

        #region 取证记录管理

        /// <summary>
        /// 根据查询条件获取取证记录分页列表
        /// </summary>
        public async Task<PagedResultDto<ForensicsRecordDto>> GetPagedAsync(GetForensicsRecordInput input)
        {
            var query = _forensicsRecordRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件

            var forensicsRecordCount = await query.CountAsync();

            var forensicsRecords = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var forensicsRecordDtos = forensicsRecords.MapTo<List<ForensicsRecordDto>>();
            return new PagedResultDto<ForensicsRecordDto>(
            forensicsRecordCount,
            forensicsRecordDtos
            );
        }

        /// <summary>
        /// 新增取证记录
        /// </summary>
        [AbpAuthorize(ForensicsRecordAppPermissions.ForensicsRecord_CreateForensicsRecord)]
        public async Task<ForensicsRecordForEdit> CreateAsync(ForensicsRecordForEdit input)
        {
            //TODO: 新增前的逻辑判断，是否允许新增
            var entity = input.ForensicsRecordEditDto.MapTo<ForensicsRecord>();

            entity.DeviceId = AbpSession.GetDeviceId().Value;    

            entity = await _forensicsRecordRepository.InsertAsync(entity);
            return new ForensicsRecordForEdit { ForensicsRecordEditDto = entity.MapTo<ForensicsRecordEditDto>() };
        }
        #endregion

    }
}
