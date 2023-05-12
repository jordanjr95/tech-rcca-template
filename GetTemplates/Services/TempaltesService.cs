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

        public async Task<Template?> GetAsync(string id) =>
            await _templatesCollection.Find(x => x.templateID == id).FirstOrDefaultAsync();

        public async Task DeleteAsync(string id) =>
            await _templatesCollection.DeleteOneAsync(x => x.templateID == id);

        public async Task UpdateAsync(string id, Template updatedTemplate) =>
            await _templatesCollection.ReplaceOneAsync(x => x.templateID == id, updatedTemplate);

        public async Task CreateAsync(Template newTemplate) =>
            await _templatesCollection.InsertOneAsync(newTemplate);
    }
}
