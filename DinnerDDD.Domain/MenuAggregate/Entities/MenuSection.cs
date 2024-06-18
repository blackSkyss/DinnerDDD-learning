using DinnerDDD.Domain.Common.Models;
using DinnerDDD.Domain.Menu.ValueObjects;

namespace DinnerDDD.Domain.MenuAggregate.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();

        private MenuSection(
            MenuSectionId menuSectionId,
            string name,
            string description,
            List<MenuItem> items) : base(menuSectionId)
        {
            Name = name;
            Description = description;
            _items = items;
        }

        public static MenuSection Create(string name, string description, List<MenuItem> items)
        {
            return new(MenuSectionId.CreateUnique(), name, description, items);
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

#pragma warning disable CS8618
        protected MenuSection()
        {

        }
#pragma warning restore CS8618

    }
}
