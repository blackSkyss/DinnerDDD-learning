using DinnerDDD.Domain.Common.Models;

namespace DinnerDDD.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuReviewId Create()
    {
        return new MenuReviewId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}