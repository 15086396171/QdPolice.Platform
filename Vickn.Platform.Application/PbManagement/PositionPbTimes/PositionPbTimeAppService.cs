/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbTimes
* 类 名  称 :      PositionPbTimeAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionPbTimeAppService.cs
* 描      述 :     当天上下班时间服务
* 创建时间 :     2018/5/8 13:47:37
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
using Vickn.Platform.PbManagement.PositionPbMaps;
using Vickn.Platform.PbManagement.PositionPbMaps.Dtos;
using Vickn.Platform.PbManagement.PositionPbs;
using Vickn.Platform.PbManagement.PositionPbTimes.Authorization;
using Vickn.Platform.PbManagement.PositionPbTimes.Dtos;
using Vickn.Platform.Users;

namespace Vickn.Platform.PbManagement.PositionPbTimes
{
    /// <summary>
    /// 当天上下班时间服务
    /// </summary>
    [AbpAuthorize(PositionPbTimeAppPermissions.PositionPbTime)]
    public class PositionPbTimeAppService : PlatformAppServiceBase, IPositionPbTimeAppService
    {
        private readonly IRepository<PositionPbTime, int> _positionPbTimeRepository;
        private readonly IRepository<PositionPbMap, int> _postionPbMapsRepository;
        private readonly PositionPbTimeManager _positionPbTimeManager;
  
             

        /// <summary>
        /// 初始化当天上下班时间服务实例
        /// </summary>
        public PositionPbTimeAppService(IRepository<PositionPbTime, int> positionPbTimeRepository, PositionPbTimeManager positionPbTimeManager, IRepository<PositionPbMap, int> postionPbMapsRepository, IRepository<PositionPb> userReppository)
        {
            _positionPbTimeRepository = positionPbTimeRepository;
            _positionPbTimeManager = positionPbTimeManager;
            _postionPbMapsRepository = postionPbMapsRepository;
          
        }

        #region 当天上下班时间管理

        /// <summary>
        /// 根据查询条件获取当天上下班时间分页列表
        /// </summary>
        public async Task<PagedResultDto<PositionPbTimeDto>> GetPagedAsync(GetPositionPbTimeInput input)
        {
            var query = _positionPbTimeRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件

            var positionPbTimeCount = await query.CountAsync();

            var positionPbTimes = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var positionPbTimeDtos = positionPbTimes.MapTo<List<PositionPbTimeDto>>();
            return new PagedResultDto<PositionPbTimeDto>(
            positionPbTimeCount,
            positionPbTimeDtos
            );
        }

        /// <summary>
        /// 通过指定id获取当天上下班时间Dto信息
        /// </summary>
        public async Task<PositionPbTimeDto> GetByIdAsync(EntityDto<int> input)
        {
            var entity = await _positionPbTimeRepository.GetAsync(input.Id);
            return entity.MapTo<PositionPbTimeDto>();
        }

        /// <summary>
        /// 通过Id获取当天上下班时间信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<PositionPbTimeForEdit> GetForEditAsync(NullableIdDto<int> input)
        {
            PositionPbTimeEditDto positionPbTimeEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _positionPbTimeRepository.GetAsync(input.Id.Value);
                positionPbTimeEditDto = entity.MapTo<PositionPbTimeEditDto>();
            }
            else
            {
                positionPbTimeEditDto = new PositionPbTimeEditDto();
            }
            return new PositionPbTimeForEdit { PositionPbTimeEditDtos = positionPbTimeEditDto };
        }

        /// <summary>
        /// 新增或更改当天上下班时间
        /// </summary>
		[AbpAuthorize(PositionPbTimeAppPermissions.PositionPbTime_CreatePositionPbTime, PositionPbTimeAppPermissions.PositionPbTime_EditPositionPbTime)]
        public async Task CreateOrUpdateAsync(PositionPbTimeForEdit input)
        {
            if (input.PositionPbTimeEditDtos.Id != 0)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
        }

        /// <summary>
        /// 新增当天上下班时间
        /// </summary>
		[AbpAuthorize(PositionPbTimeAppPermissions.PositionPbTime_CreatePositionPbTime)]
        public async Task<PositionPbTimeForEdit> CreateAsync(PositionPbTimeForEdit input)
        {
            //TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.PositionPbTimeEditDtos.MapTo<PositionPbTime>();

            entity = await _positionPbTimeRepository.InsertAsync(entity);
            return new PositionPbTimeForEdit { PositionPbTimeEditDtos = entity.MapTo<PositionPbTimeEditDto>() };
        }

