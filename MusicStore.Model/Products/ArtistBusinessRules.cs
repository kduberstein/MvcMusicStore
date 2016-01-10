#region Using Directives

using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Products
{
    public static class ArtistBusinessRules
    {
        public static readonly BusinessRule NameRequired
            = new BusinessRule("Name", "An artist must have a name.");
    }
}