using GroceryStoreShopListApi.Domain.Domain.App.Models;
using GroceryStoreShopListApi.Domain.Domain.App.Repositories;
using GroceryStoreShopListApi.Helpers;
using GroceryStoreShopListApi.Helpers.Cache;

namespace GroceryStoreShopListApi.Domain.Domain.App.Services;

public class ShopListService : IShopListService
{
    private readonly IShopListRepository _shopListRepository;
    private readonly IProductRepository _productRepository;
    private readonly IAuthHelpers _authHelper;
    private readonly IRedisCacheService _RedisCacheService;

    public ShopListService(IShopListRepository shopListRepository, IProductRepository productRepository, IAuthHelpers authHelper, IRedisCacheService redisCacheService)
    {
        _shopListRepository = shopListRepository;
        _productRepository = productRepository;
        _authHelper = authHelper;
        _RedisCacheService = redisCacheService;
    }
    
    public async Task CreateShoplistAsync(string listName)
    {
        var cacheKey = $"Token_JWT";
        var tokenCache = _RedisCacheService.GetCachedData<string>(cacheKey);

        var userId = _authHelper.GetCurrentUserId(tokenCache);

        var shopList = new ShopList()
        {
            Id = Guid.NewGuid().ToString(),
            UserId = userId,
            ListName = listName
        };
        
        await _shopListRepository.AddShopListAsync(shopList);
    }

    public List<ShopList>? GetAllShopListsAsync()
    {
        var cacheKey = $"Token_JWT";
        var tokenCache = _RedisCacheService.GetCachedData<string>(cacheKey);
        var userId = _authHelper.GetCurrentUserId(tokenCache);
        
        var shopLists = _shopListRepository.GetAllShopLists(userId);
        
        return shopLists;
    }

    public async Task<ShopList?> GetShopListAsync(string shopListId)
    {
        var shopList = await _shopListRepository.GetShopListsAsync(shopListId);

        if (shopList == null)
        {
            return null;
        }
        
        return shopList;
    }

    public async Task<ShopList?> GetShopListByNameAsync(string shopListName)
    {
        var shopList = await _shopListRepository.GetShopListsByName(shopListName);

        if (shopList == null)
        {
            return null;
        }
        
        return shopList;
    }

    public async Task UpdateShopListAsync(string shopListId, string shopListName)
    {
        var shopList = await _shopListRepository.GetShopListsAsync(shopListId);

        if (shopList == null)
        {
            throw new Exception("Shop List Not Found");
        }

        shopList.ListName = shopListName;
        
        await _shopListRepository.UpdateShopListAsync(shopList);
    }
    
    public async Task DeleteShopListAsync(string shopListId)
    {
        var shopList = await _shopListRepository.GetShopListsAsync(shopListId);

        if (shopList == null)
        {
            throw new Exception("Shop List Not Found");
        }
        
        await _shopListRepository.DeleteShopListAsync(shopList);
    }
}