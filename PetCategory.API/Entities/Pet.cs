using System;

namespace PetCategory.API.Entities;

public class PetCategories
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

}
