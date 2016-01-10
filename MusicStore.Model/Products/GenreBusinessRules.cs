#region Using Directives

using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Products
{
    public static class GenreBusinessRules
    {
        public static readonly BusinessRule NameRequired
            = new BusinessRule("Name", "A genre must have a name.");

        public static readonly BusinessRule DescriptionRequired
            = new BusinessRule("Description", "A genre must have a description.");
    }
}