/*
* 命名空间 :     Vickn.Platform.PrivatePhoneWhites
* 类 名  称 :      PrivatePhoneWhiteAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     PrivatePhoneWhiteAppService.cs
* 描      述 :     个人白名单服务
* 创建时间 :     2018/2/23 14:15:14
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
using Vickn.Platform.PrivatePhoneWhites.Authorization;
using Vickn.Platform.PrivatePhoneWhites.Dtos;
using Vickn.Platform.Users;

namespace Vickn.Platform.PrivatePhoneWhites
{
	/// <summary>
    /// 个人白名单服务
    /// </summary>
	[AbpAuthorize(PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite)]
    public class PrivatePhoneWhiteAppService : PlatformAppServiceBase, IPrivatePhoneWhiteAppService
    {
	    private readonly IRepository<PrivatePhoneWhite,long> _privatePhoneWhiteRepository;
        private readonly IRepository<User, long> _userRepository;
	  	private readonly PrivatePhoneWhiteManager _privatePhoneWhiteManager;

	    /// <summary>
        /// 初始化个人白名单服务实例
        /// </summary>
        public PrivatePhoneWhiteAppService(IRepository<PrivatePhoneWhite, long> privatePhoneWhiteRepository,PrivatePhoneWhiteManager privatePhoneWhiteManager, IRepository<User, long> userRepository)
        {
            _privatePhoneWhiteRepository = privatePhoneWhiteRepository;
            _privatePhoneWhiteManager = privatePhoneWhiteManager;
            _userRepository = userRepository;
        }

        #region 个人白名单管理

        /// <summary>
        /// 获取个人白名单
        /// </summary>
        /// <returns></returns>
        public async Task<ListResultDto<PhoneWhiteDto>> GetPhoneWhites()
        {
            List<PhoneWhiteDto> phoneWhiteDtos = new List<PhoneWhiteDto>();
            //phoneWhiteDtos.AddRange(_userRepository.GetAll().Select(p=>new PhoneWhiteDto()
            //{
            //    Name = p.Name,
            //    PhoneNumber = p.PhoneNumber,
            //    PhoneWhiteType = PhoneWhiteType.Public
            //}).ToList());

            phoneWhiteDtos.AddRange(_privatePhoneWhiteRepository.GetAllList(p=>p.UserId == AbpSession.UserId.Value).Select(p=>new PhoneWhiteDto()
            {
                Name = p.Name,
                PhoneNumber = p.PhoneNumber,
                PhoneWhiteType = PhoneWhiteType.Private
            }).ToList());

            return new ListResultDto<PhoneWhiteDto>(phoneWhiteDtos);
        }

        /// <summary>
        /// 根据查询条件获取个人白名单分页列表
        /// </summary>
        public async Task<PagedResultDto<PrivatePhoneWhiteDto>> GetPagedAsync(GetPrivatePhoneWhiteInput input)
		{
			 var query = _privatePhoneWhiteRepository.GetAll().Where(p=>p.UserId == input.UserId);

            //TODO:根据传入的参数添加过滤条件

            var privatePhoneWhiteCount = await query.CountAsync();

            var privatePhoneWhites = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var privatePhoneWhiteDtos = privatePhoneWhites.MapTo<List<PrivatePhoneWhiteDto>>();
            return new PagedResultDto<PrivatePhoneWhiteDto>(
            privatePhoneWhiteCount,
            privatePhoneWhiteDtos
            );
		}

		/// <summary>
        /// 通过指定id获取个人白名单Dto信息
        /// </summary>
        public async Task<PrivatePhoneWhiteDto> GetByIdAsync(EntityDto<long> input)
		{
		    var entity = await _privatePhoneWhiteRepository.GetAsync(input.Id);
            return entity.MapTo<PrivatePhoneWhiteDto>();
		}

        /// <summary>
        /// 通过Id获取个人白名单信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        public async Task<PrivatePhoneWhiteForEdit> GetForEditAsync(NullableIdDto<long> input)
		{
			PrivatePhoneWhiteEditDto privatePhoneWhiteEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _privatePhoneWhiteRepository.GetAsync(input.Id.Value);
                privatePhoneWhiteEditDto = entity.MapTo<PrivatePhoneWhiteEditDto>();
            }
            else
            {
                privatePhoneWhiteEditDto = new PrivatePhoneWhiteEditDto();
            }
            return new PrivatePhoneWhiteForEdit { PrivatePhoneWhiteEditDto = privatePhoneWhiteEditDto };
		}

        /// <summary>
        /// 新增或更改个人白名单
        /// </summary>
		[AbpAuthorize(PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite_CreatePrivatePhoneWhite,PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite_EditPrivatePhoneWhite)]
        public async Task CreateOrUpdateAsync(PrivatePhoneWhiteForEdit input)
		{
			 if (input.PrivatePhoneWhiteEditDto.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                await CreateAsync(input);
            }
		}

        /// <summary>
        /// 新增个人白名单
        /// </summary>
		[AbpAuthorize(PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite_CreatePrivatePhoneWhite)]
        public async Task<PrivatePhoneWhiteForEdit> CreateAsync(PrivatePhoneWhiteForEdit input)
		{
			//TODO: 新增前的逻辑判断，是否允许新增

            var entity = input.PrivatePhoneWhiteEditDto.MapTo<PrivatePhoneWhite>();

            entity = await _privatePhoneWhiteRepository.InsertAsync(entity);
            return new PrivatePhoneWhiteForEdit { PrivatePhoneWhiteEditDto = entity.MapTo<PrivatePhoneWhiteEditDto>() };
		}

        /// <summary>
        /// 修改个人白名单
        /// </summary>
		[AbpAuthorize(PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite_EditPrivatePhoneWhite)]
        public async Task UpdateAsync(PrivatePhoneWhiteForEdit input)
		{
		    //TODO: 更新前的逻辑判断，是否允许更新

			var entity = await _privatePhoneWhiteRepository.GetAsync(input.PrivatePhoneWhiteEditDto.Id.Value);
            input.PrivatePhoneWhiteEditDto.MapTo(entity);

            await _privatePhoneWhiteRepository.UpdateAsync(entity);
		}

        /// <summary>
        /// 删除个人白名单
        /// </summary>
		[AbpAuthorize(PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite_DeletePrivatePhoneWhite)]
        public async Task DeleteAsync(EntityDto<long> input)
		{
			//TODO: 删除前的逻辑判断，是否允许删除

            await _privatePhoneWhiteRepository.DeleteAsync(input.Id);
		}

        /// <summary>
        /// 批量删除个人白名单
        /// </summary>
		[AbpAuthorize(PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite_DeletePrivatePhoneWhite)]
        public async Task BatchDeleteAsync(List<long> input)
		{
		    //TODO: 批量删除前的逻辑判断，是否允许删除

            await _privatePhoneWhiteRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        /// <summary>
        /// 自定义检查个人白名单输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(PrivatePhoneWhiteForEdit input)
		{	
			//TODO: 自定义逻辑判断是否有逻辑错误

			return new CustomerModelStateValidationDto() {HasModelError = false};
		}

        #endregion

    }
}
