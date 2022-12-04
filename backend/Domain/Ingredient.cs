namespace Domain;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
    public List<Dish> Dishes { get; set; }
}