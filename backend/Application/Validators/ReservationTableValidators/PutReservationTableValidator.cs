using Application.DTOs.ReservationTable;
using FluentValidation;

namespace Application.Validators.ReservationTableValidators;

public class PutReservationTableValidator: AbstractValidator<PutReservationTableDto>
{
    public PutReservationTableValidator()
    {
        RuleFor(r => r.NumberOfSeats).GreaterThan(0);
        RuleFor(r => r.Number).GreaterThan(0);
        RuleFor(r => r.Location).NotNull().NotEmpty();
    }
}