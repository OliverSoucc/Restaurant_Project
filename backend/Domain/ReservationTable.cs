namespace Domain;

public class ReservationTable
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int NumberOfSeats { get; set; }
    public string Location { get; set; } = string.Empty;
    public Reservation Reservation { get; set; }
    public int ReservationId { get; set; }
}