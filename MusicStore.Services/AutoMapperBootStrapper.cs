#region Using Directives

using AutoMapper;
using MusicStore.Infrastructure.Helpers;
using MusicStore.Model.Customers;
using MusicStore.Model.Ecommerce;
using MusicStore.Model.Orders;
using MusicStore.Model.Products;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services
{
    public static class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            // Genre
            Mapper.CreateMap<Genre, GenreView>();

            // Artist
            Mapper.CreateMap<Artist, ArtistView>();

            // Album
            Mapper.CreateMap<Album, AlbumView>();

            // Cart
            Mapper.CreateMap<Cart, CartView>();
            Mapper.CreateMap<CartItem, CartItemView>();

            // User Login
            Mapper.CreateMap<UserLogin, UserLoginView>();

            // State
            Mapper.CreateMap<State, StateView>();

            // Customer
            Mapper.CreateMap<Customer, CustomerView>();
            Mapper.CreateMap<DeliveryAddress, DeliveryAddressView>();

            // Order
            Mapper.CreateMap<Order, OrderView>();
            Mapper.CreateMap<OrderItem, OrderItemView>();

            // Money Formatter
            Mapper.CreateMap<decimal, string>().ConvertUsing<MoneyFormatter>();
        }
    }

    public class MoneyFormatter : ITypeConverter<decimal, string>
    {
        public string Convert(ResolutionContext context)
        {
            return System.Convert.ToDecimal(context.SourceValue).FormatMoney();
        }
    }
}