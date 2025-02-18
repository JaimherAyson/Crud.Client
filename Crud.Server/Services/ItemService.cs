using Crud.Server.Models;
using MongoDB.Driver;

namespace Crud.Server.Services
{
    public class ItemService
    {
        private readonly IMongoCollection<Item> _items;

        public ItemService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDB"));
            var database = client.GetDatabase("CrudDB");
            _items = database.GetCollection<Item>("Items");
        }

        public async Task<List<Item>> GetAsync() => await _items.Find(_ => true).ToListAsync();
        public async Task<Item?> GetByIdAsync(string id) => await _items.Find(i => i.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Item item) => await _items.InsertOneAsync(item);
        public async Task UpdateAsync(string id, Item item) => await _items.ReplaceOneAsync(i => i.Id == id, item);
        public async Task DeleteAsync(string id) => await _items.DeleteOneAsync(i => i.Id == id);
    }
}
