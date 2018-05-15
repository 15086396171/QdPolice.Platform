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
using Vickn.Platform.PbManagement.PbPositions;
using Vickn.Platform.PbManagement.PositionPbMaps;
using Vickn.Platform.PbManagement.PositionPbMaps.Dtos;
using Vickn.Platform.PbManagement.PositionPbs;
using Vickn.Platform.PbManagement.PositionPbTimes.Authorization;
using Vickn.Platform.PbManagement.PositionPbTimes.Dtos;
using Vickn.Platform.PbManagement.Positions;
using Vickn.Platform.Users;

namespace Vickn.Platform.PbManagement.PositionPbTimes
{
    /// <summary>
    /// 当天上下班时间服务
    /// </summary>
    [AbpAuthorize(PositionPbTimeAppPermissions.PositionPbTime)]
    public class PositionPbTimeAppService : PlatformAppServiceBase, IPositionPbTimeAppService
    {
        private readonly PositionPbTimeManager _positionPbTimeManager;
        private readonly IRepository<PositionPbTime, int> _positionPbTimeRepository;
        private readonly IRepository<PositionPbMap, int> _postionPbMapsRepository;
        private readonly IRepository<PositionPb, int> _positionPbRepository;
        private readonly IRepository<PbPosition, int> _pbPositionRepository;
        private readonly IRepository<Position, int> _positionRepository;

      


        /// <summary>
        /// 初始化当天上下班时间服务实例
        /// </summary>
        public PositionPbTimeAppService(IRepository<PositionPbTime, int> positionPbTimeRepository, PositionPbTimeManager positionPbTimeManager, IRepository<PositionPbMap, int> postionPbMapsRepository, IRepository<PositionPb> userReppository, IRepository<PositionPb, int> positionPbRepository, IRepository<PbPosition, int> pbPositionRepository, IRepository<Position, int> positionRepository)
        {
            _positionPbTimeRepository = positionPbTimeRepository;
            _positionPbTimeManager = positionPbTimeManager;
            _postionPbMapsRepository = postionPbMapsRepository;
            _positionPbRepository = positionPbRepository;
            _pbPositionRepository = pbPositionRepository;
            _positionRepository = positionRepository;
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
        /// 根据用户获取本月未值班的排班信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<PositionPbTimeListDto>> GetAllAsync()
        {


            var userid = (await GetCurrentUserAsync()).Id;

            DateTime now = DateTime.Now;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);
            DateTime d2 = d1.AddMonths(1);
            DateTime d3 = DateTime.Today;

            var query = _positionPbTimeRepository.GetAll().ToList();
            query = query.Where(p => p.UserId == userid && p.StartTime > d3 && p.EndTime < d2).ToList();

            List<PositionPbTimeListDto> querylist = new List<PositionPbTimeListDto>();

            for (int i = 0; i < query.Count(); i++)
            {
                PositionPbTimeListDto item = new PositionPbTimeListDto();

                item.PbTime = query[i].StartTime.ToString("MM月dd日 HH:mm") + "--" + query[i].EndTime.ToString("MM月dd日 HH:mm");
                querylist.Add(item);
            }



            return querylist;
        }

        /// <summary>
        /// 查询获取当月除发起人外所有未值班列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<PositionPbTimeListDto>> GetAllForUserDutyAsync()
        {
            var user = await GetCurrentUserAsync();

            DateTime now = DateTime.Now;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);
            DateTime d2 = d1.AddMonths(1);
            DateTime d3 = DateTime.Today;

            var query = _positionPbTimeRepository.GetAll().ToList();
            query = query.Where(p => p.StartTime > d3 && p.EndTime < d2 && p.RealName != user.UserName).ToList();

            List<PositionPbTimeListDto> querylist = new List<PositionPbTimeListDto>();

            for (int i = 0; i < query.Count(); i++)
            {
                PositionPbTimeListDto item = new PositionPbTimeListDto();

                item.PbTime = query[i].StartTime.ToString("yyyy年MM月dd日");

                querylist.Add(item);
            }
            querylist = querylist.GroupBy(t => t.PbTime).Select(t => t.First()).ToList();


            return querylist;
        }

