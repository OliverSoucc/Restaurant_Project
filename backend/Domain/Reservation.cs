namespace Domain;

public class Reservation
{
    public int Id { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Date { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public ReservationTable ReservationTable { get; set; }
    public int ReservationTableId { get; set; }
}