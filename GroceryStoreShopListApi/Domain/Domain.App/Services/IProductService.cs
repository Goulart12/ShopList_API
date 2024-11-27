using GroceryStoreShopListApi.Domain.Domain.App.Models;
using GroceryStoreShopListApi.Domain.Domain.App.Models.InputModels;

namespace GroceryStoreShopListApi.Domain.Domain.App.Services;

public interface IProductService
{
    Task AddProduct(ProductInputModel inputModel, string shopListId);
    List<Product>? GetAllProducts(string shopListId);
    Task<Product?> GetProductById(int productId);
    Task<Product?> GetProductByName(string productName);
    Task UpdateProduct(ProductInputModel inputModel, string oldName);
    Task DeleteProduct(string productName);
}