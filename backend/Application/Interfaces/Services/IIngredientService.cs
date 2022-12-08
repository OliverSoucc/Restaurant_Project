using Application.Validators;
namespace Application.Interfaces.Repositories;
using Domain;

public interface IIngredientService
{
    public Ingredient CreateNewIngredient(GetIngredientDto getIngredientDto);
    public List<Ingredient> GetAllIngredients();
    public Ingredient GetIngredient(int id);
}   