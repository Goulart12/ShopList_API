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

    [Authorize]
    [HttpGet]
    [Route("Product/GetProduct/{productId}")]
    public async Task<IActionResult> GetProduct([FromRoute] int productId)
    {
        var product = await _productService.GetProductById(productId);
        
        return Ok(product);
    }
    
    [Authorize]
    [HttpGet]
    [Route("Product/GetProductByName")]
    public async Task<IActionResult> GetProductByName([FromBody] string productName)
    {
        var product = await _productService.GetProductByName(productName);
        
        return Ok(product);
    }

    [Authorize]
    [HttpPatch]
    [Route("Product/Update/{oldName}")]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductInputModel inputModel, [FromRoute] string oldName)
    {
        await _productService.UpdateProduct(inputModel, oldName);
        
        return Ok(new { message = "Product updated successfully!" });
    }

    [Authorize]
    [HttpDelete]
    [Route("Product/Delete/{productName}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] string productName)
    {
        await _productService.DeleteProduct(productName);
        
        return Ok(new { message = "Product deleted successfully!" });
    }
}