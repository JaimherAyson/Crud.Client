using System.Net.Http.Json;

public class ItemService
{
    private readonly HttpClient _http;

    public ItemService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Item>?> GetItemsAsync()
        => await _http.GetFromJsonAsync<List<Item>>("api/Items");

    public async Task<Item?> GetItemByIdAsync(string id)
        => await _http.GetFromJsonAsync<Item>($"api/Items/{id}");

    public async Task CreateItemAsync(Item item)
        => await _http.PostAsJsonAsync("api/Items", item);

    public async Task UpdateItemAsync(string id, Item item)
        => await _http.PutAsJsonAsync($"api/Items/{id}", item);

    public async Task DeleteItemAsync(string id)
        => await _http.DeleteAsync($"api/Items/{id}");
}
