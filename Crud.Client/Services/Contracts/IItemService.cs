using System.Threading.Tasks;

namespace Crud.Client.Services.Contracts
{
    public interface IItemService
    {
        Task<List<Item>?> GetItemsAsync();
        Task<Item?> GetItemByIdAsync(string id);
        Task CreateItemAsync(Item item);
        Task UpdateItemAsync(string id, Item item);
        Task DeleteItemAsync(string id);
        Task<string> GetConn();
    }
}
