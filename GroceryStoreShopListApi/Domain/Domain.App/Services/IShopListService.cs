using GroceryStoreShopListApi.Domain.Domain.App.Models;

namespace GroceryStoreShopListApi.Domain.Domain.App.Services;

public interface IShopListService
{
    Task CreateShoplistAsync(string listName);
    List<ShopList>? GetAllShopListsAsync();
    Task<ShopList?> GetShopListAsync(string shopListId);
    Task<ShopList?> GetShopListByNameAsync(string shopListName);
    Task UpdateShopListAsync(string shopListId, string shopListName);
    Task DeleteShopListAsync(string shopListId);
}