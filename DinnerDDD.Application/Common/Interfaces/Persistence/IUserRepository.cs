using DinnerDDD.Domain.UserAggregate;

namespace DinnerDDD.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    void Add(User user);
}