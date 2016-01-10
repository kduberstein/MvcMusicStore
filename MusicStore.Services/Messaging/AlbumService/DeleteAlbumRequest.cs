#region Using Directives

using System;

#endregion

namespace MusicStore.Services.Messaging.AlbumService
{
    public class DeleteAlbumRequest
    {
        public Guid Id { get; set; }
    }
}