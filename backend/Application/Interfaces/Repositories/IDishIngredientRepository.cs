using Application.DTOs;
using Application.DTOs.Dishes;
using Domain;

namespace Application.Interfaces.Repositories;

public interface IDishIngredientRepository
{
    GetDishDto AddDishIngredient(DishIngredient dishIngredient);
}