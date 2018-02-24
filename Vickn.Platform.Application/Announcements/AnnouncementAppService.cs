/*
* 命名空间 :     Vickn.Platform.Announcements
* 类 名  称 :      AnnouncementAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     AnnouncementAppService.cs
* 描      述 :     通知公告服务
* 创建时间 :     2018/2/24 11:43:02
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
using Vickn.Platform.Announcements.Authorization;
using Vickn.Platform.Announcements.Dtos;

namespace Vickn.Platform.Announcements
{
	/// <summary>
    /// 通知公告服务
    /// </summary>
	[AbpAuthorize(AnnouncementAppPermissions.Announcement)]
    public class AnnouncementAppService : PlatformAppServiceBase, IAnnouncementAppService
    {
	    private readonly IRepository<Announcement,long> _announcementRepository;
	  	private readonly AnnouncementManager _announcementManager;

	    /// <summary>
        /// 初始化通知公告服务实例
        /// </summary>
        public AnnouncementAppService(IRepository<Announcement, long> announcementRepository,AnnouncementManager announcementManager)
        {
            _announcementRepository = announcementRepository;
            _announcementManager = announcementManager;
        }

        #region 通知公告管理

		/// <summary>
        /// 根据查询条件获取通知公告分页列表
        /// </summary>
        public async Task<PagedResultDto<AnnouncementDto>> GetPagedAsync(GetAnnouncementInput input)
		{
			 var query = _announcementRepository.GetAll();

            //TODO:根据传入的参数添加过滤条件
		    query = query.WhereIf(!input.FilterText.IsNullOrEmpty(), p => p.Title.Contains(input.FilterText));

            var announcementCount = await query.CountAsync();

            var announcements = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var announcementDtos = announcements.MapTo<List<AnnouncementDto>>();
            return new PagedResultDto<AnnouncementDto>(
            announcementCount,
            announcementDtos
            );
		}

		/// <summary>
        /// 通过指定id获取通知公告Dto信息
        /// </summary>
        public async Task<AnnouncementDto> GetByIdAsync(EntityDto<long> input)
		{
		    var entity = await _announcementRepository.GetAsync(input.Id);
            return entity.MapTo<AnnouncementDto>();
		}

        /// <summary>
        /// 通过Id获取通知公告信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<AnnouncementForEdit> GetForEditAsync(NullableIdDto<long> input)
		{
			AnnouncementEditDto announcementEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _announcementRepository.GetAsync(input.Id.Value);
                announcementEditDto = entity.MapTo<AnnouncementEditDto>();
            }
            else
            {
                announcementEditDto = new AnnouncementEditDto();
            }
            return new AnnouncementForEdit { AnnouncementEditDto = announcementEditDto };
		}

        /// <summary>
        /// 新增或更改通知公告
        /// </summary>
		[AbpAuthorize(AnnouncementAppPermissions.Announcement_CreateAnnouncement,AnnouncementAppPermissions.Announcement_EditAnnouncement)]
        public async Task CreateOrUpdateAsync(AnnouncementForEdit input)
		{
			 if (input.AnnouncementEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
		}

        /// <summary>
        /// 新增通知公告
        /// </summary>
		[AbpAuthorize(AnnouncementAppPermissions.Announcement_CreateAnnouncement)]
        public async Task<AnnouncementForEdit> CreateAsync(AnnouncementForEdit input)
		{
			//TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.AnnouncementEditDto.MapTo<Announcement>();

            entity = await _announcementRepository.InsertAsync(entity);
            return new AnnouncementForEdit { AnnouncementEditDto = entity.MapTo<AnnouncementEditDto>() };
		}

        /// <summary>
        /// 修改通知公告
        /// </summary>
		[AbpAuthorize(AnnouncementAppPermissions.Announcement_EditAnnouncement)]
        public async Task UpdateAsync(AnnouncementForEdit input)
		{
		    //TODO: 更新前的逻辑判断，是否允许更新

			var entity = await _announcementRepository.GetAsync(input.AnnouncementEditDto.Id.Value);
            input.AnnouncementEditDto.MapTo(entity);

            await _announcementRepository.UpdateAsync(entity);
		}

        /// <summary>
        /// 删除通知公告
        /// </summary>
		[AbpAuthorize(AnnouncementAppPermissions.Announcement_DeleteAnnouncement)]
        public async Task DeleteAsync(EntityDto<long> input)
		{
			//TODO: 删除前的逻辑判断，是否允许删除

            await _announcementRepository.DeleteAsync(input.Id);
		}

        /// <summary>
        /// 批量删除通知公告
        /// </summary>
		[AbpAuthorize(AnnouncementAppPermissions.Announcement_DeleteAnnouncement)]
        public async Task BatchDeleteAsync(List<long> input)
		{
		    //TODO: 批量删除前的逻辑判断，是否允许删除

            await _announcementRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        /// <summary>
        /// 自定义检查通知公告输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(AnnouncementForEdit input)
		{	
			//TODO: 自定义逻辑判断是否有逻辑错误

			return new CustomerModelStateValidationDto() {HasModelError = false};
		}

        #endregion

    }
}
