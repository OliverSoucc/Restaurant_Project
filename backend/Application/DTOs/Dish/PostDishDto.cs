namespace Application.DTOs.Dish;

public class PostDishDto
{
    public string Name { get; set; } = string.Empty;
    public int Price  { get; set; }
    public string Description { get; set; } = string.Empty;
    public string WeekDay { get; set; } = string.Empty;
}