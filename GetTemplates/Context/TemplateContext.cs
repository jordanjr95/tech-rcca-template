using GetTemplates.Models;
using Microsoft.EntityFrameworkCore;


namespace GetTemplates.Context
{
    public class TemplateContext : DbContext
    {
        public TemplateContext(DbContextOptions<TemplateContext> options) 
            : base(options) 
        {
        
        }
        public DbSet<Template> Template { get; set; }
    }
}
