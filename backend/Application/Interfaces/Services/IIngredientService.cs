using Application.DTOs.Ingredient;

namespace Application.Interfaces.Services;
using Domain;

public interface IIngredientService
{
    public Ingredient CreateNewIngredient(GetIngredientDto getIngredientDto);
    public List<Ingredient> GetAllIngredients();
    public Ingredient GetIngredient(int id);
}   