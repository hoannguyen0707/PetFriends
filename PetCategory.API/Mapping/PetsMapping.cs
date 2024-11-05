using System;
using PetCategory.API.Dtos;
using PetCategory.API.Entities;

namespace PetCategory.API.Mapping;

public static class PetsMapping
{
    public static PetsDto ToDto(this Entities.PetCategories pet)
    {
        return new(
            pet.Id,
            pet.Name,
            pet.Description
        );
    }

    public static Entities.PetCategories ToEntity(this CreatePetDto pet)
    {
        return new Entities.PetCategories()
        {
            Name = pet.Name,
            Description = pet.Description
        };
    }

    public static Entities.PetCategories ToEntity(this UpdatePetDto pet, int id)
    {
        return new Entities.PetCategories()
        {
            Id = id,
            Name = pet.Name,
            Description = pet.Description
        };
    }
}
