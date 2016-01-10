#region Using Directives

using MusicStore.Data.NHibernate.SessionStorage;
using MusicStore.Infrastructure.SchemaCreation;
using NHibernate.Tool.hbm2ddl;

#endregion

namespace MusicStore.Data.NHibernate.SchemaCreation
{
    public class SchemaCreator : ISchemaCreator
    {
        private readonly IConfigurationBuilder _cfgBuilder;

        public SchemaCreator(IConfigurationBuilder cfgBuilder)
        {
            _cfgBuilder = cfgBuilder;
        }

        public bool CreateScript(string fileName)
        {
            var cfg = _cfgBuilder.BuildConfiguration();

            new SchemaExport(cfg).SetOutputFile(fileName).Create(true, false);

            return true;
        }
    }
}