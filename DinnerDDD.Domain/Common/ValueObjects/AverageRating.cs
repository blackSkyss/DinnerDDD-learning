using DinnerDDD.Domain.Common.Models;

namespace DinnerDDD.Domain.Common.ValueObjects;

public class AverageRating : ValueObject
{
    public AverageRating(double value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }

    public double Value { get; set; }
    public int NumRatings { get; set; }

    public static AverageRating CreateNew(double value = 0, int numRatings = 0)
    {
        return new AverageRating(value, numRatings);
    }

    public void AddNewRating(Rating rating)
    {
        Value = (Value * NumRatings + rating.Value) / ++NumRatings;
    }

    public void RemoveRating(Rating rating)
    {
        Value = (Value * NumRatings - rating.Value) / --NumRatings;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}