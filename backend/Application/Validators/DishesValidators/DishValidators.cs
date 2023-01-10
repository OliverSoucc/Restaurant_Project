using Application.DTOs.Dish;
using FluentValidation;

namespace Application.DTOs;

public class PostDishValidator: AbstractValidator<PostDishDto>
{
    public PostDishValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(d => d.WeekDay).NotNull().NotEmpty();
    }
}