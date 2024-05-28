using DinnerDDD.Application.Authentication.Commands.Register;
using DinnerDDD.Application.Authentication.Common;
using DinnerDDD.Application.Authentication.Queries.Login;
using DinnerDDD.Contracts.Authentication;
using Mapster;
using Microsoft.AspNetCore.Identity.Data;

namespace DinnerDDD.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationReponse>()
                 .Map(dest => dest, src => src.User);
        }
    }
}
