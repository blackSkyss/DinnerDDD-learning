using DinnerDDD.Api.Common.Errors;
using DinnerDDD.Api.Common.Mapping;

namespace DinnerDDD.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMappings();
        services.AddSingleton<ProblemDetailsFactory, DinnerDDDProblemDetailsFactory>();

        return services;
    }
}