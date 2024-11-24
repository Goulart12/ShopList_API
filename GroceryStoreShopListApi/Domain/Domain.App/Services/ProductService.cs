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
            ShopListId = shopListId,
            ShopList = shopList
        };
        
        await _productRepository.AddProductAsync(product);
        
        // shopList.Product = product;
        // await _shopListRepository.UpdateShopListAsync(shopList);
    }

    public List<Product>? GetAllProducts(string shopListId)
    {
        var products = _productRepository.GetAllProductsAsync(shopListId); 
        
        return products;
    }
}