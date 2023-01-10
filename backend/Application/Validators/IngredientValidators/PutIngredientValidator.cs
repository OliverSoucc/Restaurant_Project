using Application.DTOs.Ingredient;
using FluentValidation;

namespace Application.DTOs.IngredientValidators;

public class PutIngredientValidator: AbstractValidator<PutIngredientDto>
{
    public PutIngredientValidator()
    {
        RuleFor(i => i.Amount).GreaterThan(0);
        RuleFor(i => i.Name).NotEmpty().NotNull();
    }
}