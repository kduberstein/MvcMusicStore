#region Using Directives

using System;

#endregion

namespace MusicStore.Services.ViewModels
{
    public class GenreView
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}