using GetTemplates.Context;
using GetTemplates.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GetTemplates.Services
{
    public class TempaltesService
    {
        private readonly IMongoCollection<Template> _templatesCollection;

        public TempaltesService(
        IOptions<TemplateDatabaseSettings> templateDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                templateDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                templateDatabaseSettings.Value.DatabaseName);

            _templatesCollection = mongoDatabase.GetCollection<Template>(
                templateDatabaseSettings.Value.TemplatesCollectioName);
        }

        public async Task<List<Template>> GetAsync() =>
        await _templatesCollection.Find(_ => true).ToListAsync();
    }
}
