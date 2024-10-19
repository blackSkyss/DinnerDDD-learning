using DinnerDDD.Domain.Common.Models;

namespace DinnerDDD.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    private HostId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    public static HostId Create(Guid value)
    {
        return new HostId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}