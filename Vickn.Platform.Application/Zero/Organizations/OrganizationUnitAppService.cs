using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Organizations;
using Vickn.Platform.Dtos;
using Vickn.Platform.Organizations.Dto;
using Vickn.Platform.Zero.Users.Dtos;

namespace Vickn.Platform.Organizations
{
    public class OrganizationUnitAppService : PlatformAppServiceBase, IOrganizationUnitAppService
    {
        private readonly OrganizationUnitManager _organizationUnitManager;
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;
        private readonly IRepository<UserOrganizationUnit, long> _userOrganizationUnitRepository;

        public OrganizationUnitAppService(
            OrganizationUnitManager organizationUnitManager,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository)
        {
            _organizationUnitManager = organizationUnitManager;
            _organizationUnitRepository = organizationUnitRepository;
            _userOrganizationUnitRepository = userOrganizationUnitRepository;
        }

        /// <summary>
        /// 获取所有组织
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrganizationUnitDto>> GetOrganizationUnitDto()
        {

            var query = _organizationUnitRepository.GetAll();

            var organizationUnits = await query.ToListAsync();

            return organizationUnits.MapTo<List<OrganizationUnitDto>>();
        }

        /// <summary>
        /// 获取自己所在的组织和用户
        /// </summary>
        /// <returns></returns>
        public async Task<List<OuWithUserDto>> GetOuWithUsersAsync()
        {
            // 只查询根节点
            // 根据自己所在的组织，查询到根节点组织
            var userOrganizationUnits = await _userOrganizationUnitRepository.GetAllListAsync(p => p.UserId == AbpSession.UserId);

            List<OuWithUserDto> ouWithUserDtos = new List<OuWithUserDto>();
            foreach (var userOrganizationUnit in userOrganizationUnits)
            {
                //所在当前组织
                var organizationUnit = await _organizationUnitRepository.GetAsync(userOrganizationUnit.OrganizationUnitId);

                var codeZero = organizationUnit.Code.Split(".")[0];

                var query = _organizationUnitRepository.GetAll().Where(p => p.Code == codeZero);
                var organizationUnits = await query.ToListAsync();

                ouWithUserDtos.AddRange(organizationUnits.MapTo<List<OuWithUserDto>>());
               
                foreach (var ouWithUserDto in ouWithUserDtos)
                {
                    await GetUsers(ouWithUserDto);
                }
            }

            return ouWithUserDtos;
        }

        /// <summary>
        /// 获取所有组织和用户
        /// </summary>
        /// <returns></returns>
        public async Task<List<OuWithUserDto>> GetAllOuWithUsersAsync()
        {
            var query = _organizationUnitRepository.GetAll().Where(p => p.ParentId == null);
            var organizationUnits = await query.ToListAsync();

            var ouWithUserDtos = (organizationUnits.MapTo<List<OuWithUserDto>>());

            foreach (var ouWithUserDto in ouWithUserDtos)
            {
                await GetUsers(ouWithUserDto);
            }

            return ouWithUserDtos;
        }

        public async Task GetUsers(OuWithUserDto dto)
        {
            var query = from uou in _userOrganizationUnitRepository.GetAll()
                        join ou in _organizationUnitRepository.GetAll() on uou.OrganizationUnitId equals ou.Id
                        join user in UserManager.Users on uou.UserId equals user.Id
                        where uou.OrganizationUnitId == dto.Id
                        select user;
            var users = await query.ToListAsync();

            dto.Users = users.MapTo<List<UserSimpleDto>>();
            dto.Children = dto.Children.OrderBy(p => p.Id).ToList();
            dto.Users = dto.Users.OrderBy(p => p.Id).ToList();
            foreach (var ouWithUserDto in dto.Children)
            {
                await GetUsers(ouWithUserDto);
            }
        }

        public async Task<PagedResultDto<OrganizationUnitDto>> GetPagedOrganizationUnitAsync(GetOrganizationUnitInput input)
        {
            var query = _organizationUnitRepository.GetAll();

            query = query.WhereIf(input.ParentId.HasValue, p => p.ParentId == input.ParentId.Value);

            query = query.WhereIf(!input.DisplayName.IsNullOrEmpty(), p => p.DisplayName.Contains(input.DisplayName));

            var totalCount = await query.CountAsync();

            var organizationUnits = await query
               .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var organizationUnitListDto = organizationUnits.MapTo<List<OrganizationUnitDto>>();
            return new PagedResultDto<OrganizationUnitDto>(totalCount, organizationUnitListDto);
        }

        /// <summary>
        /// 根据查询条件获取该组织下用户分页列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<OrganizationUnitUserListDto>> GetOrganizationUnitUsers(GetOrganizationUnitUsersInput input)
        {
            var query = from uou in _userOrganizationUnitRepository.GetAll()
                        join ou in _organizationUnitRepository.GetAll() on uou.OrganizationUnitId equals ou.Id
                        join user in UserManager.Users on uou.UserId equals user.Id
                        where uou.OrganizationUnitId == input.Id
                        orderby input.Sorting
                        select new { uou, user };

            var totalCount = await query.CountAsync();
            var items = await query.PageBy(input).ToListAsync();

            return new PagedResultDto<OrganizationUnitUserListDto>(
                totalCount,
                items.Select(item =>
                {
                    var dto = item.user.MapTo<OrganizationUnitUserListDto>();
                    dto.AddedTime = item.uou.CreationTime;
                    return dto;
                }).ToList());
        }

