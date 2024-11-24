using GroceryStoreShopListApi.Domain.Domain.App.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryStoreShopListApi.Data;

public class ShopListContext : DbContext
{
    public ShopListContext(DbContextOptions<ShopListContext> options) : base(options)
    {
        
    }
    
    public DbSet<ShopList> ShopLists { get; set; }
    public DbSet<Product> Products { get; set; }
}