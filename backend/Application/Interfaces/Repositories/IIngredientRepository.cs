namespace Application.Interfaces.Repositories;
using Domain;

public interface IIngredientRepository
{
    public Ingredient CreateNewIngredient(Ingredient ingredient);
    public List<Ingredient> GetAllIngredients();
    public Ingredient GetIngredient(int id);
    public Ingredient DeleteIngredient(int id);
    public Ingredient UpdateIngredient(Ingredient ingredient);
}