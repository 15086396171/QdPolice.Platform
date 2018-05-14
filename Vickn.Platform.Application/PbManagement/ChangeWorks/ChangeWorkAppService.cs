/*
* 命名空间 :     Vickn.Platform.PbManagement.ChangWorks
* 类 名  称 :      ChangeWorkAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     ChangeWorkAppService.cs
* 描      述 :     换班服务
* 创建时间 :     2018/5/14 9:16:05
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
using Vickn.Platform.PbManagement.ChangeWorks.Authorization;
using Vickn.Platform.PbManagement.ChangeWorks.Dtos;
using Vickn.Platform.PbManagement.PbPositions;
using Vickn.Platform.Users;
using Vickn.Platform.PbManagement.PositionPbs;
using Vickn.Platform.PbManagement.PositionPbMaps;
using Vickn.Platform.PbManagement.PositionPbTimes;
using Vickn.Platform.PbManagement.Positions;

namespace Vickn.Platform.PbManagement.ChangeWorks
{
	/// <summary>
    /// 换班服务
    /// </summary>
	[AbpAuthorize(ChangeWorkAppPermissions.ChangeWork)]
    public class ChangeWorkAppService : PlatformAppServiceBase, IChangeWorkAppService
    {
        private readonly ChangeWorkManager _changeWorkManager;
        private readonly IRepository<ChangeWork,long> _changeWorkRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<PositionPbTime, int> _positionPbTimeRepository;
        private readonly IRepository<PositionPbMap, int> _postionPbMapsRepository;
        private readonly IRepository<PositionPb, int> _positionPbRepository;
        private readonly IRepository<PbPosition, int> _pbPositionRepository;
        private readonly IRepository<Position, int> _positionsRepository;

        /// <summary>
        /// 初始化换班服务实例
        /// </summary>
        public ChangeWorkAppService(IRepository<ChangeWork, long> changeWorkRepository,ChangeWorkManager changeWorkManager, IRepository<User, long> userRepository, IRepository<PositionPb> positionRepository, IRepository<PositionPbTime, int> positionPbTimeRepository, IRepository<PositionPbMap, int> postionPbMapsRepository, IRepository<PositionPb, int> positionPbRepository, IRepository<PbPosition, int> pbPositionRepository, IRepository<Position, int> positionsRepository)
        {
            _changeWorkRepository = changeWorkRepository;
            _changeWorkManager = changeWorkManager;
            _userRepository = userRepository;
            _positionPbTimeRepository = positionPbTimeRepository;
            _postionPbMapsRepository = postionPbMapsRepository;
            _positionPbRepository = positionPbRepository;
            _pbPositionRepository = pbPositionRepository;
            _positionsRepository = positionsRepository;
        }

        #region 换班管理

		/// <summary>
        /// 根据查询条件获取换班分页列表
        /// </summary>
        public async Task<PagedResultDto<ChangeWorkDto>> GetPagedAsync(GetChangeWorkInput input)
		{
			 var query = _changeWorkRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件

            var changeWorkCount = await query.CountAsync();

            var changeWorks = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var changeWorkDtos = changeWorks.MapTo<List<ChangeWorkDto>>();
            return new PagedResultDto<ChangeWorkDto>(
            changeWorkCount,
            changeWorkDtos
            );
		}

		/// <summary>
        /// 通过指定id获取换班Dto信息
        /// </summary>
        public async Task<ChangeWorkDto> GetByIdAsync(EntityDto<long> input)
		{
		    var entity = await _changeWorkRepository.GetAsync(input.Id);
            return entity.MapTo<ChangeWorkDto>();
		}

        /// <summary>
        /// 通过Id获取换班信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<ChangeWorkForEdit> GetForEditAsync(NullableIdDto<long> input)
		{
			ChangeWorkEditDto changeWorkEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _changeWorkRepository.GetAsync(input.Id.Value);
                changeWorkEditDto = entity.MapTo<ChangeWorkEditDto>();
            }
            else
            {

                var user = await GetCurrentUserAsync();
         

                changeWorkEditDto = new ChangeWorkEditDto();
              
                changeWorkEditDto.UserName = user.UserName;

                var PositionPbTId = _positionPbTimeRepository.GetAllList().Where(p => p.UserId == user.Id).ToList()[0].PositionPbId;
                var PbPositionId = _positionPbRepository.GetAllList().Where(p => p.Id == PositionPbTId).ToList()[0].PbPositionId;
                var PositionId = _pbPositionRepository.GetAllList().Where(p => p.Id == PbPositionId).ToList()[0].PositionId;
                var positionName = _positionsRepository.GetAllList().Where(p => p.Id == PositionId).ToList()[0].Name;

                changeWorkEditDto.PositionName = positionName;
                changeWorkEditDto.BePositionName = positionName;
            }
            return new ChangeWorkForEdit { ChangeWorkEditDto = changeWorkEditDto };
		}

        /// <summary>
        /// 新增或更改换班
        /// </summary>
		[AbpAuthorize(ChangeWorkAppPermissions.ChangeWork_CreateChangeWork,ChangeWorkAppPermissions.ChangeWork_EditChangeWork)]
        public async Task CreateOrUpdateAsync(ChangeWorkForEdit input)
		{
			 if (input.ChangeWorkEditDto.Id.HasValue)
            {
              
                await UpdateAsync(input);
            }
            else
            {
                input.ChangeWorkEditDto.UserId = (_userRepository.GetAllList()).Where(p => p.UserName == input.ChangeWorkEditDto.UserName).ToList()[0].Id;
                input.ChangeWorkEditDto.PositionPbMapId = (_postionPbMapsRepository.GetAllList()).Where(p => p.UserId == input.ChangeWorkEditDto.UserId).ToList()[0].Id;
                input.ChangeWorkEditDto.BeUserId = (_userRepository.GetAllList()).Where(p => p.UserName == input.ChangeWorkEditDto.BeUserName).ToList()[0].Id;
                input.ChangeWorkEditDto.BePositionPbMapId = (_postionPbMapsRepository.GetAllList()).Where(p => p.UserId == input.ChangeWorkEditDto.BeUserId).ToList()[0].Id;
                input.ChangeWorkEditDto.LeaderId = (_userRepository.GetAllList()).Where(p => p.UserName == input.ChangeWorkEditDto.Leader).ToList()[0].Id;
                input.ChangeWorkEditDto.IsOnDuty = false;
                input.ChangeWorkEditDto.Status = "审批中";
                input.ChangeWorkEditDto.StatusDes = "发起换班";
                await CreateAsync(input);
            }
		}

        /// <summary>
        /// 新增换班
        /// </summary>
		[AbpAuthorize(ChangeWorkAppPermissions.ChangeWork_CreateChangeWork)]
        public async Task<ChangeWorkForEdit> CreateAsync(ChangeWorkForEdit input)
		{
			//TODO: 新增前的逻辑判断，是否允许新增

            
		  
            var entity = input.ChangeWorkEditDto.MapTo<ChangeWork>();

            entity = await _changeWorkRepository.InsertAsync(entity);
            return new ChangeWorkForEdit { ChangeWorkEditDto = entity.MapTo<ChangeWorkEditDto>() };
		}

        /// <summary>
        /// 修改换班
        /// </summary>
		[AbpAuthorize(ChangeWorkAppPermissions.ChangeWork_EditChangeWork)]
        public async Task UpdateAsync(ChangeWorkForEdit input)
		{
		    //TODO: 更新前的逻辑判断，是否允许更新

			var entity = await _changeWorkRepository.GetAsync(input.ChangeWorkEditDto.Id.Value);
            input.ChangeWorkEditDto.MapTo(entity);

            await _changeWorkRepository.UpdateAsync(entity);
		}

        /// <summary>
        /// 删除换班
        /// </summary>
		[AbpAuthorize(ChangeWorkAppPermissions.ChangeWork_DeleteChangeWork)]
        public async Task DeleteAsync(EntityDto<long> input)
		{
			//TODO: 删除前的逻辑判断，是否允许删除

            await _changeWorkRepository.DeleteAsync(input.Id);
		}

        /// <summary>
        /// 批量删除换班
        /// </summary>
		[AbpAuthorize(ChangeWorkAppPermissions.ChangeWork_DeleteChangeWork)]
        public async Task BatchDeleteAsync(List<long> input)
		{
		    //TODO: 批量删除前的逻辑判断，是否允许删除

            await _changeWorkRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        /// <summary>
        /// 自定义检查换班输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(ChangeWorkForEdit input)
		{	
			//TODO: 自定义逻辑判断是否有逻辑错误

			return new CustomerModelStateValidationDto() {HasModelError = false};
		}

        #endregion

    }
}
