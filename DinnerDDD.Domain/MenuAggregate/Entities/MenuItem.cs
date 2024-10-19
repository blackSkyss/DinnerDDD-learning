using DinnerDDD.Domain.Common.Models;
using DinnerDDD.Domain.MenuAggregate.ValueObjects;

namespace DinnerDDD.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    private MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

#pragma warning disable CS8618
    protected MenuItem()
    {
    }
#pragma warning restore CS8618

    public string Name { get; private set; }
    public string Description { get; private set; }

    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }
}