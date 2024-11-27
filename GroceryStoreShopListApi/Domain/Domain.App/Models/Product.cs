using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryStoreShopListApi.Domain.Domain.App.Models;

[Table("product")]
public class Product
{
    // [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string ProductName { get; set; } = string.Empty;
    
    [Column("quantity")]
    public int Quantity { get; set; }
    
    // [ForeignKey("ShopList")]
    [Column("shoplistId")]
    public string ShopListId { get; set; } = string.Empty;
    
    [Column("shoplist")]
    public ShopList ShopList { get; set; }
}