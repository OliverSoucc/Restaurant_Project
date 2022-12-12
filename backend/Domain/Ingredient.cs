namespace Domain;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Amount { get; set; }
    public ICollection<DishIngredient>? Dishes { get; set; }
}