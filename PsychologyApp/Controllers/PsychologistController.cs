using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PsychologyApp.WebApi.Requests;
using PsychologyApp.WebApi.Services;

namespace PsychologyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/psychologist")]
    public class PsychologistController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPsychologistService _psychologistService;

        public PsychologistController(ILogger logger, IPsychologistService psychologistService)
        {
            _logger = logger;
            _psychologistService = psychologistService;
        }

        [HttpGet("login/{request}")]
        public IActionResult LogIn(UserAuthorizationRequest request)
        {            
            return Ok();
        }

    }
}
