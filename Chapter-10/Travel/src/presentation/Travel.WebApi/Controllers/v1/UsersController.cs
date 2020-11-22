using Microsoft.AspNetCore.Mvc;
using Travel.Application.Common.Interfaces;
using Travel.Application.Dtos.User;


namespace Travel.WebApi.Controllers.v1
{
    /// <summary>
    /// No need to derive from ApiController.
    /// The controller is using a repository pattern and
    /// a hard coded user to make it simple.
    /// You decide whether to use Auth0, IdentityServer4, or the simple ASPNET.Identity.Core
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase 
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) => _userService = userService;
        
        [HttpPost("auth")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
