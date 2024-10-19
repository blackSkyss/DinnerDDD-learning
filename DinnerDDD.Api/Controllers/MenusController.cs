using DinnerDDD.Application.Menus.Commands.CreateMenu;
using DinnerDDD.Contracts.Menus;

namespace DinnerDDD.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController(IMapper mapper, ISender sender) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        var command = mapper.Map<CreateMenuCommand>((request, hostId));
        var createMenuResult = await sender.Send(command);

        return createMenuResult.Match(
            menu => Ok(mapper.Map<MenuResponse>(menu)),
            Problem);
    }
}