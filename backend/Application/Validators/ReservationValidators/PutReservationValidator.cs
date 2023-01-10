using Application.DTOs.Reservation;
using FluentValidation;

namespace Application.Validators.ReservationValidators;

public class PutReservationValidator: AbstractValidator<PutReservationDto>
{
    public PutReservationValidator()
    {
        RuleFor(r => r.ReservationTableId).NotNull();
        RuleFor(r => r.Date).NotEmpty().NotNull();
        RuleFor(r => r.LastName).NotEmpty().NotNull();
    }
}