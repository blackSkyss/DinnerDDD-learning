using DinnerDDD.Application.Common.Interfaces.Persistence;
using DinnerDDD.Domain.HostAggregate.ValueObjects;
using DinnerDDD.Domain.MenuAggregate;
using DinnerDDD.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace DinnerDDD.Application.Menus.Commands.CreateMenu;

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
            HostId.CreateUnique(),
            request.Name,
            request.Description,
            request.Sections.ConvertAll(sections => MenuSection.Create(
                sections.Name,
                sections.Description,
                sections.Items.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description)))));

        _menuRepository.Add(menu);

        return menu;
    }
}