using ErrorOr;

namespace DinnerDDD.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredential => Error.Validation(
            "Auth.InvalidCred",
            "Invalid Creatdential.");
    }
}