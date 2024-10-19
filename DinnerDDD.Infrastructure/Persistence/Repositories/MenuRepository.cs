using DinnerDDD.Application.Common.Interfaces.Persistence;
using DinnerDDD.Domain.MenuAggregate;

namespace DinnerDDD.Infrastructure.Persistence.Repositories;

public class MenuRepository(DinnerDDDContext context) : IMenuRepository
{
    public void Add(Menu menu)
    {
        context.Add(menu);
        context.SaveChanges();
    }
}