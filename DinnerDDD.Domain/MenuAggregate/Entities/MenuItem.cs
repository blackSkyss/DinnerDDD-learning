using DinnerDDD.Domain.Common.Models;
using DinnerDDD.Domain.Menu.ValueObjects;

namespace DinnerDDD.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        private MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description)
        {
            return new(MenuItemId.CreateUnique(), name, description);
        }

        public string Name { get; }
        public string Description { get; }
    }
}
