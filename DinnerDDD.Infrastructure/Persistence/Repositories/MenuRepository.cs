using DinnerDDD.Application.Common.Interfaces.Persistence;
using DinnerDDD.Domain.Menu;

namespace DinnerDDD.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly DinnerDDDContext _context;

        public MenuRepository(DinnerDDDContext context)
        {
            _context = context;
        }

        public void Add(Menu menu)
        {
            _context.Add(menu);
            _context.SaveChanges();
        }
    }
}
