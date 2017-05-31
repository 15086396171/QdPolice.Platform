using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Configuration.Startup;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.IO;
using Abp.Zero.Configuration;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Web.SignalR;
using Vickn.Platform.Api;
using Hangfire;
using Vickn.Platform.MainTenance.AppFolders;

namespace Vickn.Platform.Web
{
    [DependsOn(
        typeof(PlatformDataModule),
        typeof(PlatformApplicationModule),
        typeof(PlatformWebApiModule),
        typeof(AbpWebSignalRModule),
        //typeof(AbpHangfireModule), - ENABLE TO USE HANGFIRE INSTEAD OF DEFAULT JOB MANAGER
        typeof(AbpWebMvcModule))]
    public class PlatformWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<PlatformNavigationProvider>();

            //Configuration.Modules.AbpWebCommon().SendAllExceptionsToClients = true;

            //Configuration.Modules

            //Configure Hangfire - ENABLE TO USE HANGFIRE INSTEAD OF DEFAULT JOB MANAGER
            //Configuration.BackgroundJobs.UseHangfire(configuration =>
            //{
            //    configuration.GlobalConfiguration.UseSqlServerStorage("Hangfire");
            //});
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        public override void PostInitialize()
        {
            var server = HttpContext.Current.Server;
            var appFolders = IocManager.Resolve<AppFolders>();

            appFolders.SampleProfileImagesFolder = server.MapPath("~/Common/Images/SampleProfilePics");
            appFolders.TempFileDownloadFolder = server.MapPath("~/Temp/Downloads");
            appFolders.WebLogsFolder = server.MapPath("~/App_Data/Logs");

            try { DirectoryHelper.CreateIfNotExists(appFolders.TempFileDownloadFolder); } catch { }
        }
    }
}
