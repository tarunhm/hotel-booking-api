using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Shared.ValidatorAttributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class FutureDateAttribute : ValidationAttribute
{
    private readonly DateOnly _minDate = DateOnly.FromDateTime(DateTime.Now);

    public FutureDateAttribute() { }

    public override bool IsValid(object? value)
    {
        return value != null && ((DateOnly)value).CompareTo(_minDate) >= 0;
    }
}