using System.ComponentModel.DataAnnotations;

namespace PetCategory.API.Dtos;

public record class UpdatePetDto
(
    [Required][StringLength(50)] string Name,
    [StringLength(250)] string Description
);
