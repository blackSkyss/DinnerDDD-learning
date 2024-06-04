using DinnerDDD.Domain.User;

namespace DinnerDDD.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
       User? GetUserByEmail(string email);
      
       void Add(User user);
    }
}
