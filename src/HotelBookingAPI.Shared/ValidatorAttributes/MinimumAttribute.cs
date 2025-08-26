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

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        if (value == null) { return new ValidationResult("Value cannot be null"); }

        if ((int)value >= _minValue) { return ValidationResult.Success!; }

        return new ValidationResult($"Value must be greater than or equal to {_minValue}.");
    }
}