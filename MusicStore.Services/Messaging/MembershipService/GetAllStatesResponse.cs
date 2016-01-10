#region Using Directives

using System.Collections.Generic;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.MembershipService
{
    public class GetAllStatesResponse
    {
        public IEnumerable<StateView> States { get; set; }
    }
}