        /// <summary>
        /// 查询所选日期未值班用户信息列表
        /// </summary>
        public async Task<List<PositionPbUserTimeListDto>> GetUserAllForDutyAsync(GetPositionUserPbTimeListDto input)
        {
            var user = await GetCurrentUserAsync();

            DateTime d2 = input.Date;
            DateTime d3 = d2.AddDays(1);

            var query = _positionPbTimeRepository.GetAll().ToList();
            query = query.Where(p => p.StartTime > d2 && p.EndTime < d3 && p.RealName != user.UserName).ToList();

            var UserPositionPbId = (_positionPbTimeRepository.GetAllList()).Where(p => p.UserId == user.Id).ToList()[0]
                .PositionPbId;
            var UserPbPositionId =
                _positionPbRepository.GetAllList().Where(p => p.Id == UserPositionPbId).ToList()[0]
                    .PbPositionId;
            var UserPositionId = _pbPositionRepository.GetAllList().Where(p => p.Id == UserPbPositionId).ToList()[0].PositionId;
            var UserpositionName = _positionRepository.GetAllList().Where(p => p.Id == UserPositionId).ToList()[0].Name;


            List<PositionPbUserTimeListDto> querylist = new List<PositionPbUserTimeListDto>();

            for (int i = 0; i < query.Count(); i++)
            {
                PositionPbUserTimeListDto item = new PositionPbUserTimeListDto();

                item.PositionPbTimeId = query[i].Id;
                item.UserName = query[i].RealName;
                item.WorkTime = query[i].StartTime.ToString("MM月dd日 HH:mm") + "--" + query[i].EndTime.ToString("MM月dd日 HH:mm");
                //获取岗位名称
                var PbPositionId = _positionPbRepository.GetAllList().Where(p => p.Id == query[i].PositionPbId).ToList()[0].PbPositionId;
                var PositionId = _pbPositionRepository.GetAllList().Where(p => p.Id == PbPositionId).ToList()[0].PositionId;
                var positionName = _positionRepository.GetAllList().Where(p => p.Id == PositionId).ToList()[0].Name;
                item.PositionName = positionName;

                querylist.Add(item);
            }

            querylist = querylist.Where(p => p.PositionName == UserpositionName).ToList();

            return querylist;
        }


        #region 警务通 

        /// <summary>
        ///  app根据用户查询获取当月值班列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<AppPositionPbTimeDto>> AppGetAllAsync()
        {
            var userid = (await GetCurrentUserAsync()).Id;

            DateTime now = DateTime.Now;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);
            DateTime d2 = d1.AddMonths(1);

            var query = _positionPbTimeRepository.GetAll().ToList();
            query = query.Where(p => p.UserId == userid && p.StartTime > d1 && p.EndTime < d2).ToList();

            List<AppPositionPbTimeDto> querylist = new List<AppPositionPbTimeDto>();

            for (int i = 0; i < query.Count(); i++)
            {
                AppPositionPbTimeDto item = new AppPositionPbTimeDto();

                item.StartTime = int.Parse(query[i].StartTime.ToString("dd"));
                querylist.Add(item);
            }

            List<AppPositionPbTimeDto> newquerylist = new List<AppPositionPbTimeDto>();
            int MonthDay = DateTime.DaysInMonth(now.Year, now.Month);
            for (int i = 0; i < MonthDay; i++)
            {
                AppPositionPbTimeDto newitem = new AppPositionPbTimeDto();

                var count = querylist.Where(p => p.StartTime == i);
                if (count.Count() == 1)
                {
                    newitem.StartTime = i;

                }
                else
                {
                    newitem.StartTime = 0;
                }

                newquerylist.Add(newitem);
            }

            return newquerylist;
        }

        /// <summary>
        ///  app查询获取当月所有值班列表详情
        /// </summary>
        /// <returns></returns>
        public async Task<List<AppPositionPbTimeDetailDto>> AppGetAllDetailAsync(AppGetPositionPbDto input)
        {


            var querylist = _positionPbTimeRepository.GetAll().ToList();
            querylist = querylist.Where(p => p.StartTime > input.PbDate && p.StartTime < input.PbDate.AddDays(1)).OrderBy(p => p.PositionPbId).ToList();


            List<AppPositionPbTimeDetailDto> querylists = new List<AppPositionPbTimeDetailDto>();
            foreach (var query in querylist)
            {
                AppPositionPbTimeDetailDto item = new AppPositionPbTimeDetailDto();

                item.StartTime = query.StartTime.ToString("MM月dd日 HH:mm");
                item.EndTime = query.EndTime.ToString("MM月dd日 HH:mm");
                item.UserName = query.RealName;

                //获取岗位名称
                var PbPositionId = _positionPbRepository.GetAllList().Where(p => p.Id == query.PositionPbId).ToList()[0].PbPositionId;
                var PositionId = _pbPositionRepository.GetAllList().Where(p => p.Id == PbPositionId).ToList()[0].PositionId;
                var positionName = _positionRepository.GetAllList().Where(p => p.Id == PositionId).ToList()[0].Name;

                item.positionPbName = positionName;

                querylists.Add(item);
            }

            querylists.OrderByDescending(p => p.positionPbName);
            return querylists;
        }


        #endregion

        #endregion

    }
}
