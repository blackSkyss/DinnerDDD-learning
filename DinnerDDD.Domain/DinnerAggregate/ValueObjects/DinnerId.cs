using DinnerDDD.Domain.Common.Models;

namespace DinnerDDD.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerId : ValueObject
{
    private DinnerId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static DinnerId Create()
    {
        return new DinnerId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}