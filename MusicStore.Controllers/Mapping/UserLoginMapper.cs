#region Using Directives

using AutoMapper;
using MusicStore.Controllers.ViewModels.Account;
using MusicStore.Services.Messaging.MembershipService;

#endregion

namespace MusicStore.Controllers.Mapping
{
    public static class UserLoginMapper
    {
        public static RegisterUserRequest ConvertToRegisterUserLoginRequest(this RegisterAccountViewModel model)
        {
            return Mapper.Map<RegisterAccountViewModel, RegisterUserRequest>(model);
        }

        public static LoginUserRequest ConvertToLoginUserRequest(this LoginAccountViewModel model)
        {
            return Mapper.Map<LoginAccountViewModel, LoginUserRequest>(model);
        }
    }
}