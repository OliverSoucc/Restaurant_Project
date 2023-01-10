using Application.DTOs;
using FluentValidation;

namespace Application.Validators.ReservationTableValidators;

public class PostReservationTableValidator: AbstractValidator<ReservationTableDTO>
{
    public PostReservationTableValidator()
    {
        RuleFor(r => r.NumberOfSeats).GreaterThan(0);
        RuleFor(r => r.Number).GreaterThan(0);
        RuleFor(r => r.Location).NotNull().NotEmpty();
    }
}