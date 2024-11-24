using GroceryStoreShopListApi.Domain.Domain.App.Models;

namespace GroceryStoreShopListApi.Domain.Domain.App.Repositories;

public interface IShopListRepository
{
    Task AddShopListAsync(ShopList shopList);
    List<ShopList>? GetAllShopLists(string userId);
    Task<ShopList?> GetShopListsAsync(string shopListId);
    Task<ShopList?> GetShopListsByName(string shopListName);
    Task UpdateShopListAsync(ShopList shopList);
    Task DeleteShopListAsync(ShopList shopList);
}