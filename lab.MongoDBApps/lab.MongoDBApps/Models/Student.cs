using MongoDB.Bson.Serialization.Attributes;

namespace lab.MongoDBApps.Models
{
    public class Student : BaseModel
    {
        [BsonElement("StudentId")]
        public int StudentId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }
        
    }
}