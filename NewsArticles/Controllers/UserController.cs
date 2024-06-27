using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsArticleApplication.DTOS.UserDto.Request;
using NewsArticleApplication.Services.Abstruct;
using NewsArticlesDomain.Exeptions;
using NewsArticlesDomain.shared;

namespace NewsArticles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RequestRegistrationUserDto request)
        {
            try
            {
                var user = await _userService.RegisterUser(request);
                return Ok(user);
            }
            catch (UsernameAlreadyExistsException e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Login")]

        public async Task<IActionResult> LogIn([FromBody] RequestLogInUserDto logInInfo)
        {
            try
            {
                var user = await _userService.LogInUser(logInInfo);
                return Ok(user);
            }
            catch (InvalidLoginCredentialsException e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser(RequestUpdateUserDto request)
        {
            var user = await _userService.UpdateUser(request);
            return Ok(user);
        }
        [HttpDelete]
        public async Task DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }
        [HttpGet("[action]/{type}")]
        public async Task<IActionResult> GetUsersByType(UserTypeEnum type)
        {
            var users = await _userService.GetUsersByTypeAsync(type);
            return Ok(users);
        }

    }
}
