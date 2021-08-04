
using System.Threading.Tasks;
using API.DTOs;
using API.Model;
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
         public async  Task<ActionResult<User>> GetUsers()
        {
            return  await _userService.Get();
        }

        [HttpPost("register")]
         public async  Task<ActionResult<ResponseRegister>> Register(RegisterDto payload)
        {
            return  await _userService.Register(payload);
        }
        [HttpPost("login")]
         public async  Task<ActionResult<ResponseLogin>> Login(LoginDto payload)
        {
            return  await _userService.Login(payload);
        }

    }
}