using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace RecipeBook.Web.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Recipe> Recipes => Set<Recipe>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // ✅ Important for Identity

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(r => r.Title).IsRequired().HasMaxLength(120);
                entity.Property(r => r.Category).HasMaxLength(60);
                entity.Property(r => r.ImagePath).HasMaxLength(255);
                entity.Property(r => r.Ingredients).IsRequired();
                entity.Property(r => r.Steps).IsRequired();

                entity.Property(r => r.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(r => r.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }

        // ✅ Custom seeding method that runs only if DB is empty
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Recipes.Any())
                return; // Already seeded

            var recipes = new[]
            {
                new Recipe
                {
                    Title = "Ghanaian Jollof Rice",
                    Category = "Main Dish",
                    Ingredients = "2 cups rice\n1 can tomato paste\n2 cups chicken stock\n1 onion\n2 tomatoes\n1 tsp salt\n1 tsp pepper\n1 tsp curry powder\n2 tbsp oil",
                    Steps = "1. Blend tomatoes and onion.\n2. Heat oil and fry tomato paste for 5 minutes.\n3. Add blended mix, seasoning, and stock.\n4. Add rice and simmer until cooked.",
                    ImagePath = "/images/recipes/jollof.jpg",
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    UpdatedAt = DateTime.UtcNow.AddDays(-8)
                },
                new Recipe
                {
                    Title = "Fried Plantain with Beans (Red Red)",
                    Category = "Traditional",
                    Ingredients = "3 ripe plantains\n2 cups black-eyed beans\n1 onion\n1 cup palm oil\nSalt to taste\nPepper to taste",
                    Steps = "1. Boil beans until soft.\n2. Prepare palm oil sauce with onions and pepper.\n3. Mix beans with sauce.\n4. Fry sliced plantains until golden brown.",
                    ImagePath = "/images/recipes/redred.jpg",
                    CreatedAt = DateTime.UtcNow.AddDays(-7),
                    UpdatedAt = DateTime.UtcNow.AddDays(-5)
                },
                new Recipe
                {
                    Title = "Chicken Light Soup",
                    Category = "Soup",
                    Ingredients = "1 whole chicken\n4 tomatoes\n1 onion\n2 scotch bonnet peppers\n1 tbsp tomato paste\nSalt and spices to taste",
                    Steps = "1. Season chicken and boil for 10 mins.\n2. Blend tomatoes, onion, and pepper.\n3. Add blend and tomato paste to chicken.\n4. Simmer until thick and chicken is tender.",
                    ImagePath = "/images/recipes/lightsoup.jpg",
                    CreatedAt = DateTime.UtcNow.AddDays(-6),
                    UpdatedAt = DateTime.UtcNow.AddDays(-4)
                },
                new Recipe
                {
                    Title = "Vegetable Stir-Fry",
                    Category = "Vegetarian",
                    Ingredients = "1 cup chopped carrots\n1 bell pepper\n1 onion\n1 cup broccoli\n2 tbsp soy sauce\n1 tbsp oil\nSalt to taste",
                    Steps = "1. Heat oil in pan.\n2. Add onion and stir for 1 min.\n3. Add vegetables and soy sauce.\n4. Stir-fry for 5 mins and serve warm.",
                    ImagePath = "/images/recipes/stirfry.jpg",
                    CreatedAt = DateTime.UtcNow.AddDays(-3),
                    UpdatedAt = DateTime.UtcNow.AddDays(-1)
                },
                new Recipe
                {
                    Title = "Chocolate Cake",
                    Category = "Dessert",
                    Ingredients = "2 cups flour\n1 cup sugar\n1/2 cup cocoa powder\n2 eggs\n1 cup milk\n1/2 cup butter\n1 tsp baking powder",
                    Steps = "1. Preheat oven to 180°C.\n2. Mix dry ingredients.\n3. Add wet ingredients and blend well.\n4. Pour into pan and bake 30–35 mins.",
                    ImagePath = "/images/recipes/chocolatecake.jpg",
                    CreatedAt = DateTime.UtcNow.AddDays(-2),
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.Recipes.AddRange(recipes);
            context.SaveChanges();
        }
    }
}
