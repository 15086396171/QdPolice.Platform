using System.Threading.Tasks;
using Abp.Application.Services;
using Vickn.Platform.Roles.Dto;

namespace Vickn.Platform.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
