#region Using Directives

using System;

#endregion

namespace MusicStore.Controllers.ViewModels.Cart
{
    public class RemoveCartItemViewModel
    {
        public string Message { get; set; }

        public string CartTotal { get; set; }

        public int CartCount { get; set; }

        public int ItemQty { get; set; }

        public Guid DeleteId { get; set; }
    }
}