#region Using Directives

using System.Web.Mvc;
using MusicStore.Infrastructure.Authentication.Principal;

#endregion

namespace MusicStore.Controllers.ViewModels.Shared
{
    public abstract class BasePageViewModel : WebViewPage
    {
        public new virtual CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }

    public abstract class BasePageViewModel<TModel> : WebViewPage<TModel>
    {
        public new virtual CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }
}