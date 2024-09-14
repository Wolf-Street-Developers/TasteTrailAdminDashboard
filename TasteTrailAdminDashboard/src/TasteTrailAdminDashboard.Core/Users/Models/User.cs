#pragma warning disable CS8618

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TasteTrailData.Core.Common.Models.Base;

namespace TasteTrailAdminDashboard.Core.Users.Models;
public class User : IBanable, IMuteable
{
    [Key]
    public string Id { get; set; }
    public string RoleId { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    
    [DefaultValue(false)]
    public bool IsBanned { get; set; }

    [DefaultValue(false)]
    public bool IsMuted { get; set; }
}
