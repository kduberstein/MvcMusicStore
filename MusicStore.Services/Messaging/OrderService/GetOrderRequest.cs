#region Using Directives

using System;

#endregion

namespace MusicStore.Services.Messaging.OrderService
{
    public class GetOrderRequest
    {
        public Guid Id { get; set; }
    }
}