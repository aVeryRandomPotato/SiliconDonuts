using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SiliconDonuts.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename = ./donuts.sqlite");
        }

        public DbSet<Donut> Donuts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

<<<<<<< HEAD
            modelBuilder.Entity<Category>().HasData(new Category {CategoryId = 1, Name = "Glazed"});

            modelBuilder.Entity<Donut>().HasData(new Donut {
                DonutId = 1,
                Name = "Plain Glazed Donut",
                DonutPrice = 2,
                ShortDescription = "Our Classic Donut covered with Plain Glaze",
                ImageUrl = "https://i.ibb.co/rMrcKxy/glazed-donut.png",
                Allergies = "Egg, Milk, Gluten",
=======
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, Name = "Glazed" });

            modelBuilder.Entity<Donut>().HasData(new Donut
            {
                DonutId = 3,
                Name = "Plain Glazed Donut",
                DonutPrice = 0.99m,
                ShortDescription = "Our Classic Donut covered with Plain Glaze",
                ImageUrl = "https://i.ibb.co/rMrcKxy/glazed-donut.png",
                Allergens = "Egg, Milk, Gluten",
>>>>>>> 7afe0fc (Carousel and Bootstrap Front End added)
                IsAvailable = true,
            });

            modelBuilder.Entity<Donut>().HasData(new Donut
            {
<<<<<<< HEAD
                DonutId = 2,
                Name = "Chocolate Glazed Donut",
                DonutPrice = 2,
                ShortDescription = "Our Classic Donut covered with Chocolate Glaze",
                ImageUrl = "https://i.ibb.co/9G2yGws/chocolate-donut.jpg",
                Allergies = "Egg, Milk, Gluten",
=======
                DonutId = 4,
                Name = "Chocolate Glazed Donut",
                DonutPrice = 0.99m,
                ShortDescription = "Our Classic Donut covered with Chocolate Glaze",
                ImageUrl = "https://i.ibb.co/9G2yGws/chocolate-donut.jpg",
                Allergens = "Egg, Milk, Gluten",
>>>>>>> 7afe0fc (Carousel and Bootstrap Front End added)
                IsAvailable = true,
            });
        }
    }
}