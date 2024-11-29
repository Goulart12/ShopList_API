using GroceryStoreShopListApi.Authorization.Models;
using GroceryStoreShopListApi.Data;
using GroceryStoreShopListApi.Domain.Domain.Authorization.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace GroceryStoreShopListApi.Infraestructures.Database.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly UserContext _userContext;

    public UserRepository(UserContext userContext)
    {
        _userContext = userContext;
    }

    public async Task AddUserAsync(User user)
    {
        _userContext.Users.Add(user);
        await _userContext.SaveChangesAsync();
    }

    public async Task<User?> GetUserAsync(string userId)
    {
        var user = await _userContext.Users.FindAsync(userId);

        if (user == null)
        {
            return null;
        }

        return user;
    }
    
    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await _userContext.Users.FirstOrDefaultAsync(x => x.Email == email);

        if (user == null)
        {
            return null;
        }

        return user;
    }

    public async Task UpdateUserAsync(User user)
    {
        _userContext.Users.Update(user);
        await _userContext.SaveChangesAsync();
    }
    
    public async Task DeleteUserAsync(User user)
    {
        _userContext.Users.Remove(user);
        await _userContext.SaveChangesAsync();
    }

    public async Task AddRoleAsync(Role role)
    {
        _userContext.Roles.Add(role);
        await _userContext.SaveChangesAsync();
    }

    public async Task<Role?> GetRoleAsync(string roleId)
    {
        var role = await _userContext.Roles.FindAsync(roleId);

        return role;
    }
}