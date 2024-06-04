using DinnerDDD.Domain.Host.ValueObjects;
using DinnerDDD.Domain.Menu;
using DinnerDDD.Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace DinnerDDD.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        public Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = Menu.Create(
                hostId: HostId.CreateUnique(),
                name: request.Name,
                description: request.Description,
                sections: request.Sections.ConvertAll(sections => MenuSection.Create(
                    sections.Name,
                    sections.Description,
                    sections.Items.ConvertAll(item => MenuItem.Create(
                        item.Name,
                        item.Description)))));


            return default!;
        }
    }
}
