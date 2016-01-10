#region Using Directives

using System.ComponentModel.DataAnnotations;

#endregion

namespace MusicStore.Controllers.ViewModels.Admin.Artist
{
    public class CreateArtistViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    }
}