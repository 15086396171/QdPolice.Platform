using System.Web.Optimization;

namespace Vickn.Platform.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            // 默认不压缩
            BundleTable.EnableOptimizations = false;

            //VENDOR RESOURCES

            #region Platformlib

            //~/Bundles/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/vendor/css")
                    .Include("~/Content/Hplus/css/bootstrap.min.css", new CssRewriteUrlTransform())
                    .Include("~/Content/Hplus/css/font-awesome.min.css", new CssRewriteUrlTransform())
                    .Include("~/Content/Hplus/css/animate.css", new CssRewriteUrlTransform())
                    .Include("~/Content/Hplus/css/style.css", new CssRewriteUrlTransform())

                    .Include("~/Content/Hplus/css/plugins/dataTables/dataTables.bootstrap.css", new CssRewriteUrlTransform())
                    .Include("~/Content/Hplus/css/plugins/toastr/toastr.min.css", new CssRewriteUrlTransform())
                    .Include("~/Content/Hplus/css/plugins/iCheck/custom.css", new CssRewriteUrlTransform())
                );

            //~/Bundles/vendor/js/top (These scripts should be included in the head of the page)
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/top")
                    .Include(
                    "~/Scripts/jquery-2.2.1.js",
                        "~/Abp/Framework/scripts/utils/ie10fix.js",
                        "~/Scripts/modernizr-2.8.3.js"
                    )
                );

            //~/Bundles/vendor/bottom (Included in the bottom for fast page load)
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/bottom")
                    .Include(
                        "~/Scripts/json2.min.js",

                        // jqvaliate

                        "~/Scripts/jquery.validation/1.14.0/jquery.validate.js",
                        "~/Scripts/jquery.validation/1.14.0/jquery.validate.unobtrusive.js",

                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/others/spinjs/spin.js",
                        "~/Scripts/others/spinjs/jquery.spin.js",

                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js",
                        "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",

                        "~/Scripts/moment.min.js",
                        "~/Scripts/moment-with-locales.min.js",

                        "~/Scripts/jquery.signalR-2.2.1.min.js",

                        // datatable
                        "~/Content/Hplus/js/plugins/dataTables/jquery.dataTables.js",
                        "~/Content/Hplus/js/plugins/dataTables/dataTables.bootstrap.js",
                                                "~/js/datatable.extend.js",
                        // layer
                        "~/Content/Hplus/js/plugins/layer/layer.min.js",

                        // layerDate
                        "~/Content/Hplus/js/plugins/layer/laydate/laydate.js",

                        // H+
                        /*< !--全局js-- >*/
                        "~/Content/Hplus/js/bootstrap.min.js",
                        "~/Content/Hplus/js/plugins/metisMenu/jquery.metisMenu.js",
                        "~/Content/Hplus/js/plugins/slimscroll/jquery.slimscroll.min.js",
                  
                        /*   <!-- 自定义js -->*/
                        "~/Content/Hplus/js/hplus.js",
                        "~/Content/Hplus/js/contabs.js",
                        //"~/Content/Hplus/js/content.js",

                          /*   <!-- 第三方插件 -->*/
                          "~/Content/Hplus/js/plugins/iCheck/icheck.min.js",
                          "~/js/icheck.fn.js"
                    )
                );

            //APPLICATION RESOURCES

            //~/Bundles/css
            bundles.Add(
                new StyleBundle("~/Bundles/css")
                .Include("~/css/pager.css", new CssRewriteUrlTransform())
                .Include("~/css/validation.css", new CssRewriteUrlTransform())
                .Include("~/css/common.css", new CssRewriteUrlTransform())
                );

            //~/Bundles/js
            bundles.Add(
            new ScriptBundle("~/Bundles/js")
                .Include("~/js/main.js")
            );

            #endregion

            #region otherlib

            //jstree
            bundles.Add(
                  new StyleBundle("~/Bundles/lib/css/jstree")
                      .Include("~/Content/Hplus/css/plugins/jsTree/style.min.css", new CssRewriteUrlTransform())
                  );
            bundles.Add(
             new ScriptBundle("~/Bundles/lib/js/jstree")
                 .Include("~/Content/Hplus/js/plugins/jsTree/jstree.js")
             );

            //ztree
            bundles.Add(
                  new StyleBundle("~/Bundles/lib/css/ztree/metro")
                      .Include("~/Content/Hplus/js/plugins/zTree/v3/css/metroStyle/metroStyle.css", new CssRewriteUrlTransform())
                  );
            bundles.Add(
             new ScriptBundle("~/Bundles/lib/js/ztree/core")
                 .Include("~/Content/Hplus/js/plugins//zTree/v3/js/jquery.ztree.core-3.5.js", "~/Content/Hplus/js/plugins//zTree/v3/js/jquery.ztree.excheck-3.5.js")
             );

            #endregion
        }
    }
}