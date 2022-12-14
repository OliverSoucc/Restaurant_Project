namespace Application.DTOs.Ingredient;

public class GetIngredientDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Amount { get; set; }
}