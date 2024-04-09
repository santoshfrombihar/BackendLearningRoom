using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLearningRoomBackend.Dto;
using MyLearningRoomBackend.Repository;
using MyLearningRoomBackend.Services.Interfaces;

namespace MyLearningRoomBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly MyAuthorizationServerProvider _serverProvider;

        public UserController(ILogger<UserController> logger, IUserService userService, MyAuthorizationServerProvider serverProvider)
        {
            _logger = logger;
            _userService = userService;
            _serverProvider = serverProvider;
        }

        [Authorize]
        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(UserDto user)
        {
            var myUser  = await _userService.SaveData(user);
            if (myUser != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var user = await _userService.ValidateUser(login);
            if (user != null)
            {
                var token = _serverProvider.GenerateToken(user);
                return Ok(new { token = token});
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
