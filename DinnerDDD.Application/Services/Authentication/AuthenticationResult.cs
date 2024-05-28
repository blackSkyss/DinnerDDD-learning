using DinnerDDD.Domain.Entities;

namespace DinnerDDD.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token
        );
}
