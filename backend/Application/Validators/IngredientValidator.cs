using Application.DTOs.Ingredient;
using FluentValidation;

namespace Application.DTOs;

public class IngredientValidator: AbstractValidator<PostIngredientDto>
{
    public IngredientValidator()
    {
        RuleFor(i => i.Amount).GreaterThan(0);
        RuleFor(i => i.Name).NotEmpty();
    }
}