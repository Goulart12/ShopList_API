using GroceryStoreShopListApi.Authorization.Models.InputModel;
using GroceryStoreShopListApi.Authorization.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreShopListApi.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthenticationService _authenticationService;

    public UserController(IUserService userService, IAuthenticationService authenticationService)
    {
        _userService = userService;
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [Route("User/Register")]
    public async Task<IActionResult> CreateUser(UserInputModel inputModel)
    {
        await _userService.CreateUserAsync(inputModel);
        
        return Ok(new { message = "User created successfully!" });
    }

    [Authorize]
    [HttpGet]
    [Route("User/GetUser")]
    public async Task<IActionResult> GetUser(string userId)
    {
        var result = await _userService.GetUserAsync(userId);
        
        return Ok(result);
    }
    
    [HttpGet]
    [Route("User/GetByEmailUser")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var result = await _userService.GetUserByEmailAsync(email);
        
        return Ok(result);
    }

    [HttpPost]
    [Route("User/Login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var result = await _authenticationService.AuthenticateUser(email, password);
        
        return Ok(result);
    }

    [HttpPost]
    [Route("User/AddRole")]
    public async Task<IActionResult> AddRole([FromBody] string roleName)
    {
        await _userService.AddUserRoleAsync(roleName);
        
        return Ok(new { message = "Role added successfully!" });
    }

    [HttpGet]
    [Route("User/GetRoles/{roleId}")]
    public async Task<IActionResult> GetRoles([FromRoute] string roleId)
    {
        var result = await _userService.GetUserRoleAsync(roleId);

        return Ok(result);
    }
}