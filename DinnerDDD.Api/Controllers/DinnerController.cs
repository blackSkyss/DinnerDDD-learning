using Microsoft.AspNetCore.Mvc;

namespace DinnerDDD.Api.Controllers
{
    [Route("dinner")]
    public class DinnerController : ApiController
    {
        public DinnerController() { }

        [HttpGet]
        public IActionResult ListDinner()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
