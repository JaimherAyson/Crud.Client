using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Crud.Server.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
