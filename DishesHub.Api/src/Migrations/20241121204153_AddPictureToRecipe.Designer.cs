﻿// <auto-generated />
using System;
using DishesHub.Api.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DishesHub.Api.Migrations
{
    [DbContext(typeof(DishesHubDbContext))]
    [Migration("20241121204153_AddPictureToRecipe")]
    partial class AddPictureToRecipe
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DishesHub.Api.DAL.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("DishesHub.Api.DAL.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Potato"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tomato"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Carrot"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Onion"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Garlic"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Bell Pepper"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Chicken"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Beef"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Pork"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Fish"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Cheese"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Egg"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Milk"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Flour"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Rice"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Pasta"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Bread"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Butter"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Olive Oil"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Salt"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Black Pepper"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Chili Powder"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Cumin"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Paprika"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Basil"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Oregano"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Thyme"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Parsley"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Lettuce"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Spinach"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Mushroom"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Zucchini"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Cucumber"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Broccoli"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Cauliflower"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Banana"
                        },
                        new
                        {
                            Id = 38,
                            Name = "Orange"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Strawberry"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Blueberry"
                        },
                        new
                        {
                            Id = 41,
                            Name = "Pineapple"
                        },
                        new
                        {
                            Id = 42,
                            Name = "Grapes"
                        },
                        new
                        {
                            Id = 43,
                            Name = "Watermelon"
                        },
                        new
                        {
                            Id = 44,
                            Name = "Avocado"
                        },
                        new
                        {
                            Id = 45,
                            Name = "Coconut"
                        },
                        new
                        {
                            Id = 46,
                            Name = "Almond"
                        },
                        new
                        {
                            Id = 47,
                            Name = "Walnut"
                        },
                        new
                        {
                            Id = 48,
                            Name = "Peanut"
                        },
                        new
                        {
                            Id = 49,
                            Name = "Cashew"
                        },
                        new
                        {
                            Id = 50,
                            Name = "Honey"
                        },
                        new
                        {
                            Id = 51,
                            Name = "Lemon"
                        },
                        new
                        {
                            Id = 52,
                            Name = "Ginger"
                        },
                        new
                        {
                            Id = 53,
                            Name = "Soy Sauce"
                        },
                        new
                        {
                            Id = 54,
                            Name = "Vinegar"
                        },
                        new
                        {
                            Id = 55,
                            Name = "Yogurt"
                        },
                        new
                        {
                            Id = 56,
                            Name = "Mayonnaise"
                        },
                        new
                        {
                            Id = 57,
                            Name = "Mustard"
                        },
                        new
                        {
                            Id = 58,
                            Name = "Ketchup"
                        },
                        new
                        {
                            Id = 59,
                            Name = "Sugar"
                        },
                        new
                        {
                            Id = 60,
                            Name = "Brown Sugar"
                        });
                });

            modelBuilder.Entity("DishesHub.Api.DAL.Entities.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorId")
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("DishesHub.Api.DAL.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DishId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DishId1")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("bytea");

                    b.Property<string>("VideoRefference")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("DishId1");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("IngredientRecipe", b =>
                {
                    b.Property<int>("IngredientsId")
                        .HasColumnType("integer");

                    b.Property<int>("RecipesId")
                        .HasColumnType("integer");

                    b.HasKey("IngredientsId", "RecipesId");

                    b.HasIndex("RecipesId");

                    b.ToTable("IngredientRecipe");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DishesHub.Api.DAL.Entities.Rate", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("DishesHub.Api.DAL.Entities.Recipe", "Recipe")
                        .WithMany("Rates")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("DishesHub.Api.DAL.Entities.Recipe", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DishesHub.Api.DAL.Entities.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("IngredientRecipe", b =>
                {
                    b.HasOne("DishesHub.Api.DAL.Entities.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DishesHub.Api.DAL.Entities.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DishesHub.Api.DAL.Entities.Recipe", b =>
                {
                    b.Navigation("Rates");
                });
#pragma warning restore 612, 618
        }
    }
}