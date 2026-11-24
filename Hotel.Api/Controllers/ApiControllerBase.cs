using Hotel.Utilitario;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IActionResult ToActionResult<T>(Result<T> result)
        {
            if (result.Success)
            {
                return result.StatusCode == 201
                    ? StatusCode(201, result)
                    : Ok(result);
            }

            return result.StatusCode switch
            {
                404 => NotFound(result),
                409 => Conflict(result),
                500 => StatusCode(500, result),
                _ => BadRequest(result)
            };
        }
    }
}
