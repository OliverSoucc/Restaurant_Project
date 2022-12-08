using Application.Validators;
using Application.Validators.Dishes;
using Domain;

namespace Application.Interfaces.Repositories;

public interface IDishIngredientService
{
    GetDishDto AddDishIngredient(PostDishIngredientDto dto);
}