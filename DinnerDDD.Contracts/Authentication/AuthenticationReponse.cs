namespace DinnerDDD.Contracts.Authentication
{
    public record AuthenticationReponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token
        );
}
