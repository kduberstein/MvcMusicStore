#region Using Directives

using MusicStore.Services.Messaging.CartService;

#endregion

namespace MusicStore.Services.Interfaces
{
    public interface ICartService
    {
        CreateCartResponse CreateCart(CreateCartRequest request);

        EditCartResponse EditCart(EditCartRequest request);

        GetCartResponse GetCart(GetCartRequest request);
    }
}