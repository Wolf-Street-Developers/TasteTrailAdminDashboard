using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasteTrailData.Api.Common.Extensions.Controllers;
using TasteTrailData.Core.Roles.Enums;
using TasteTrailData.Infrastructure.Filters.Dtos;
using TasteTrailUserManager.Core.Common.Admin.Services;

namespace TasteTrailUserManager.Api.Common.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class AdminPanelController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminPanelController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost("User/Count")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetUsersCountAsync([FromBody]FilterParametersDto filterParameters)
    {
        try
        {
            var usersCount = await _adminService.GetCountFilteredAsync(filterParameters);

            return Ok(new {
                usersCount
            });
        }
        catch(ArgumentException exception)
        {   
            return BadRequest(exception.Message);
        }
        catch(Exception exception)
        {
            return this.InternalServerError(exception.Message);
        }
    }

    [HttpPost("UserFilter")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetUsersAsync([FromBody]FilterParametersSearchDto dto)
    {
        try
        {
            var userResonseDto = await _adminService.GetUsersFiltereBySearchdAsync(dto);

            return Ok(userResonseDto);
        }
        catch(ArgumentException exception)
        {   
            return BadRequest(exception.Message);
        }
        catch(Exception exception)
        {
            return this.InternalServerError(exception.Message);
        }
    }

    [HttpPost("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AssignRoleAsync([FromQuery] string userId, [FromQuery] UserRoles role)
    {
        try
        {
            await _adminService.AssignRoleToUserAsync(userId, role);
            return Ok();
        }
        catch(ArgumentException exception)
        {   
            return BadRequest(exception.Message);
        }
        catch(Exception exception)
        {
            return this.InternalServerError(exception.Message);
        }
    }

    [HttpPost("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveRoleAsync([FromQuery] string userId, [FromQuery] UserRoles role)
    {
        try
        {
            await _adminService.RemoveRoleFromUserAsync(userId: userId, role);
            return Ok();
        }
        catch(ArgumentException exception)
        {   
            return BadRequest(exception.Message);
        }
        catch(Exception exception)
        {
            return this.InternalServerError(exception.Message);
        }
    }

    [HttpPost("[action]/{userId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ToggleMuteAsync(string userId)
    {
        try
        {
            await _adminService.ToggleMuteUserAsync(userId);
            return Ok();
        }
        catch(ArgumentException exception)
        {   
            return BadRequest(exception.Message);
        }
        catch(Exception exception)
        {
            return this.InternalServerError(exception.Message);
        }
    }

    [HttpPost("[action]/{userId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ToggleBanAsync(string userId)
    {
        try
        {
            await _adminService.ToggleBanUserAsync(userId);
            return Ok();
        }
        catch(ArgumentException exception)
        {   
            return BadRequest(exception.Message);
        }
        catch(Exception exception)
        {
            return this.InternalServerError(exception.Message);
        }
    }

    [HttpGet("UserInfo/{userId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetUserInfoAsync(string userId)
    {
        try
        {
            var user = await _adminService.GetUserByIdAsync(userId);
            return Ok(user);
        }
        catch(ArgumentException exception)
        {   
            return BadRequest(exception.Message);
        }
        catch(Exception exception)
        {
            return this.InternalServerError(exception.Message);
        }
    }

  
}


