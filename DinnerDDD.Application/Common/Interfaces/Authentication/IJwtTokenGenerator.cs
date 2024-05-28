using DinnerDDD.Domain.Entities;

namespace DinnerDDD.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
