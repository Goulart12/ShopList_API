using System.Text.RegularExpressions;
using GroceryStoreShopListApi.Authorization.Models;
using GroceryStoreShopListApi.Authorization.Models.InputModel;
using GroceryStoreShopListApi.Domain.Domain.Authorization.Repositories;
using BCrypt.Net;
using static BCrypt.Net.BCrypt;


namespace GroceryStoreShopListApi.Authorization.Services;

public partial class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    private const int WorkFactor = 12;
    private const string PasswordValidationRegEx = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-+_.]).{8,16}$";

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CreateUserAsync(UserInputModel userInputModel)
    {
        var getUser = await _userRepository.GetByEmailAsync(userInputModel.Email);

        if (getUser != null)
        {
            throw new Exception("UserAlreadyExists");
        }

        if (!MyRegex().IsMatch(userInputModel.Password))
        {
            throw new Exception("InvalidPassword");
        }
        
        var hash = HashPassword(userInputModel.Password, WorkFactor);

        var user = new User()
        {
            Id = Guid.NewGuid().ToString(),
            Email = userInputModel.Email,
            FirstName = userInputModel.FirstName,
            LastName = userInputModel.LastName,
            Password = hash,
        };
        
        await _userRepository.AddUserAsync(user);
    }

    public async Task<User?> GetUserAsync(string userId)
    {
        var user = await _userRepository.GetUserAsync(userId);

        if (user == null)
        {
            return null;
        }
        
        return user;
    }
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user == null)
        {
            return null;
        }
        
        return user;
    }

    [GeneratedRegex(PasswordValidationRegEx)]
    private static partial Regex MyRegex();
}