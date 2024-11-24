using GroceryStoreShopListApi.Authorization.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroceryStoreShopListApi.Database.Maps;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(80).HasColumnName("FirstName").HasColumnType("VARCHAR");
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(80).HasColumnName("LastName").HasColumnType("VARCHAR");
        builder.Property(x => x.Email).IsRequired().HasMaxLength(160).HasColumnName("Email").HasColumnType("VARCHAR");
        builder.Property(x => x.Password).IsRequired().HasMaxLength(255).HasColumnName("Password").HasColumnType("VARCHAR");
    }
}