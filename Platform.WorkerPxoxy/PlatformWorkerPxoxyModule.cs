using System.Reflection;
using Abp.Dependency;
using Abp.Modules;

namespace Vickn.Platform.WorkerPxoxy
{
    public class PlatformWorkerPxoxyModule: AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
        public override void PreInitialize()
        {
            IocManager.RegisterIfNot<IBackgroudWorkerProxy, PeriodicWorkerPxoxy>();
        }
    }
}