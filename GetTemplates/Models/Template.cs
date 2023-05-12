using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GetTemplates.Models
{
    public class Template
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("Id")]
        public string? templateID { get; set; }

        [BsonElement("templateName")]
        public string templateName { get; set; }

        [BsonElement("listOfElements")]
        public string Fields { get; set; }
      
    }
}
