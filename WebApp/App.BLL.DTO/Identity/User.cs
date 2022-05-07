using Microsoft.AspNetCore.Identity;

namespace App.BLL.DTO.Identity;

public class User
{
    public Guid Id = Guid.NewGuid();
    public string? Name { get; set; } = "";
}