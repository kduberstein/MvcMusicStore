#region Using Directives

using System.Web.Mvc;

#endregion

namespace MusicStore.WebUI
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}