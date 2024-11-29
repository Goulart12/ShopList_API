using GroceryStoreShopListApi.Authorization.Models;

namespace GroceryStoreShopListApi.Domain.Domain.Authorization.Repositories;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<User?> GetUserAsync(string userId);
    Task<User?> GetByEmailAsync(string email);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);
    Task AddRoleAsync(Role role);
    Task<Role?> GetRoleAsync(string roleId);
}