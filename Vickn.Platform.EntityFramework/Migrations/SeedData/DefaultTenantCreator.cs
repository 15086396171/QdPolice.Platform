using System.Linq;
using Vickn.Platform.EntityFramework;
using Vickn.Platform.MultiTenancy;

namespace Vickn.Platform.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly PlatformDbContext _context;

        public DefaultTenantCreator(PlatformDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
