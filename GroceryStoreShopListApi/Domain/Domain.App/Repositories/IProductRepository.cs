using GroceryStoreShopListApi.Domain.Domain.App.Models;

namespace GroceryStoreShopListApi.Domain.Domain.App.Repositories;

public interface IProductRepository
{
    Task AddProductAsync(Product product);
    List<Product>? GetAllProductsAsync(string shopListId);
    Task<Product?> GetProductByIdAsync(int productId);
    Task<Product?> GetProductByNameAsync(string name, string shopListId);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(Product product);
}