using DinnerDDD.Application.Authentication.Commands.Register;
using DinnerDDD.Application.Authentication.Common;
using DinnerDDD.Application.Authentication.Queries.Login;
using DinnerDDD.Contracts.Authentication;
using DinnerDDD.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerDDD.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            var authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));

        }


        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            var authResult = await _mediator.Send(query);

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
