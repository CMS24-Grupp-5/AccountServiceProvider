using Business.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController(IAccountUserService accountUserService) : ControllerBase
{
    private readonly IAccountUserService _accountUserService = accountUserService;

    [HttpGet("getroles")]
    public async Task<IActionResult> GetRoles(string id)
    {
        var result = await _accountUserService.GetRoleAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return BadRequest("User not found");


    }


}
