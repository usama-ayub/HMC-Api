using System.Net;
using System.Threading.Tasks;
using API.Shared;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected BaseResponseResult<T> BaseResponse<T>(T data, HttpStatusCode status = HttpStatusCode.OK,string message = "", bool success = true, bool error = false)
        {
            return new BaseResponseResult<T>(data, status,message, success, error);
        }
    }

   public class BaseResponseResult<T> : IActionResult
    {
        private readonly BaseResponses<T> baseResponse;
        public BaseResponseResult(T data, HttpStatusCode status,string message, bool success, bool error)
        {
            baseResponse = new BaseResponses<T>(data,status, message, success, error);
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(baseResponse)
            {
                StatusCode = (int)baseResponse.Status
            };
            await objectResult.ExecuteResultAsync(context);
        }
    }
}