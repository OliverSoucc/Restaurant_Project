namespace Application.DTOs;

public class ReservationDTO
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Date { get; set; }
    public int ReservationTableId { get; set; }
}