using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryStoreShopListApi.Authorization.Models;

public class Role
{
    [Column("Id")]
    public int RoleId { get; set; }
    
    [Column("Name")]
    public string RoleName { get; set; } = string.Empty;
    
    [Column("User")]
    public List<User>? User { get; set; }
}