namespace MusicStore.Controllers.ViewModels.Account
{
    public abstract class AccountView
    {
        public bool HasIssues { get; set; }

        public string ErrorMessage { get; set; }
    }
}