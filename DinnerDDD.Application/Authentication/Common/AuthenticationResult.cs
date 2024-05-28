using DinnerDDD.Domain.Entities;

namespace DinnerDDD.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token
        );

}
