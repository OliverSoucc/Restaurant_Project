using Application.Validators;
namespace Application.Interfaces.Repositories;
using Domain;

public interface IIngredientService
{
    public Ingredient CreateNewIngredient(IngredientDTO ingredientDto);
    public List<Ingredient> GetAllIngredients();
    public Ingredient GetIngredient(int id);
}   