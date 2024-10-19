using DinnerDDD.Application.Common.Interfaces.Services;

namespace DinnerDDD.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}