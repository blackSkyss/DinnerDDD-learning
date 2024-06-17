using DinnerDDD.Domain.Menu;
using Microsoft.EntityFrameworkCore;

namespace DinnerDDD.Infrastructure.Persistence
{
    public class DinnerDDDContext : DbContext
    {
        public DinnerDDDContext(DbContextOptions<DinnerDDDContext> options) : base(options)
        {
        }

        public DbSet<Menu> Menu { get; set; } = null!;

    }
}
