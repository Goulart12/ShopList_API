using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GroceryStoreShopListApi.Domain.Domain.App.Models;

[Table("shoplist")]
public class ShopList
{
    [Key]
    [Column("id")]
    public string Id { get; set;} = string.Empty;
    
    [ForeignKey("User")]
    [Column("userId")]
    public string UserId { get; set;} = string.Empty;
    
    [Column("listName")]
    public string ListName { get; set; } = string.Empty;
    
    [Key]
    [Column("product")]
    public Product? Product { get; set; }
}