using DinnerDDD.Domain.Common.Models;

namespace DinnerDDD.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObject
{
    private MenuId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}