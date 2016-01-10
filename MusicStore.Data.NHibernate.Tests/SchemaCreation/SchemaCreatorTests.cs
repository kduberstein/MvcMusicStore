#region Using Directives

using MusicStore.Data.NHibernate.SchemaCreation;
using MusicStore.TestUtils.Attributes;
using Xunit;

#endregion

namespace MusicStore.Data.NHibernate.Tests.SchemaCreation
{
    public class SchemaCreatorTests
    {
        [Trait("Category", "Integration")]
        [Theory, AutoMoqContainerData]
        public void CreateScript_FileName_ReturnsTrue(SchemaCreator sut)
        {
            var result = sut.CreateScript("music_store_create_schema.sql");

            Assert.True(result);
        }
    }
}