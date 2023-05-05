using GetTemplates.Models;

namespace GetTemplates.Context
{
    public class TemplateDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TemplatesCollectioName { get; set; } = null!;
    }
}
