#region Using Directives

using System.ComponentModel.DataAnnotations;

#endregion

namespace MusicStore.Controllers.ViewModels.Account
{
    public class LoginAccountViewModel : AccountView
    {
        [Required(ErrorMessage = "Email address is required.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}