﻿using System.Net.Http.Json;
using Crud.Client.Services.Contracts;

public class ItemService : IItemService
{
    private readonly HttpClient _httpClient;

    public ItemService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<List<Item>?> GetItemsAsync()
        => await _httpClient.GetFromJsonAsync<List<Item>>("api/Items");

    public async Task<Item?> GetItemByIdAsync(string id)
        => await _httpClient.GetFromJsonAsync<Item>($"api/Items/{id}");

    public async Task CreateItemAsync(Item item)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Items", item);
        response.EnsureSuccessStatusCode(); // Ensures the request was successful
    }

    public async Task UpdateItemAsync(string id, Item item)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Items/{id}", item);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteItemAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"api/Items/{id}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<string> GetConn()
    {
        var response = await _httpClient.GetAsync("api/testConn/getdata");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

}
