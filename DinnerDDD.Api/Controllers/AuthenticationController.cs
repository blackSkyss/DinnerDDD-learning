using DinnerDDD.Application.Authentication.Commands.Register;
using DinnerDDD.Application.Authentication.Queries.Login;
using DinnerDDD.Contracts.Authentication;

namespace DinnerDDD.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController(IMediator mediator, IMapper mapper) : ApiController
{
    private readonly ISender _mediator = mediator;

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(SignUpRequest request)
    {
        var command = mapper.Map<RegisterCommand>(request);
        var authResult = await _mediator.Send(command);

        return authResult.Match(
            authenticationResult => Ok(mapper.Map<AuthenticationReponse>(authenticationResult)),
            Problem);
    }


    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(SignInRequest request)
    {
        var query = mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredential)
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);

        return authResult.Match(
            authenticationResult => Ok(mapper.Map<AuthenticationReponse>(authenticationResult)),
            Problem);
    }
}