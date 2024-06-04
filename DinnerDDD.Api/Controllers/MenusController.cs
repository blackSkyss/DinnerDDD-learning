using DinnerDDD.Application.Menus.Commands.CreateMenu;
using DinnerDDD.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerDDD.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public MenusController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(
            CreateMenuRequest request,
            string hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>(request);
            var createMenuResult = await _sender.Send(command);

            return Ok(request);
        }
    }
}
