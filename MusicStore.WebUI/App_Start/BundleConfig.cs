#region Using Directives

using System.Web.Optimization;

#endregion

namespace MusicStore.WebUI
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Content/Scripts/jquery-{version}.js",
                "~/Content/Scripts/bootstrap.js",
                "~/Content/Scripts/site.js",
                "~/Content/Scripts/respond.js",
                "~/Content/Scripts/bootstrap-hover-dropdown.js",
                "~/Content/Scripts/jquery.maskedinput.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Styles/fonts.css",
                "~/Content/Styles/bootstrap.css",
                "~/Content/Styles/font-awesome.css",
                "~/Content/Styles/site.css",
                "~/Content/Styles/responsive.css"));
        }
    }
}