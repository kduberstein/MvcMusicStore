#region Using Directives

using System;
using System.Linq;
using System.Web;
using Castle.MicroKernel;

#endregion

namespace MusicStore.Data.NHibernate.SessionStorage
{
    public class StorageContainerSelector : IHandlerSelector
    {
        public bool HasOpinionAbout(string key, Type service)
        {
            return service == typeof (ISessionStorageContainer);
        }

        public IHandler SelectHandler(string key, Type service, IHandler[] handlers)
        {
            return HttpContext.Current == null
                ? handlers.First(a => a.ComponentModel.Name.Equals("ThreadSessionContainer"))
                : handlers.First(a => a.ComponentModel.Name.Equals("HttpSessionContainer"));
        }
    }
}