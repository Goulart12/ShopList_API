using GroceryStoreShopListApi.Authorization.Models;
using GroceryStoreShopListApi.Authorization.Models.InputModel;

namespace GroceryStoreShopListApi.Authorization.Services;

public interface IUserService
{
    Task CreateUserAsync(UserInputModel userInputModel);
    Task<User?> GetUserAsync(string userId);
    Task<User?> GetUserByEmailAsync(string email);
    Task AddUserRoleAsync(string roleName);
    Task<Role?> GetUserRoleAsync(string roleId);
}