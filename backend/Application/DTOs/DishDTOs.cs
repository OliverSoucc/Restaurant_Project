namespace Application.Validators;

public class PostDishDTO
{
    public int Price { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime WeekDay { get; set; }
}