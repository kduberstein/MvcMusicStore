#region Using Directives

using System.ComponentModel.DataAnnotations;

#endregion

namespace MusicStore.Controllers.ViewModels.Admin.Genre
{
    public class CreateGenreViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
    }
}