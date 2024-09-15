
using TasteTrailData.Core.Roles.Enums;

namespace TasteTrailAdminDashboard.Core.Users.Dtos;

public class UpdateUserRoleDto
{
    public required string UserId { get; set; }
    public required UserRoles Role { get; set; }
}
