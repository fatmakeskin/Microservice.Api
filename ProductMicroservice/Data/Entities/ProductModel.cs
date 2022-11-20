using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductMicroservice.Entities
{
    public class ProductModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ProductId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
