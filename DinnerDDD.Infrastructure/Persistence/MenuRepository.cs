using DinnerDDD.Application.Common.Interfaces.Persistence;
using DinnerDDD.Domain.Menu;

namespace DinnerDDD.Infrastructure.Persistence
{
    public class MenuRepository : IMenuRepository
    {
        private static readonly List<Menu> _menus = new();
        public void Add(Menu menu)
        {
           _menus.Add(menu);
        }
    }
}
