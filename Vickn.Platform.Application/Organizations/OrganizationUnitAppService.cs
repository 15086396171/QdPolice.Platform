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
using Vickn.Platform.Organizations.Dto;

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

        public async Task<GetOrganizationUnitForEditOutput> GetGetOrganizationUnitForEditAsync(NullableIdDto<long> input)
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

        private async Task<OrganizationUnitDto> CreateOrganizationUnitDto(OrganizationUnit organizationUnit)
        {
            var dto = organizationUnit.MapTo<OrganizationUnitDto>();
            dto.MemberCount = await _userOrganizationUnitRepository.CountAsync(uou => uou.OrganizationUnitId == organizationUnit.Id);
            return dto;
        }
    }
}