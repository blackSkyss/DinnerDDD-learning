namespace DinnerDDD.Api.Controllers;

[Route("dinner")]
public class DinnerController : ApiController
{
    [HttpGet]
    public IActionResult ListDinner()
    {
        return Ok(Array.Empty<string>());
    }
}