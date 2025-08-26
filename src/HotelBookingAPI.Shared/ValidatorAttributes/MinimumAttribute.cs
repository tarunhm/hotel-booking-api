using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Shared.ValidatorAttributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class MinValueAttribute : ValidationAttribute
{
    private readonly int _minValue;

    public MinValueAttribute(int minValue)
    {
        _minValue = minValue;
    }

    public override bool IsValid(object? value)
    {
        return value != null && (int)value >= _minValue;
    }
}