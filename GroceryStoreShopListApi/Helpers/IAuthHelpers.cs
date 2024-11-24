using GroceryStoreShopListApi.Authorization.Models;

namespace GroceryStoreShopListApi.Helpers;

public interface IAuthHelpers
{
    string GenerateJwtToken(User user);
    string GetCurrentUserId(string jwtToken);
}