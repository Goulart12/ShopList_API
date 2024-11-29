using GroceryStoreShopListApi.Authorization.Models;
using GroceryStoreShopListApi.Domain.Domain.Authorization.Repositories;
using GroceryStoreShopListApi.Helpers;
using BCrypt.Net;
using GroceryStoreShopListApi.Helpers.Cache;
using StackExchange.Redis;
using static BCrypt.Net.BCrypt;

namespace GroceryStoreShopListApi.Authorization.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthHelpers _authHelper;
    private readonly IRedisCacheService _RedisCacheService;

    public AuthenticationService(IUserRepository userRepository, IAuthHelpers authHelper, IRedisCacheService redisCacheService)
    {
        _userRepository = userRepository;
        _authHelper = authHelper;
        _RedisCacheService = redisCacheService;
    }

    public async Task<string> AuthenticateUser(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (!Verify(password, user.Password))
        {
            throw new Exception("Invalid password");
        }

        var token = _authHelper.GenerateJwtToken(user);
        
        var cacheKey = $"Token_JWT";

        var tokenCache = _RedisCacheService.GetCachedData<string>(cacheKey);

        if (tokenCache != null)
        {
            _RedisCacheService.RemoveCachedData(cacheKey);
        }
        
        _RedisCacheService.SetCachedData(cacheKey, token, TimeSpan.FromMinutes(30));

        return token;
    }
}