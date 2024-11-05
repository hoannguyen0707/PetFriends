using System.ComponentModel.DataAnnotations;

namespace PetCategory.API.Dtos;

public record class CreatePetDto(
    [Required][StringLength(50)] string Name,
    [StringLength(250)] string Description
);
