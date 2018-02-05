using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Notifications;
using Castle.MicroKernel.Registration;
using Vickn.Platform.RealTime;
using Vickn.Platform.Users.Authorization;

namespace Vickn.Platform
{
    [DependsOn(typeof(PlatformCoreModule), typeof(AbpAutoMapperModule))]
    public class PlatformApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
            });

            new AuthorizationProvider().AddAuthorizationProviders(Configuration);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            IocManager.IocContainer.Register(Component.For<IRealTimeNotifier>().Named("MyRealTimeNotifier")
                .ImplementedBy<MySignalrRealTimeNotifier>().IsDefault());
        }
    }
}
