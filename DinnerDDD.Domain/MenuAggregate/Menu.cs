using DinnerDDD.Domain.Common.Models;
using DinnerDDD.Domain.Common.ValueObjects;
using DinnerDDD.Domain.Dinner.ValueObjects;
using DinnerDDD.Domain.Host.ValueObjects;
using DinnerDDD.Domain.Menu.Entities;
using DinnerDDD.Domain.Menu.ValueObjects;
using DinnerDDD.Domain.MenuReview.ValueObjects;

namespace DinnerDDD.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();

        private readonly List<DinnerId> _dinnerIds = new();

        private readonly List<MenuReviewId> _menuReviewIds = new();
        public string Name { get; }
        public string Description { get; }
        public AverageRating? AverageRating { get; }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public HostId HostId { get; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

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
    }
}
