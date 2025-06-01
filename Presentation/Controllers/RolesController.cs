using Business.Intefaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extentions.Attributes;

namespace Presentation.Controllers;

/// <summary>
/// API-kontroller för att hämta användarroller.
/// </summary>
[ApiKey]
[Route("api/[controller]")]
[ApiController]
public class RolesController(IAccountUserService accountUserService) : ControllerBase
{
    private readonly IAccountUserService _accountUserService = accountUserService;

    /// <summary>
    /// Hämtar alla roller som är kopplade till en specifik användare.
    /// </summary>
    /// <param name="id">Användarens unika ID.</param>
    /// <returns>
    /// HTTP 200 OK med rollista om användaren finns, annars 404 Not Found.
    /// </returns>
    [HttpGet("getroles")]
    [ProducesResponseType(typeof(RoleResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RoleResponse<string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetRoles(string id)
    {
        var result = await _accountUserService.GetRoleAsync(id);
        return StatusCode(result.StatusCode, result);
    }
}
