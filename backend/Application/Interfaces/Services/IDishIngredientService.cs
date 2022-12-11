using Application.DTOs;
using Application.DTOs.Dishes;
using Domain;

namespace Application.Interfaces.Repositories;

public interface IDishIngredientService
{
    GetDishDto AddDishIngredient(PostDishIngredientDto dto);
}