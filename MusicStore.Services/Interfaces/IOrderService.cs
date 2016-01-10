#region Using Directives

using MusicStore.Services.Messaging.OrderService;

#endregion

namespace MusicStore.Services.Interfaces
{
    public interface IOrderService
    {
        CreateOrderResponse CreateOrder(CreateOrderRequest request);

        GetOrderResponse GetOrder(GetOrderRequest request);
    }
}