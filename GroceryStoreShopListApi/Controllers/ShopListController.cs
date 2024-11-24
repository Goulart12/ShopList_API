using GroceryStoreShopListApi.Domain.Domain.App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreShopListApi.Controllers;

public class ShopListController : ControllerBase
{
    private readonly IShopListService _shopListService;

    public ShopListController(IShopListService shopListService)
    {
        _shopListService = shopListService;
    }
    
    [Authorize]
    [HttpPost]
    [Route("ShopList/Create")]
    public async Task<IActionResult> CreateShopList([FromBody] string listName)
    {
        await _shopListService.CreateShoplistAsync(listName);
        
        return Ok(new { message = "ShopList created successfully!" });
    }

    [Authorize]
    [HttpGet]
    [Route("ShopList/GetAllLists")]
    public IActionResult GetAllShopLists()
    {
        var shopLists = _shopListService.GetAllShopListsAsync();
        
        return Ok(shopLists);
    }
    
    [Authorize]
    [HttpGet]
    [Route("ShopList/GetShopListById")]
    public async Task<IActionResult> GetShopListById(string shopListId)
    {
        var shopLists =  await _shopListService.GetShopListAsync(shopListId);
        
        return Ok(shopLists);
    }
    
    [Authorize]
    [HttpGet]
    [Route("ShopList/GetShopListByName")]
    public async Task<IActionResult> GetShopListByName(string shopListName)
    {
        var shopLists =  await _shopListService.GetShopListByNameAsync(shopListName);
        
        return Ok(shopLists);
    }

    [Authorize]
    [HttpPatch]
    [Route("ShopList/Update/{shopListId}")]
    public async Task<IActionResult> UpdateShopList([FromRoute] string shopListId, [FromBody] string shopListName)
    {
        await _shopListService.UpdateShopListAsync(shopListId, shopListName);
        
        return Ok(new { message = "ShopList updated successfully!" });
    }
    
    [Authorize]
    [HttpDelete]
    [Route("ShopList/Delete/{shopListId}")]
    public async Task<IActionResult> DeleteShopList([FromRoute] string shopListId)
    {
        await _shopListService.DeleteShopListAsync(shopListId);
        
        return Ok(new { message = "ShopList deleted successfully!" });
    }
}