using System;
using Microsoft.EntityFrameworkCore;

namespace PetCategory.API.Data;

public static class DataExtensions
{
    public static void MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<PetCategoriesContext>();
        dbContext.Database.MigrateAsync();
    }

}
