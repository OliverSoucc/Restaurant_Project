namespace Application.DTOs.Ingredient;

public class PutIngredientDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Amount{ get; set; } 
}