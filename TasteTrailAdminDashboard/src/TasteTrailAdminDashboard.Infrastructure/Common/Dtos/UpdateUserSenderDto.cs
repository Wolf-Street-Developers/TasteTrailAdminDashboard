namespace TasteTrailAdminDashboard.Infrastructure.Common.Dtos;

public class UpdateUserSenderDto
{
    public required string Id { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }

}
