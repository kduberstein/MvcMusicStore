#region Using Directives

using System.Collections.Generic;

#endregion

namespace MusicStore.Model.Customers
{
    public interface IStateRepository
    {
        IEnumerable<State> FindAll();
    }
}