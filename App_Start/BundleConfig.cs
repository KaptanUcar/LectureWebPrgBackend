﻿using System.Web;
using System.Web.Optimization;

namespace LectureWebPrgBackend
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                            "~/Scripts/jquery.min.js",
                            "~/Scripts/bootstrap.bundle.min.js",
                            "~/Scripts/js.cookie.js"
                        ));

            bundles.Add(new ScriptBundle("~/Scripts/jquery-ext").Include(
                            "~/Scripts/jquery.scrollbar.min.js",
                            "~/Scripts/jquery-scrollLock.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/Scripts/argon").Include(
                            "~/Scripts/argon.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/nucleo.css",
                      "~/Content/fontawesome-free/css/all.min.css",
                      "~/Content/argon.css"));
        }
    }
}
