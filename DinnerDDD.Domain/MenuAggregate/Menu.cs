using DinnerDDD.Domain.Common.Models;
using DinnerDDD.Domain.Common.ValueObjects;
using DinnerDDD.Domain.Dinner.ValueObjects;
using DinnerDDD.Domain.Host.ValueObjects;
using DinnerDDD.Domain.Menu.ValueObjects;
using DinnerDDD.Domain.MenuAggregate.Entities;
using DinnerDDD.Domain.MenuReview.ValueObjects;

namespace DinnerDDD.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();

        private readonly List<DinnerId> _dinnerIds = new();

        private readonly List<MenuReviewId> _menuReviewIds = new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating? AverageRating { get; private set; }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public HostId HostId { get; private set; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        public Menu(MenuId menuId,
            HostId hostId,
            string name,
            string description,
            List<MenuSection> sections,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            _sections = sections;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(
            HostId hostId,
            string name,
            string description,
            List<MenuSection> sections)
        {
            return new(MenuId.CreateUnique(),
                       hostId,
                       name,
                       description,
                       sections,
                       DateTime.UtcNow,
                       DateTime.UtcNow);
        }

#pragma warning disable CS8618
        private Menu()
        {

        }
#pragma warning restore CS8618
    }
}
