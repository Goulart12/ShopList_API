using GroceryStoreShopListApi.Data;
using GroceryStoreShopListApi.Domain.Domain.App.Models;
using GroceryStoreShopListApi.Domain.Domain.App.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GroceryStoreShopListApi.Infraestructures.Database.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly ShopListContext _shopListContext;

    public ProductRepository(ShopListContext shopListContext)
    {
        _shopListContext = shopListContext;
    }

    public async Task AddProductAsync(Product product)
    {
        _shopListContext.Products.Add(product);
        await _shopListContext.SaveChangesAsync();
    }

    public List<Product>? GetAllProductsAsync(string shopListId)
    {
        var products = _shopListContext.Products.Where(x => x.ShopListId == shopListId).ToList();

        if (products == null)
        {
            return null;
        }
        
        return products;
    }

    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        var product = await _shopListContext.Products.FindAsync(productId);

        if (product == null)
        {
            return null;
        }

        return product;
    }
    
    public async Task<Product?> GetProductByNameAsync(string name)
    {
        var product = await _shopListContext.Products.FirstOrDefaultAsync(x => x.ProductName == name);

        if (product == null)
        {
            return null;
        }

        return product;
    }

    public async Task UpdateProductAsync(Product product)
    {
        _shopListContext.Products.Update(product);
        await _shopListContext.SaveChangesAsync();
    }
    
    public async Task DeleteProductAsync(Product product)
    {
        _shopListContext.Products.Remove(product);
        await _shopListContext.SaveChangesAsync();
    }
}