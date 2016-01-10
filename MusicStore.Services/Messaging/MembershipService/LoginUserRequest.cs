namespace MusicStore.Services.Messaging.MembershipService
{
    public class LoginUserRequest
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public bool HasIssues { get; set; }

        public string ErrorMessage { get; set; }
    }
}