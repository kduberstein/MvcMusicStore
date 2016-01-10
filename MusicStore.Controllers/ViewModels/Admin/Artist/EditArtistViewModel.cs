#region Using Directives

using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace MusicStore.Controllers.ViewModels.Admin.Artist
{
    public class EditArtistViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    }
}