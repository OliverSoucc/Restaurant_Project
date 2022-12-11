namespace Application.DTOs.ReservationTable;

public class PutReservationTableDto
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int NumberOfSeats { get; set; }
    public string Location { get; set; } = string.Empty;
}