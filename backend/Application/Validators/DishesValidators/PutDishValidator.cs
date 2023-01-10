using Application.DTOs.Dish;
using FluentValidation;

namespace Application.DTOs;

public class PutDishValidator: AbstractValidator<PutDishDto>
{
    public PutDishValidator()
    {
        RuleFor(d => d.Name).NotEmpty().NotNull();
        RuleFor(d => d.Price).GreaterThan(0);
        RuleFor(d => d.WeekDay).NotNull().NotEmpty();
    }
}