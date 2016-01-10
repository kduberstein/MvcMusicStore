#region Using Directives

using MusicStore.TestUtils.Customizations;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Xunit2;

#endregion

namespace MusicStore.TestUtils.Attributes
{
    public class AutoMoqContainerDataAttribute : AutoDataAttribute
    {
        public AutoMoqContainerDataAttribute()
            : base(new Fixture().Customize(new WindsorCustomization()).Customize(new AutoConfiguredMoqCustomization()))
        {
        }
    }
}