        /// <summary>
        /// 修改当天上下班时间
        /// </summary>
		[AbpAuthorize(PositionPbTimeAppPermissions.PositionPbTime_EditPositionPbTime)]
        public async Task UpdateAsync(PositionPbTimeForEdit input)
        {
            //TODO: 更新前的逻辑判断，是否允许更新

            var entity = await _positionPbTimeRepository.GetAsync(input.PositionPbTimeEditDtos.Id);
            input.PositionPbTimeEditDtos.MapTo(entity);

            await _positionPbTimeRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除当天上下班时间
        /// </summary>
		[AbpAuthorize(PositionPbTimeAppPermissions.PositionPbTime_DeletePositionPbTime)]
        public async Task DeleteAsync(EntityDto<int> input)
        {
            //TODO: 删除前的逻辑判断，是否允许删除

            await _positionPbTimeRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除当天上下班时间
        /// </summary>
		[AbpAuthorize(PositionPbTimeAppPermissions.PositionPbTime_DeletePositionPbTime)]
        public async Task BatchDeleteAsync(List<int> input)
        {
            //TODO: 批量删除前的逻辑判断，是否允许删除

            await _positionPbTimeRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        /// <summary>
        /// 自定义检查当天上下班时间输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(PositionPbTimeForEdit input)
        {
            //TODO: 自定义逻辑判断是否有逻辑错误

            return new CustomerModelStateValidationDto() { HasModelError = false };
        }


        /// <summary>
        ///  根据用户查询获取当月值班列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<AppPositionPbTimeDto>> AppGetAllAsync()
        {
            var userid = (await GetCurrentUserAsync()).Id;

            DateTime now = DateTime.Now;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);
            DateTime d2 = d1.AddMonths(1);

            var query = _positionPbTimeRepository.GetAll().ToList();
            query = query.Where(p => p.UserId == userid&&p.StartTime>d1&&p.EndTime<d2).ToList();

            List<AppPositionPbTimeDto> querylist = new List<AppPositionPbTimeDto>();
            for (int i = 0; i < query.Count(); i++)
            {
                AppPositionPbTimeDto item = new AppPositionPbTimeDto();

                item.StartTime = query[i].StartTime.ToString("yyyy.MM.dd");
                querylist.Add(item);
            }
            
            return querylist;
        }

        /// <summary>
        ///  根据用户查询获取当月值班列表详情
        /// </summary>
        /// <returns></returns>
        public async Task<List<AppPositionPbTimeDetailDto>> AppGetAllDetailAsync()
        {
            var userid = (await GetCurrentUserAsync()).Id;

            DateTime now = DateTime.Now;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);
            DateTime d2 = d1.AddMonths(1);

            var query = _positionPbTimeRepository.GetAll().ToList();
            query = query.Where(p => p.UserId == userid && p.StartTime > d1 && p.EndTime < d2).ToList();

            List<AppPositionPbTimeDetailDto> querylist = new List<AppPositionPbTimeDetailDto>();
            for (int i = 0; i < query.Count(); i++)
            {
                AppPositionPbTimeDetailDto item = new AppPositionPbTimeDetailDto();
                item.PositionPbId = query[i].Id;
                item.StartTime = query[i].StartTime.ToString("yyyy.MM.dd");
                item.EndTime = query[i].EndTime.ToString("yyyy.MM.dd");
                item.RealName = query[i].RealName;
                item.UserId = query[i].UserId;
                item.IsDuty = query[i].IsDuty;

                var positionpbmapQuery = _postionPbMapsRepository.GetAll().ToList().Where(p => p.PositionPbTimeId == query[i].Id).ToList();
                List<PositionPbMapDto> positionpbmap = new List<PositionPbMapDto>();
                for (int j = 0; j < positionpbmapQuery.Count(); j++)
                {
                    PositionPbMapDto list = new PositionPbMapDto();
                    list.Id = positionpbmapQuery[j].Id;
                    list.PositionPbTimeId = positionpbmapQuery[j].PositionPbTimeId;
                    list.UserId = positionpbmapQuery[j].UserId;
                    list.RealName = positionpbmapQuery[j].User.UserName;
                    positionpbmap.Add(list);
                }
                item.PositionPbMaps = positionpbmap;
                
                querylist.Add(item);
            }

            return querylist;
        }

        #endregion

    }
}
