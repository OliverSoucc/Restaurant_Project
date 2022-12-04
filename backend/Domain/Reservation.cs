namespace Domain;

public class Reservation
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Date { get; set; }
    public string Email { get; set; }
    public ReservationTable ReservationTable { get; set; }
}