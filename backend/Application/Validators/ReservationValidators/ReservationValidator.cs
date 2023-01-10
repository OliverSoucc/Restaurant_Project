using Application.DTOs;
using FluentValidation;

namespace Application.Validators.ReservationValidators;

public class ReservationValidator: AbstractValidator<ReservationDTO>
{
    public ReservationValidator()
    {
        RuleFor(r => r.ReservationTableId).NotNull();
        RuleFor(r => r.Date).NotEmpty().NotNull();
        RuleFor(r => r.LastName).NotEmpty().NotNull();
    }
}