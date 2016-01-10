#region Using Directives

using AutoMapper;
using MusicStore.Model.Orders;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Mapping
{
    public static class OrderMapper
    {
        public static OrderView ConvertToOrderView(this Order order)
        {
            return Mapper.Map<Order, OrderView>(order);
        }
    }
}