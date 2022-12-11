namespace Application.DTOs;

public class ReservationTableDTO
{
    public int Number { get; set; }
    public int NumberOfSeats { get; set; }
    public string Location { get; set; } = string.Empty;
}