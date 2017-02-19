using Abp.Authorization.Users;
using Abp.AutoMapper;

namespace Vickn.Platform.Users.Dtos
{
    public class UserRoleDto 
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string RoleDisplayName { get; set; }

        public bool IsAssigned { get; set; }
    }
}