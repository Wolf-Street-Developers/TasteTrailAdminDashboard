using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasteTrailData.Api.Common.Extensions.Controllers;
using TasteTrailData.Core.Roles.Enums;
using TasteTrailData.Infrastructure.Filters.Dtos;
using TasteTrailAdminDashboard.Core.Common.Admin.Services;
using TasteTrailAdminDashboard.Core.Users.Dtos;

namespace TasteTrailAdminDashboard.Api.Common.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class AdminDashboardController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminDashboardController(IAdminService adminService)
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
    public async Task<IActionResult> AssignRoleAsync([FromBody]UpdateUserRoleDto updateDto)
    {
        try
        {
            await _adminService.AssignRoleToUserAsync(updateDto.UserId, updateDto.Role);
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
    public async Task<IActionResult> RemoveRoleAsync([FromBody] UpdateUserRoleDto updateDto)
    {
        try
        {
            await _adminService.RemoveRoleFromUserAsync(updateDto.UserId, updateDto.Role);
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
    public async Task<IActionResult> ToggleMuteAsync([FromQuery]string userId)
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

    [HttpPost("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ToggleBanAsync([FromQuery]string userId)
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

    [HttpGet("UserInfo")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetUserInfoAsync([FromQuery]string userId)
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


