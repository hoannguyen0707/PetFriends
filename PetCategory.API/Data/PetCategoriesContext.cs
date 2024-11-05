using System;
using Microsoft.EntityFrameworkCore;
using PetCategory.API.Entities;

namespace PetCategory.API.Data;

public class PetCategoriesContext(DbContextOptions<PetCategoriesContext> options) : DbContext(options)
{
    public DbSet<Entities.PetCategories> Pets => Set<PetCategories>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PetCategories>().HasData(
            new { Id = 1, Name = "Dog", Description = "Loyal and friendly companion" },
            new { Id = 2, Name = "Cat", Description = "Independent and playful" },
            new { Id = 3, Name = "Bird", Description = "Colorful and sings beautifully" },
            new { Id = 4, Name = "Fish", Description = "Quiet, easy-care pet" },
            new { Id = 5, Name = "Rabbit", Description = "Gentle and soft-furred" }
        );
    }
}
