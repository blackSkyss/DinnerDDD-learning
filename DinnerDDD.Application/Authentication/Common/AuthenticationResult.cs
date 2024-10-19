using DinnerDDD.Domain.UserAggregate;

namespace DinnerDDD.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);