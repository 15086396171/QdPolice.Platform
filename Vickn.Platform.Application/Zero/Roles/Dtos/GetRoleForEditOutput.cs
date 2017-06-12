using System.Collections.Generic;
using System.Web.Mvc;

namespace Vickn.Platform.Roles.Dtos
{
    /// <summary>
    ///用于添加或编辑 角色管理时使用的DTO
    /// </summary>
    public class GetRoleForEditOutput
    {
        public RoleEditDto RoleEditDto { get; set; }

        public List<SelectListItem> WeightList { get; set; }
    }
}