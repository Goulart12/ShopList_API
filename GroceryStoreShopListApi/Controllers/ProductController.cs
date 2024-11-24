using GroceryStoreShopListApi.Domain.Domain.App.Models;
using GroceryStoreShopListApi.Domain.Domain.App.Models.InputModels;
using GroceryStoreShopListApi.Domain.Domain.App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreShopListApi.Controllers;

public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [Authorize]
    [HttpPost]
    [Route("Product/Add/{shopListId}")]
    public async Task<IActionResult> AddProduct([FromRoute] string shopListId, [FromBody] ProductInputModel inputModel)
    {
        await _productService.AddProduct(inputModel, shopListId);
        
        return Ok(new { message = "Product added successfully!" });
    }

    [Authorize]
    [HttpGet]
    [Route("Product/GetAllProducts/{shopListId}")]
    public IActionResult GetAllProducts([FromRoute] string shopListId)
    {
        var products = _productService.GetAllProducts(shopListId);
        
        return Ok(products);
    }
}