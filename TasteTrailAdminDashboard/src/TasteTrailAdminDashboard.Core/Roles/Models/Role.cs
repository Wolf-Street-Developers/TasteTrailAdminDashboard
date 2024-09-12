#pragma warning disable CS8618

using System.Text.Json.Serialization;
using TasteTrailAdminDashboard.Core.Users.Models;

namespace TasteTrailAdminDashboard.Core.Roles.Models;

public class Role
{
    public string Id { get; set; }
    public required string Name { get; set; }
    
    [JsonIgnore]
    public ICollection<User> Users { get; set; }
}
