using FluentValidation;

namespace Application.Validators;

public class PostDishValidator: AbstractValidator<PostDishDTO>
{
    public PostDishValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Price).GreaterThan(0);
    }
}