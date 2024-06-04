using DinnerDDD.Application.Common.Interfaces.Persistence;
using DinnerDDD.Domain.Host.ValueObjects;
using DinnerDDD.Domain.Menu;
using DinnerDDD.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace DinnerDDD.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var menu = Menu.Create(
                hostId: HostId.Create(),
                name: request.Name,
                description: request.Description,
                sections: request.Sections.ConvertAll(sections => MenuSection.Create(
                    sections.Name,
                    sections.Description,
                    sections.Items.ConvertAll(item => MenuItem.Create(
                        item.Name,
                        item.Description)))));

            _menuRepository.Add(menu);

            return menu;
        }
    }
}
