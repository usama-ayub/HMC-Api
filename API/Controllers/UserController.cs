using System.Collections.Generic;
using System.Threading.Tasks;
using API.Model;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
       [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
          private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
         public async  Task<ActionResult<User>> GetUsers()
        {
            return  await _userService.Get();
        }
    }
}