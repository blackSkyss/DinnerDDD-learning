using DinnerDDD.Domain.Common.Models;

namespace DinnerDDD.Domain.Common.ValueObjects;

public class Rating : ValueObject
{
    public int Value { get; set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}