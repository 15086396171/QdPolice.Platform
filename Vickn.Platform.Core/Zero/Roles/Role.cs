using Abp.Authorization.Roles;
using Vickn.Platform.Users;

namespace Vickn.Platform.Authorization.Roles
{
    public class Role : AbpRole<User>
    {
        //Can add application specific role properties here

        /// <summary>
        /// 角色等级，只能设置等级比自己低的角色
        /// </summary>
        public int Weight { get; set; }


        public Role()
        {

        }

        public Role(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {

        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {

        }
        public Role(int? tenantId, string name, string displayName, int weight)
          : base(tenantId, name, displayName)
        {
            this.Weight = weight;
        }
    }
}