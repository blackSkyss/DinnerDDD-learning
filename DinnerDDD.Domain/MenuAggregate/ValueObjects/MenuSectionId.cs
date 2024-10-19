using DinnerDDD.Domain.Common.Models;

namespace DinnerDDD.Domain.MenuAggregate.ValueObjects;

public class MenuSectionId : ValueObject
{
    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid value)
    {
        return new MenuSectionId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}