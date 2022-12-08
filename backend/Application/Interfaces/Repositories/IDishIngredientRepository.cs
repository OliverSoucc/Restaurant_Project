using Application.Validators;
using Application.Validators.Dishes;
using Domain;

namespace Application.Interfaces.Repositories;

public interface IDishIngredientRepository
{
    GetDishDto AddDishIngredient(DishIngredient dishIngredient);
}