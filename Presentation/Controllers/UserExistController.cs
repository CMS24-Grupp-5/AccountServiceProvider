using Business.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExistController(IAccountUserService accountUserService) : ControllerBase
    {

        private readonly IAccountUserService _accountUserService = accountUserService;

        [HttpPost("userexist")]
        public async Task<IActionResult> UserExist(string id)
        {
            var result = await _accountUserService.ExistAsync(id);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
