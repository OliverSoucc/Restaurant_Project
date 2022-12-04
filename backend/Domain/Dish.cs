namespace Domain;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price  { get; set; }
    public string Description { get; set; } = string.Empty;
    public string WeekDay { get; set; } = string.Empty;
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}