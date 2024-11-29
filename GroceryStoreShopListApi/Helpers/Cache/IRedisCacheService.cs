namespace GroceryStoreShopListApi.Helpers.Cache;

public interface IRedisCacheService
{
    T GetCachedData<T>(string key);
    void SetCachedData<T>(string key, T data, TimeSpan cacheDuration);
    void RemoveCachedData(string key);
}