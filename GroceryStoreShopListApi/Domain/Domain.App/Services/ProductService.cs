using GroceryStoreShopListApi.Domain.Domain.App.Models;
using GroceryStoreShopListApi.Domain.Domain.App.Models.InputModels;
using GroceryStoreShopListApi.Domain.Domain.App.Repositories;
using GroceryStoreShopListApi.Helpers;
using GroceryStoreShopListApi.Helpers.Cache;

namespace GroceryStoreShopListApi.Domain.Domain.App.Services;

public class ProductService : IProductService
{
    private readonly IShopListRepository _shopListRepository;
    private readonly IProductRepository _productRepository;
    private readonly IAuthHelpers _authHelper;
    private readonly IRedisCacheService _RedisCacheService;

    public ProductService(IShopListRepository shopListRepository, IProductRepository productRepository, IAuthHelpers authHelper, IRedisCacheService redisCacheService)
    {
        _shopListRepository = shopListRepository;
        _productRepository = productRepository;
        _authHelper = authHelper;
        _RedisCacheService = redisCacheService;
    }

    public async Task AddProduct(ProductInputModel inputModel, string shopListId)
    {
        var shopList = await _shopListRepository.GetShopListsAsync(shopListId);

        if (shopList == null)
        {
            throw new Exception($"ShopList with id: {shopListId} does not exist.");
        }

        var product = new Product()
        {
            ProductName = inputModel.ProductName,
            Quantity = inputModel.Quantity,
            ShopListId = shopListId
        };
        
        await _productRepository.AddProductAsync(product);
    }

    public List<Product>? GetAllProducts(string shopListId)
    {
        var products = _productRepository.GetAllProductsAsync(shopListId); 
        
        return products;
    }

    public async Task<Product?> GetProductById(int productId)
    {
        var product = await _productRepository.GetProductByIdAsync(productId);
        
        return product;
    }
    
    public async Task<Product?> GetProductByName(string productName, string shopListId)
    {
        var product = await _productRepository.GetProductByNameAsync(productName, shopListId);
        
        return product;
    }

    public async Task UpdateProduct(ProductInputModel inputModel, string oldName, string shopListId)
    {
        var product = await _productRepository.GetProductByNameAsync(oldName, shopListId);
        
        if (product == null) return;
        
        product.ProductName = inputModel.ProductName;
        product.Quantity = inputModel.Quantity;
        
        await _productRepository.UpdateProductAsync(product);
    }
    
    public async Task DeleteProduct(string productName, string shopListId)
    {
        var product = await _productRepository.GetProductByNameAsync(productName, shopListId);
        
        if (product == null) return;
        
        await _productRepository.DeleteProductAsync(product);
    }
}