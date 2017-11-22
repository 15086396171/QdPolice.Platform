/*
* 命名空间 :     Vickn.Platform.FileRecords
* 类 名  称 :      FileRecordAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     FileRecordAppService.cs
* 描      述 :     文件记录服务
* 创建时间 :     2017/8/13 22:00:25
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
using Vickn.Platform.FileRecords.Authorization;
using Vickn.Platform.FileRecords.Dtos;

namespace Vickn.Platform.FileRecords
{
    /// <summary>
    /// 文件记录服务
    /// </summary>
    public class FileRecordAppService : PlatformAppServiceBase, IFileRecordAppService
    {
        private readonly IRepository<FileRecord, int> _fileRecordRepository;
        private readonly FileRecordManager _fileRecordManager;

        /// <summary>
        /// 初始化文件记录服务实例
        /// </summary>
        public FileRecordAppService(IRepository<FileRecord, int> fileRecordRepository, FileRecordManager fileRecordManager)
        {
            _fileRecordRepository = fileRecordRepository;
            _fileRecordManager = fileRecordManager;
        }

        #region 文件记录管理

        /// <summary>
        /// 根据查询条件获取文件记录分页列表
        /// </summary>
        public async Task<PagedResultDto<FileRecordDto>> GetPagedAsync(GetFileRecordInput input)
        {
            var query = _fileRecordRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件

            query = query.Where(p => p.FileId == input.FileId);

            var fileRecordCount = await query.CountAsync();

            var fileRecords = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var fileRecordDtos = fileRecords.MapTo<List<FileRecordDto>>();
            return new PagedResultDto<FileRecordDto>(
            fileRecordCount,
            fileRecordDtos
            );
        }

        /// <summary>
        /// 通过指定id获取文件记录Dto信息
        /// </summary>
        public async Task<FileRecordDto> GetByIdAsync(EntityDto<int> input)
        {
            var entity = await _fileRecordRepository.GetAsync(input.Id);
            return entity.MapTo<FileRecordDto>();
        }

        /// <summary>
        /// 通过Id获取文件记录信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<FileRecordForEdit> GetForEditAsync(NullableIdDto<int> input)
        {
            FileRecordEditDto fileRecordEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _fileRecordRepository.GetAsync(input.Id.Value);
                fileRecordEditDto = entity.MapTo<FileRecordEditDto>();
            }
            else
            {
                fileRecordEditDto = new FileRecordEditDto();
            }
            return new FileRecordForEdit { FileRecordEditDto = fileRecordEditDto };
        }

        /// <summary>
        /// 新增或更改文件记录
        /// </summary>
        public async Task CreateOrUpdateAsync(FileRecordForEdit input)
        {
            if (input.FileRecordEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
        }

        /// <summary>
        /// 新增文件记录
        /// </summary>
        public async Task<FileRecordForEdit> CreateAsync(FileRecordForEdit input)
        {
            //TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.FileRecordEditDto.MapTo<FileRecord>();

            var id = await _fileRecordRepository.InsertAndGetIdAsync(entity);
            var dto = entity.MapTo<FileRecordEditDto>();
            dto.Id = id;
            return new FileRecordForEdit { FileRecordEditDto = dto };
        }

        /// <summary>
        /// 修改文件记录
        /// </summary>
        public async Task UpdateAsync(FileRecordForEdit input)
        {
            //TODO: 更新前的逻辑判断，是否允许更新

            var entity = await _fileRecordRepository.GetAsync(input.FileRecordEditDto.Id.Value);
            input.FileRecordEditDto.MapTo(entity);

            await _fileRecordRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除文件记录
        /// </summary>
        public async Task DeleteAsync(EntityDto<int> input)
        {
            //TODO: 删除前的逻辑判断，是否允许删除

            await _fileRecordRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除文件记录
        /// </summary>
        public async Task BatchDeleteAsync(List<int> input)
        {
            //TODO: 批量删除前的逻辑判断，是否允许删除

            await _fileRecordRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        /// <summary>
        /// 自定义检查文件记录输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(FileRecordForEdit input)
        {
            //TODO: 自定义逻辑判断是否有逻辑错误

            return new CustomerModelStateValidationDto() { HasModelError = false };
        }

        #endregion

    }
}
