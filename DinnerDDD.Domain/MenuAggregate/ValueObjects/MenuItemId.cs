using DinnerDDD.Domain.Common.Models;

namespace DinnerDDD.Domain.MenuAggregate.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }


    public static MenuItemId Create(Guid value)
    {
        return new MenuItemId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}