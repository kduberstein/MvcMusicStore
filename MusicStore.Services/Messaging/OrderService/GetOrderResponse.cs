#region Using Directives

using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.OrderService
{
    public class GetOrderResponse
    {
        public OrderView Order { get; set; }
    }
}