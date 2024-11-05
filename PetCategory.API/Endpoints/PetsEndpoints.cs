using System;
using PetCategory.API.Data;
using PetCategory.API.Dtos;
using PetCategory.API.Mapping;
using Microsoft.EntityFrameworkCore;
using PetCategory.API.Entities;

namespace PetCategory.API.Endpoints;

public static class PetsEndpoints
{
    const string GetPetEndPointName = "GetPet";

    public static RouteGroupBuilder MapPetsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("pets").WithParameterValidation();

        //GET /pets
        group.MapGet("/", async (PetCategoriesContext dbContext) =>
               await dbContext.Pets
                    .Select(pet => pet.ToDto())
                    .AsNoTracking()
                    .ToListAsync());

        //GET /pets/1
        group.MapGet("/{id}", async (int id, PetCategoriesContext dbContext) =>
        {
            Entities.PetCategories? pet = await dbContext.Pets.FindAsync(id);
            return pet is null ?
                    Results.NotFound() : Results.Ok(pet.ToDto());
        }).WithName(GetPetEndPointName);

        //POST /pets
        group.MapPost("/", async (CreatePetDto newPet, PetCategoriesContext dbContext) =>
        {
            Entities.PetCategories pet = newPet.ToEntity();
            dbContext.Pets.Add(pet);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetPetEndPointName, new { id = pet.Id }, pet.ToDto());

        }).WithParameterValidation();


        //PUT /pets/1
        group.MapPut("/{id}", async (int id, UpdatePetDto updPet, PetCategoriesContext dbContext) =>
        {
            var existingPet = await dbContext.Pets.FindAsync(id);
            if (existingPet is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingPet).CurrentValues.SetValues(updPet.ToEntity(id));
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });

        //DELETE /pets/3
        group.MapDelete("/{id}", async (int id, PetCategoriesContext dbContext) =>
        {
            await dbContext.Pets
            .Where(pet => pet.Id == id)
            .ExecuteDeleteAsync();
            return Results.NoContent();
        });

        return group;
    }

}
