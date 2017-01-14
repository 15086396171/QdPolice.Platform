using Abp.Web.Mvc.Views;

namespace Vickn.Platform.Web.Views
{
    public abstract class PlatformWebViewPageBase : PlatformWebViewPageBase<dynamic>
    {

    }

    public abstract class PlatformWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected PlatformWebViewPageBase()
        {
            LocalizationSourceName = PlatformConsts.LocalizationSourceName;
        }
    }
}