namespace Application.DTOs.Reservation;
using Domain;

public class GetReservationDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public DateTime Date { get; set; }
    public ReservationTableDTO ReservationTable { get; set; }
}