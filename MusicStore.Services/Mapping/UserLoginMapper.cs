#region Using Directives

using AutoMapper;
using MusicStore.Model.Ecommerce;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Mapping
{
    public static class UserLoginMapper
    {
        public static UserLoginView ConvertToUserLoginView(this UserLogin userLogin)
        {
            return Mapper.Map<UserLogin, UserLoginView>(userLogin);
        }
    }
}