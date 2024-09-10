#pragma warning disable CS8618

using System.Text.Json.Serialization;
using TasteTrailUserManager.Core.Users.Models;

namespace TasteTrailUserManager.Core.Roles.Models;

public class Role
{
    public string Id { get; set; }
    public required string Name { get; set; }
    
    [JsonIgnore]
    public ICollection<User> Users { get; set; }
}
