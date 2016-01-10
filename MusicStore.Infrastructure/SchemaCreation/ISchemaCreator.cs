namespace MusicStore.Infrastructure.SchemaCreation
{
    public interface ISchemaCreator
    {
        bool CreateScript(string fileName);
    }
}