using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFC
{
    internal static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>().HasData(
                 new Drink { Name = "Beer", Price = 3.50m },
                 new Drink { Name = "Pepsi", Price = 1.45m },
                 new Drink { Name = "Iced Tea", Price = 1.75m },
                 new Drink { Name = "Whiskey", Price = 15.00m },
                 new Drink { Name = "Lemonade", Price = 1.80m },
                 new Drink { Name = "Red Wine", Price = 10.00m },
                 new Drink { Name = "Coca-Cola", Price = 1.50m },
                 new Drink { Name = "Apple Juice", Price = 2.00m },
                 new Drink { Name = "Orange Juice", Price = 2.00m },
                 new Drink { Name = "Sparkling Water", Price = 1.00m }
            );

            modelBuilder.Entity<Food>().HasData(
                new Food { Name = "Cheeseburger", Price = 6.99m },
                new Food { Name = "Caesar Salad", Price = 5.99m },
                new Food { Name = "Veggie Wrap", Price = 4.99m },
                new Food { Name = "French Fries", Price = 2.99m },
                new Food { Name = "Chicken Wings", Price = 7.99m },
                new Food { Name = "Falafel Plate", Price = 6.50m },
                new Food { Name = "Pasta Alfredo", Price = 8.50m },
                new Food { Name = "Grilled Salmon", Price = 12.99m },
                new Food { Name = "Margherita Pizza", Price = 8.99m },
                new Food { Name = "Spaghetti Bolognese", Price = 9.50m }
            );

        }
    }
}
