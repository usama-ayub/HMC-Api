
using System.Net;
using System.Threading.Tasks;
using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.Get();
            if (result.status){
                return BaseResponse(result.user, HttpStatusCode.OK,"Found");
            }
            return BaseResponse("", HttpStatusCode.NotFound,"Not Found", false, true);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto payload)
        {
            var result = await _userService.Register(payload);
            if (result.status)
            {
                return BaseResponse(result.register, HttpStatusCode.OK,"Register Sucessfully", false, true);
            }
            return BaseResponse("", HttpStatusCode.NotFound, "User Already Exist");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto payload)
        {
            var result = await _userService.Login(payload);
            if (result.status)
            {
                return BaseResponse(result.login, HttpStatusCode.OK, result.message);
            }
            return BaseResponse("", HttpStatusCode.NotFound, result.message, false, true);
        }

    }
}