        public async Task<GetOrganizationUnitForEditOutput> GetOrganizationUnitForEditAsync(NullableIdDto<long> input)
        {
            GetOrganizationUnitForEditOutput output;
            if (input.Id.HasValue)
            {
                var organizationUnit = await _organizationUnitRepository.GetAsync(input.Id.Value);
                output = organizationUnit.MapTo<GetOrganizationUnitForEditOutput>();
            }
            else
            {
                output = new GetOrganizationUnitForEditOutput();
            }
            return output;
        }

        public async Task CreateOrUpdateOrganizationUnit(GetOrganizationUnitForEditOutput output)
        {
            if (output.Id.HasValue)
            {
                var input = new UpdateOrganizationUnitInput()
                {
                    DisplayName = output.DisplayName,
                    Id = output.Id.Value
                };
                await UpdateOrganizationUnit(input);
            }
            else
            {
                var input = new CreateOrganizationUnitInput()
                {
                    DisplayName = output.DisplayName,
                    ParentId = output.ParentId
                };
                await CreateOrganizationUnit(input);
            }
        }

        public async Task<OrganizationUnitDto> CreateOrganizationUnit(CreateOrganizationUnitInput input)
        {
            var organizationUnit = new OrganizationUnit(AbpSession.TenantId, input.DisplayName, input.ParentId);

            await _organizationUnitManager.CreateAsync(organizationUnit);
            await CurrentUnitOfWork.SaveChangesAsync();

            return organizationUnit.MapTo<OrganizationUnitDto>();
        }

        public async Task<OrganizationUnitDto> UpdateOrganizationUnit(UpdateOrganizationUnitInput input)
        {
            var organizationUnit = await _organizationUnitRepository.GetAsync(input.Id);

            organizationUnit.DisplayName = input.DisplayName;

            await _organizationUnitManager.UpdateAsync(organizationUnit);

            return await CreateOrganizationUnitDto(organizationUnit);
        }

        public async Task<OrganizationUnitDto> MoveOrganizationUnit(MoveOrganizationUnitInput input)
        {
            await _organizationUnitManager.MoveAsync(input.Id, input.NewParentId);

            return await CreateOrganizationUnitDto(
                await _organizationUnitRepository.GetAsync(input.Id)
                );
        }

        public async Task DeleteOrganizationUnit(EntityDto<long> input)
        {
            await _organizationUnitManager.DeleteAsync(input.Id);
        }

        public async Task BatchDeleteOrganizationUnitAsync(List<long> input)
        {
            await _organizationUnitRepository.DeleteAsync(p => input.Contains(p.Id));
        }

        public async Task AddUserToOrganizationUnit(UserToOrganizationUnitInput input)
        {
            await UserManager.AddToOrganizationUnitAsync(input.UserId, input.OrganizationUnitId);
        }

        public async Task RemoveUserFromOrganizationUnit(UserToOrganizationUnitInput input)
        {
            await UserManager.RemoveFromOrganizationUnitAsync(input.UserId, input.OrganizationUnitId);
        }

        public async Task<bool> IsInOrganizationUnit(UserToOrganizationUnitInput input)
        {
            return await UserManager.IsInOrganizationUnitAsync(input.UserId, input.OrganizationUnitId);
        }

        /// <summary>
        /// 检查用户输入错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(GetOrganizationUnitForEditOutput input)
        {
            if (_organizationUnitRepository.FirstOrDefault(p => p.ParentId == input.ParentId && p.DisplayName == input.DisplayName && p.Id != input.Id) != null)
            {
                return new CustomerModelStateValidationDto(true, "DisplayName", $"上级组织已存在\"{input.DisplayName}\"");
            }
            return new CustomerModelStateValidationDto();
        }

        private async Task<OrganizationUnitDto> CreateOrganizationUnitDto(OrganizationUnit organizationUnit)
        {
            var dto = organizationUnit.MapTo<OrganizationUnitDto>();
            dto.MemberCount = await _userOrganizationUnitRepository.CountAsync(uou => uou.OrganizationUnitId == organizationUnit.Id);
            return dto;
        }

        public async Task<PagedResultDto<OrganizationUnitUserListDto>> GetOrganizationUnitWithAllUserForAdd(GetOrganizationUnitUsersInput input)
        {
            var query = UserManager.Users;

            query = query.WhereIf(!input.Name.IsNullOrEmpty(), p => p.Name.Contains(input.Name));

            var totalCount = await query.CountAsync();
            var items = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            return new PagedResultDto<OrganizationUnitUserListDto>(
                totalCount,
                items.Select(item =>
                {
                    var dto = item.MapTo<OrganizationUnitUserListDto>();
                    dto.IsChecked =
                        _userOrganizationUnitRepository.GetAll()
                            .Any(p => p.OrganizationUnitId == input.Id && p.UserId == dto.Id);
                    return dto;
                }).ToList());
        }

        public async Task AddUserToOuAsync(AddUserToOuInput input)
        {
            foreach (var userOrganizationUnit in _userOrganizationUnitRepository.GetAllList(p => p.OrganizationUnitId == input.OuId))
            {
                if (!input.UserIds.Contains(userOrganizationUnit.UserId))
                    await _userOrganizationUnitRepository.DeleteAsync(userOrganizationUnit);
            }
            foreach (var userId in input.UserIds)
            {
                await UserManager.AddToOrganizationUnitAsync(userId, input.OuId);
            }
        }
    }
}