#region Using Directives

using System;
using System.Collections.Generic;

#endregion

namespace MusicStore.Services.ViewModels
{
    public class OrderView
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public string OrderNumber { get; set; }

        public string Total { get; set; }

        public IEnumerable<OrderItemView> Items { get; set; } 
    }
}