using Business.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extentions.Attributes;
namespace Presentation.Controllers;

/// <summary>
/// API-kontroller för att kontrollera om en användare existerar.
/// </summary>
[ApiKey]
[Route("api/[controller]")]
[ApiController]
public class UserExistController(IAccountUserService accountUserService) : ControllerBase
{
    private readonly IAccountUserService _accountUserService = accountUserService;

    /// <summary>
    /// Kontrollerar om en användare finns i systemet.
    /// </summary>
    /// <param name="id">Användarens ID som query-parameter.</param>
    /// <returns>
    /// HTTP 200 OK om användaren finns, annars 400 Bad Request.
    /// </returns>
    [HttpPost("userexist")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UserExist([FromQuery] string id)
    {
        var result = await _accountUserService.ExistAsync(id);

        return StatusCode(result.StatusCode, result.Success);
    }
}
