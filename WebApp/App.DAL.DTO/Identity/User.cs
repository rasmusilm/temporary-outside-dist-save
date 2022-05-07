using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace App.DAL.DTO.Identity;

public class User : IdentityUser<Guid>
{
    public string? Name { get; set; } = "default";
}