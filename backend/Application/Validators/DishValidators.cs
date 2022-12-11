using FluentValidation;

namespace Application.DTOs;

public class PostDishValidator: AbstractValidator<GetDishDto>
{
    public PostDishValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Price).GreaterThan(0);
    }
}