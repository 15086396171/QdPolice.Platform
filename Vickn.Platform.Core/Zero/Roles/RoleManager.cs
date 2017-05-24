using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Dynamic.Core;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using Vickn.Platform.Users;
using System.Linq;
using System.Threading.Tasks;

namespace Vickn.Platform.Authorization.Roles
{
    public class RoleManager : AbpRoleManager<Role, User>
    {
        private readonly IRepository<UserRole, long> _userRoleRepository;

        private readonly IRepository<Role> _roleRepository; 

        public RoleManager(
            RoleStore store,
            IPermissionManager permissionManager,
            IRoleManagementConfig roleManagementConfig,
            ICacheManager cacheManager,
            IUnitOfWorkManager unitOfWorkManager, IRepository<UserRole, long> userRoleRepository, IRepository<Role> roleRepository)
            : base(
                store,
                permissionManager,
                roleManagementConfig,
                cacheManager,
                unitOfWorkManager)
        {
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        /// <summary>
        /// 获取用户所有角色
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<List<Role>> FindByUserIdAsync(long userId)
        {
            var roles = from role in _roleRepository.GetAll()
                        join userRole in _userRoleRepository.GetAll() on role.Id equals userRole.RoleId
                        where userId == userRole.UserId
                        select role;
            return await roles.ToListAsync();
        }

        public async Task<int> GetMaxWeightByUserIdAsync(long userId)
        {
            var roles = await FindByUserIdAsync(userId);
            if (roles.Count > 0)
                return roles.Max(p => p.Weight);

            return 0;
        }
    }
}