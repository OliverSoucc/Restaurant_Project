using Application.DTOs;
using Application.DTOs.Dishes;
using Domain;

namespace Application.Interfaces.Services;

public interface IDishIngredientService
{
    GetDishDto AddDishIngredient(PostDishIngredientDto dto);
}