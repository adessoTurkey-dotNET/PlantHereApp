namespace PlantHere.WebAPI.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResult<T> response)
        {
            if (response.StatusCode == 204)// No Content
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            }
            else
            {
                return new ObjectResult(response)
                {
                    StatusCode = response.StatusCode
                };
            }
        }
    }
}
