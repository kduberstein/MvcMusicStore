#region Using Directives

using System;

#endregion

namespace MusicStore.Services.Messaging.GenreService
{
    public class EditGenreRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}