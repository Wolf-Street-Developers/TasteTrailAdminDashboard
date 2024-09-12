using TasteTrailAdminDashboard.Core.Users.Models;

namespace TasteTrailAdminDashboard.Core.Users.Dtos;

public class UserResponseDto
{
    public required User User { get; set; }
    public required string Role { get; set; }
}