using DinnerDDD.Api.Common.Errors;
using DinnerDDD.Application;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DinnerDDD.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {

                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.AddApplication()
                                .AddInfrastructure(builder.Configuration);

                builder.Services.AddSingleton<ProblemDetailsFactory, DinnerDDDProblemDetailsFactory>();
            }

            var app = builder.Build();
            {
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseExceptionHandler("/error");
                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();
                app.Run();
            }
        }
    }
}
