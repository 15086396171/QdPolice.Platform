using System.Web.Optimization;

namespace Vickn.Platform.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //VENDOR RESOURCES

            #region Platformlib

            //~/Bundles/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/vendor/css")
                            .Include("~/Content/H-ui.admin_v3.0/static/h-ui/css/H-ui.min.css", new CssRewriteUrlTransform())
                    .Include("~/Content/H-ui.admin_v3.0/static/h-ui.admin/css/H-ui.admin.css", new CssRewriteUrlTransform())
                    .Include("~/Content/H-ui.admin_v3.0/lib/Hui-iconfont/1.0.8/iconfont.css", new CssRewriteUrlTransform())
                    .Include("~/Content/H-ui.admin_v3.0/lib/icheck/icheck.css", new CssRewriteUrlTransform())
                    .Include("~/Content/H-ui.admin_v3.0/static/h-ui.admin/skin/blue/skin.css", new CssRewriteUrlTransform())
                    .Include("~/Content/toastr.min.css", new CssRewriteUrlTransform())
                    .Include("~/Scripts/sweetalert/sweet-alert.css", new CssRewriteUrlTransform())
                );

            //~/Bundles/vendor/js/top (These scripts should be included in the head of the page)
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/top")
                    .Include(
                        "~/Abp/Framework/scripts/utils/ie10fix.js",
                        "~/Scripts/modernizr-2.8.3.js"
                    )
                );

            //~/Bundles/vendor/bottom (Included in the bottom for fast page load)
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/bottom")
                    .Include(
                        "~/Scripts/json2.min.js",

                        //"~/Scripts/jquery-2.2.0.min.js",
                        //"~/H-ui.admin_v3.0/lib/jquery/1.9.1/jquery.min.js",
                        //"~/Scripts/jquery-ui-1.11.4.min.js",

                        "~/Scripts/moment-with-locales.min.js",
                        //"~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/sweetalert/sweet-alert.min.js",
                        "~/Scripts/others/spinjs/spin.js",
                        "~/Scripts/others/spinjs/jquery.spin.js",

                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js",
                        "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",

                        "~/Scripts/jquery.signalR-2.2.1.min.js",

                        // H-ui
                        "~/Content/H-ui.admin_v3.0/lib/layer/2.4/layer.js",
                        "~/Content/H-ui.admin_v3.0/lib/jquery.contextmenu/jquery.contextmenu.r2.js",
                        "~/Content/H-ui.admin_v3.0/static/h-ui/js/H-ui.js",
                        "~/Content/H-ui.admin_v3.0/static/h-ui.admin/js/H-ui.admin.js"
                    )
                );

            //APPLICATION RESOURCES

            //~/Bundles/css
            bundles.Add(
                new StyleBundle("~/Bundles/css")
                .Include("~/css/pager.css", new CssRewriteUrlTransform())
                .Include("~/css/validation.css", new CssRewriteUrlTransform())
                );

            //~/Bundles/js
            bundles.Add(
            new ScriptBundle("~/Bundles/js")
                .Include("~/js/main.js")
                .Include("~/js/crud.js")
            );

         
            #endregion

            #region otherlib

          //jstree
          bundles.Add(
                new StyleBundle("~/Bundles/lib/css/jstree")
                    .Include("~/Content/H-ui.admin_v3.0/lib/vakata-jstree-9770c67/dist/themes/default/style.css", new CssRewriteUrlTransform())
                );
            bundles.Add(
             new ScriptBundle("~/Bundles/lib/js/jstree")
                 .Include("~/Content/H-ui.admin_v3.0/lib/vakata-jstree-9770c67/dist/jstree.js")
             );

            #endregion
        }
    }
}