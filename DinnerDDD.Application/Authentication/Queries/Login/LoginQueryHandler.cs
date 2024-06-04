using DinnerDDD.Application.Authentication.Common;
using DinnerDDD.Application.Authentication.Queries.Login;
using DinnerDDD.Application.Common.Interfaces.Authentication;
using DinnerDDD.Application.Common.Interfaces.Persistence;
using DinnerDDD.Domain.Common.Errors;
using DinnerDDD.Domain.User;
using ErrorOr;
using MediatR;

namespace DinnerDDD.Application.Authentication.Commands.Register
{
    public class LoginQueryHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {

        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredential;
            }

            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredential;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
