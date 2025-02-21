using MongoDB.Bson;

public class Item
{
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
}
