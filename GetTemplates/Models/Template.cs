using System.ComponentModel.DataAnnotations.Schema;

namespace GetTemplates.Models
{
    public class Template
    {
        public int templateID { get; set; }
        public string templateName { get; set; }
        public string Fields { get; set; }
      
    }
}
