using System.Web.Mvc;
using Abp.IdentityFramework;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using Microsoft.AspNet.Identity;

namespace Vickn.Platform.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class PlatformControllerBase : AbpController
    {
        protected static readonly ActionResult CreateResult = new ContentResult() {Content = "<script>parent.location.reload()</script>"};

        protected PlatformControllerBase()
        {
            LocalizationSourceName = PlatformConsts.LocalizationSourceName;
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

       
}
}