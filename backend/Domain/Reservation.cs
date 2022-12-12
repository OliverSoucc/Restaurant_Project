namespace Domain;

public class Reservation
{
    public int Id { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public DateTime Date { get; set; }
    public string Email { get; set; } = String.Empty;
    public ReservationTable ReservationTable { get; set; }
    public int ReservationTableId { get; set; }
}