using System.Collections.Generic;

namespace Vickn.Platform.Roles.Dtos
{
    public class GetRolePermissionEditDto
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; } 
    }
}