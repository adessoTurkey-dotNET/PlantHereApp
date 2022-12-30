using PlantHere.Application.Interfaces.Service;

namespace PlantHere.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class EmailController : CustomBaseController
    {

        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendEmail()
        {
            return CreateActionResult(await _emailService.Send("testsendemailforapi@gmail.com", "test"));
        }


    }
}
