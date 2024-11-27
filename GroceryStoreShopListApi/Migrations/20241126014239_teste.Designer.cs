﻿// <auto-generated />
using GroceryStoreShopListApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GroceryStoreShopListApi.Migrations
{
    [DbContext(typeof(ShopListContext))]
    [Migration("20241126014239_teste")]
    partial class teste
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GroceryStoreShopListApi.Domain.Domain.App.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<string>("ShopListId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("shoplistId");

                    b.HasKey("Id");

                    b.ToTable("product");
                });

            modelBuilder.Entity("GroceryStoreShopListApi.Domain.Domain.App.Models.ShopList", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("ListName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("listName");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.ToTable("shoplist");
                });
#pragma warning restore 612, 618
        }
    }
}
