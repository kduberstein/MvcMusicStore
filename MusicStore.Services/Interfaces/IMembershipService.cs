#region Using Directives

using MusicStore.Services.Messaging.MembershipService;

#endregion

namespace MusicStore.Services.Interfaces
{
    public interface IMembershipService
    {
        GetAllStatesResponse GetAllStates();

        LoginUserResponse LoginUser(LoginUserRequest request);

        RegisterUserResponse RegisterUserLogin(RegisterUserRequest request);
    }
}