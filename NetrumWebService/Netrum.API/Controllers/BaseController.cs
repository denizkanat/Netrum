namespace Netrum.API.Controllers
{
    using Infrastructure.Utilities.ApiResponses;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult SendResponse<T>(ApiResponse<T> response)
        {
            if (response.StatusCode == StatusCodes.Status204NoContent)
            {
                return new ObjectResult(null) { StatusCode = response.StatusCode };
            }
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
