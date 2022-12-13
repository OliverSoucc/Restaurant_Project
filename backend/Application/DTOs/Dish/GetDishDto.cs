using Application.DTOs.Ingredient;

namespace Application.DTOs;

public class GetDishDto
{
    public int Id { get; set; }
    public int Price { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string WeekDay { get; set; } = String.Empty;
    public ICollection<GetIngredientDto>? Ingredients { get; set; }
}