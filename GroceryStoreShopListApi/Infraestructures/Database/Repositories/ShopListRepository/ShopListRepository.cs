using GroceryStoreShopListApi.Data;
using GroceryStoreShopListApi.Domain.Domain.App.Models;
using GroceryStoreShopListApi.Domain.Domain.App.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GroceryStoreShopListApi.Infraestructures.Database.Repositories.ShopListRepository;

public class ShopListRepository : IShopListRepository
{
    private readonly ShopListContext _shopListContext;

    public ShopListRepository(ShopListContext shopListContext)
    {
        _shopListContext = shopListContext;
    }

    public async Task AddShopListAsync(ShopList shopList)
    {
        _shopListContext.ShopLists.Add(shopList);
        await _shopListContext.SaveChangesAsync();
    }

    public List<ShopList>? GetAllShopLists(string userId)
    {
        var shopLists = _shopListContext.ShopLists.Where(x => x.UserId == userId).ToList();

        if (shopLists == null)
        {
            return null;
        }
        
        return shopLists;
    }

    public async Task<ShopList?> GetShopListsAsync(string shopListId)
    {
        var shopList = await _shopListContext.ShopLists.FindAsync(shopListId);

        if (shopList == null)
        {
            return null;
        }
        
        return shopList;
    }
    
    public async Task<ShopList?> GetShopListsByName(string shopListName)
    {
        var shopList = await _shopListContext.ShopLists.FirstOrDefaultAsync(x => x.ListName == shopListName);

        if (shopList == null)
        {
            return null;
        }

        return shopList;
    }

    public async Task UpdateShopListAsync(ShopList shopList)
    {
        _shopListContext.ShopLists.Update(shopList);
        await _shopListContext.SaveChangesAsync();
    }

    public async Task DeleteShopListAsync(ShopList shopList)
    {
        _shopListContext.ShopLists.Remove(shopList);
        await _shopListContext.SaveChangesAsync();
    }
}