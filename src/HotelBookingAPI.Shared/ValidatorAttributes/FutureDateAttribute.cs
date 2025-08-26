using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Shared.ValidatorAttributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class FutureDateAttribute : ValidationAttribute
{
    private readonly DateOnly _minDate = DateOnly.FromDateTime(DateTime.Now);

    public FutureDateAttribute() { }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) { return new ValidationResult("Value can't be null"); }

        if (((DateOnly)value).CompareTo(_minDate) >= 0) { return ValidationResult.Success!; }

        return new ValidationResult($"Date must be today's or in the future.");
    }
}