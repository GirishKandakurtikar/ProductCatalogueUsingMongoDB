using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPIToMongoDB.Models
{
    public class Product
    {
        //public ObjectId Id { get; set; }
        [BsonElement("Id")]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

       
        [BsonElement("SubCategoryId")]
        public string SubCategoryId { get; set; }
    }
}