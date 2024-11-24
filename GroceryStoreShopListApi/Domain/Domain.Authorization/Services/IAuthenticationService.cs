namespace GroceryStoreShopListApi.Authorization.Services;

public interface IAuthenticationService
{
    Task<string> AuthenticateUser(string email, string password);
}