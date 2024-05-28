using DinnerDDD.Application.Common.Errors;
using DinnerDDD.Application.Services.Authentication;
using DinnerDDD.Contracts.Authentication;
using DinnerDDD.Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace DinnerDDD.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("signup")]
        public IActionResult SignUp(SignUpRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.SignUp(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));

        }


        [HttpPost("signin")]
        public IActionResult SignIn(SignInRequest request)
        {
            var authResult = _authenticationService.SignIn(request.Email, request.Password);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredential)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }

        private static AuthenticationReponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationReponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token
                );
        }

    }
}
