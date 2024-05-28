using ErrorOr;

namespace DinnerDDD.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        ErrorOr<AuthenticationResult> SignUp(string firstName, string lastName, string email, string password);
        ErrorOr<AuthenticationResult> SignIn(string email, string password);
    }
}
