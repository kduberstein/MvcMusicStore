﻿#region Using Directives

using System;

#endregion

namespace MusicStore.Services.Messaging.OrderService
{
    public class CreateOrderRequest
    {
        public Guid CartId { get; set; }

        public Guid CustomerId { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}