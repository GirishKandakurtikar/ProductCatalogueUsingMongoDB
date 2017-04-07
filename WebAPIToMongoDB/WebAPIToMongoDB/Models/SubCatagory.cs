using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPIToMongoDB.Models
{
    public class SubCategory
    {
        [BsonElement("Id")]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("CategoryId")]
        public string CategoryId { get; set; }

    }
}
