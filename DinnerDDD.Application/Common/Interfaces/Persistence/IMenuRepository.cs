using DinnerDDD.Domain.MenuAggregate;

namespace DinnerDDD.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}