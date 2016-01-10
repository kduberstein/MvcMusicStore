#region Using Directives

using System.Linq;
using System.Text.RegularExpressions;
using AutoMapper;
using MusicStore.Controllers.ViewModels.Account;
using MusicStore.Controllers.ViewModels.Admin.Album;
using MusicStore.Controllers.ViewModels.Checkout;
using MusicStore.Services.Messaging.AlbumService;
using MusicStore.Services.Messaging.CustomerService;
using MusicStore.Services.Messaging.MembershipService;
using MusicStore.Services.Messaging.OrderService;

#endregion

namespace MusicStore.Controllers
{
    public static class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<CreateAlbumViewModel, CreateAlbumRequest>()
                .ForMember(dest => dest.Price, opt => opt.ResolveUsing<PriceResolver>().FromMember(src => src.Price));

            Mapper.CreateMap<GetAlbumResponse, EditAlbumViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Album.Id))
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.Album.Genre.Id))
                .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.Album.Artist.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Album.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Album.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Album.Price))
                .ForMember(dest => dest.AlbumArtUrl, opt => opt.MapFrom(src => src.Album.AlbumArtUrl));

            Mapper.CreateMap<EditAlbumViewModel, EditAlbumRequest>()
                .ForMember(dest => dest.Price, opt => opt.ResolveUsing<PriceResolver>().FromMember(src => src.Price));

            Mapper.CreateMap<RegisterAccountViewModel, RegisterUserRequest>();

            Mapper.CreateMap<LoginAccountViewModel, LoginUserRequest>();

            Mapper.CreateMap<GetCustomerResponse, AddressAndPaymentCheckoutViewModel>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Customer.LastName))
                .ForMember(dest => dest.AddressLine1,
                    opt => opt.MapFrom(src => src.Customer.DeliveryAddressBook.FirstOrDefault().AddressLine1))
                .ForMember(dest => dest.AddressLine2,
                    opt => opt.MapFrom(src => src.Customer.DeliveryAddressBook.FirstOrDefault().AddressLine2))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Customer.DeliveryAddressBook.FirstOrDefault().City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Customer.DeliveryAddressBook.FirstOrDefault().State))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Customer.DeliveryAddressBook.FirstOrDefault().ZipCode));

            Mapper.CreateMap<AddressAndPaymentCheckoutViewModel, CreateOrderRequest>();
        }
    }

    public class PriceResolver : ValueResolver<string, decimal>
    {
        protected override decimal ResolveCore(string source)
        {
            // Strip whitespace if present
            var price = Regex.Replace(source, @"\s+", string.Empty);

            // Remove any alpha characters
            return decimal.Parse(Regex.Replace(price, @"[^0-9.]", string.Empty));
        }
    }
}