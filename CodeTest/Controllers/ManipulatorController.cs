using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeTest.Controllers
{
    [ApiController]
    [Route("api/manipulator")]
    public class ManipulatorController : ControllerBase
    {       
        private readonly ILogger<ManipulatorController> _logger;

        public ManipulatorController(ILogger<ManipulatorController> logger)
        {
            _logger = logger;
        }

        //https://localhost:44332/api/Manipulator/reversemessage/hello
        [HttpGet]
        [Route("ReverseMessage/{stringToReverse}")]
        public ActionResult<string> ReverseMessage(string stringToReverse)
        {
            if (string.IsNullOrEmpty(stringToReverse))
            {
                return BadRequest($"No string to reverse specified: {stringToReverse}");
            }
            
            if (stringToReverse.Length > 1024)
            {
                return BadRequest(
                    $"Processing of strings > 1024 characters is not recommended. Use the HttpPost call. Provided string length: {stringToReverse.Length}");                
            }

            return Ok(stringToReverse.ReverseString());
        }

        [HttpPost]
        [Route("ReverseMessage")]
        public ActionResult<ManipulatorModel> ReverseMessageBody(ManipulatorModel message)
        {
            var stringToReverse = message.Message;

            if (string.IsNullOrEmpty(stringToReverse))
            {
                return BadRequest($"No string to reverse specified: {stringToReverse}");
            }

            return Ok(new ManipulatorModel() { Message = stringToReverse.ReverseString() });
        }
    }
}