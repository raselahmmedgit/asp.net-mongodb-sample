using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lab.MongoDBApps.Models
{
    public class BaseModel
    {
        public ObjectId Id { get; set; }

        [BsonIgnore]
        public string SuccessMessage { get; set; }

        [BsonIgnore]
        public string ErrorMessage { get; set; }

        [BsonIgnore]
        public bool IsSuccess { get; set; }
    }
}