using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class IngredientsRepository: IIngredientRepository
{
    private readonly RestaurantDbContext _context;
    
    public IngredientsRepository(RestaurantDbContext context)
    {
        _context = context;
    }
    public Ingredient CreateNewIngredient(Ingredient ingredient)
    {   
        _context.Ingredients.Add(ingredient);
        _context.SaveChanges();
        
        return ingredient;
    }

    public List<Ingredient> GetAllIngredients()
    {
        return _context.Ingredients.ToList();
    }

    public Ingredient GetIngredient(int id)
    {
        var result = _context.Ingredients.Find(id);
        if (result == null) throw new ArgumentException("Ingredient with provided Id does not exist");
        return result;
    }

    public Ingredient DeleteIngredient(int id)
    {
        throw new NotImplementedException();
    }

    public Ingredient UpdateIngredient(Ingredient ingredient)
    {
        throw new NotImplementedException();
    }
}