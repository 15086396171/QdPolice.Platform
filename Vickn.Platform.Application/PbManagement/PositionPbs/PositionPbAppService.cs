/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbs
* 类 名  称 :      PositionPbAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionPbAppService.cs
* 描      述 :     单个岗位下排班时间服务
* 创建时间 :     2018/5/7 13:34:38
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
using Vickn.Platform.Attendences.KqDetails.Dtos;
using Vickn.Platform.Dtos;
using Vickn.Platform.PbManagement.PositionPbs.Authorization;
using Vickn.Platform.PbManagement.PositionPbs.Dtos;
using Vickn.Platform.PbManagement.PositionPbTimes;
using Vickn.Platform.PbManagement.Positions;

namespace Vickn.Platform.PbManagement.PositionPbs
{
    /// <summary>
    /// 单个岗位下排班时间服务
    /// </summary>
    [AbpAuthorize(PositionPbAppPermissions.PositionPb)]
    public class PositionPbAppService : PlatformAppServiceBase, IPositionPbAppService
    {
        private readonly PositionPbManager _positionPbManager;
        private readonly IRepository<PositionPb, int> _positionPbRepository;
        private readonly IRepository<Position, int> _positionRepository;
        private readonly IRepository<PositionPbTime, int> _positionPbTimeRepository;


        /// <summary>
        /// 初始化单个岗位下排班时间服务实例
        /// </summary>
        public PositionPbAppService(IRepository<PositionPb, int> positionPbRepository, PositionPbManager positionPbManager, IRepository<Position, int> positionRepository, IRepository<PositionPbTime, int> positionPbTimeRepository)
        {
            _positionPbRepository = positionPbRepository;
            _positionPbManager = positionPbManager;
            _positionRepository = positionRepository;
            _positionPbTimeRepository = positionPbTimeRepository;
        }

        #region 单个岗位下排班时间管理

        /// <summary>
        /// 根据查询条件获取单个岗位下排班时间分页列表
        /// </summary>
        public async Task<PagedResultDto<PositionPbDto>> GetPagedAsync(GetPositionPbInput input)
        {
            var query = _positionPbRepository.GetAll();


            //TODO:根据传入的参数添加过滤条件

            var positionPbCount = await query.CountAsync();

            var positionPbs = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var positionPbDtos = positionPbs.MapTo<List<PositionPbDto>>();
            return new PagedResultDto<PositionPbDto>(
            positionPbCount,
            positionPbDtos
            );
        }

        /// <summary>
        /// 通过指定id获取单个岗位下排班时间Dto信息
        /// </summary>
        public async Task<PositionPbDto> GetByIdAsync(EntityDto<int> input)
        {
            var entity = await _positionPbRepository.GetAsync(input.Id);
            return entity.MapTo<PositionPbDto>();
        }

        /// <summary>
        /// 通过Id获取单个岗位下排班时间信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<PositionPbForEdit> GetForEditAsync(NullableIdDto<int> input)
        {
            PositionPbEditDto positionPbEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _positionPbRepository.GetAsync(input.Id.Value);
                positionPbEditDto = entity.MapTo<PositionPbEditDto>();
            }
            else
            {
                positionPbEditDto = new PositionPbEditDto();
            }
            return new PositionPbForEdit { PositionPbEditDto = positionPbEditDto };
        }

        /// <summary>
        /// 新增或更改单个岗位下排班时间
        /// </summary>
		[AbpAuthorize(PositionPbAppPermissions.PositionPb_CreatePositionPb, PositionPbAppPermissions.PositionPb_EditPositionPb)]
        public async Task CreateOrUpdateAsync(PositionPbForEdit input)
        {
            if (input.PositionPbEditDto.Id != 0)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
        }

        /// <summary>
        /// 新增单个岗位下排班时间
        /// </summary>
		[AbpAuthorize(PositionPbAppPermissions.PositionPb_CreatePositionPb)]
        public async Task<PositionPbForEdit> CreateAsync(PositionPbForEdit input)
        {
            //TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.PositionPbEditDto.MapTo<PositionPb>();

            entity = await _positionPbRepository.InsertAsync(entity);
            return new PositionPbForEdit { PositionPbEditDto = entity.MapTo<PositionPbEditDto>() };
        }

        /// <summary>
        /// 修改单个岗位下排班时间
        /// </summary>
		[AbpAuthorize(PositionPbAppPermissions.PositionPb_EditPositionPb)]
        public async Task UpdateAsync(PositionPbForEdit input)
        {
            //TODO: 更新前的逻辑判断，是否允许更新

            var entity = await _positionPbRepository.GetAsync(input.PositionPbEditDto.Id);
            input.PositionPbEditDto.MapTo(entity);

            await _positionPbRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除单个岗位下排班时间
        /// </summary>
		[AbpAuthorize(PositionPbAppPermissions.PositionPb_DeletePositionPb)]
        public async Task DeleteAsync(EntityDto<int> input)
        {
            //TODO: 删除前的逻辑判断，是否允许删除

            await _positionPbRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除单个岗位下排班时间
        /// </summary>
		[AbpAuthorize(PositionPbAppPermissions.PositionPb_DeletePositionPb)]
        public async Task BatchDeleteAsync(List<int> input)
        {
            //TODO: 批量删除前的逻辑判断，是否允许删除

            await _positionPbRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        /// <summary>
        /// 自定义检查单个岗位下排班时间输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(PositionPbForEdit input)
        {
            //TODO: 自定义逻辑判断是否有逻辑错误

            return new CustomerModelStateValidationDto() { HasModelError = false };
        }

        /// <summary>
        /// 排班信息导入
        /// </summary>
        public async Task<ResultDto> PbImportAsync(PositionPbEditDto input)
        {
            var entity = input.MapTo<PositionPb>();

            entity = await _positionPbRepository.InsertAsync(entity);
            return new ResultDto() { IsOk = true };
        }


        /// <summary>
        /// 查看岗位排班信息
        /// </summary>
        public async Task<PositionPbListForEdit> GetPositionPbListAsync(GetPositonPbListInput input)
        {
            var query =await _positionPbRepository.GetAllListAsync(p => p.PbPositionId == input.PbPositionId);
            string queryCount = query.ToList().Count().ToString();
            string nowDateMonth = query[0].DutyDate.ToString("yyyy年MM月");

            List<PositionPbListDto> positionPbList = new List<PositionPbListDto>();
            foreach (var item in query)
            {
                PositionPbListDto positionPb = new PositionPbListDto();
                positionPb.Id = item.Id;
                positionPb.PbPositionId = item.PbPositionId;
                positionPb.DutyDate = item.DutyDate;

                var positionTimes =await _positionPbTimeRepository.GetAllListAsync(p => p.PositionPbId == item.Id);

                List<PositionTimeListDto> postionTimeList = new List<PositionTimeListDto>();

                foreach (var item2 in positionTimes)
                {
                    PositionTimeListDto positionTime = new PositionTimeListDto();
                    positionTime.PositionPbId = item2.PositionPbId;
                    positionTime.StartTime = item2.StartTime.ToString("HH:mm");
                    positionTime.EndTime = item2.EndTime.ToString("HH:mm");
                    positionTime.UserName = item2.RealName;
                    postionTimeList.Add(positionTime);
                }

                positionPb.PositionPbTimes = postionTimeList;
               
                positionPbList.Add(positionPb);
            }

            return new PositionPbListForEdit { PositionPbListDtos = positionPbList,Count=queryCount,NowDateMonth= nowDateMonth };
        }

        #endregion

    }
}
