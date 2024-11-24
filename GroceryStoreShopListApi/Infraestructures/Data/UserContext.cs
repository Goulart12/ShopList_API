using GroceryStoreShopListApi.Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryStoreShopListApi.Data;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}