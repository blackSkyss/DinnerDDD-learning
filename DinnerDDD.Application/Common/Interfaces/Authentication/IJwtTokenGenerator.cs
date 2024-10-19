using DinnerDDD.Domain.UserAggregate;

namespace DinnerDDD.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}