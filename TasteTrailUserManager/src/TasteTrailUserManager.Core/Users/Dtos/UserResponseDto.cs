using TasteTrailUserManager.Core.Users.Models;

namespace TasteTrailUserManager.Core.Users.Dtos;

public class UserResponseDto
{
    public required User User { get; set; }
    public required ICollection<string> Roles { get; set; }
}