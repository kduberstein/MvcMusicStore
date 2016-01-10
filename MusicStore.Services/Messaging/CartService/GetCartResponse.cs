#region Using Directives

using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.CartService
{
    public class GetCartResponse
    {
        public CartView Cart { get; set; }
    }
}