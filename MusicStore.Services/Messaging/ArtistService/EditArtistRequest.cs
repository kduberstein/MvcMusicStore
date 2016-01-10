#region Using Directives

using System;

#endregion

namespace MusicStore.Services.Messaging.ArtistService
{
    public class EditArtistRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}