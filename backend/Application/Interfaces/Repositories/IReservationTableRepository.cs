using Domain;

namespace Application.Interfaces.Repositories;

public interface IReservationTableRepository
{
    public List<ReservationTable> GetReservationTables();
    public ReservationTable GetReservationTable(int id);
    public ReservationTable CreateReservationTable(ReservationTable reservationTable);
    public ReservationTable DeleteReservationTable(int id);
    public ReservationTable UpdateReservationTable(ReservationTable reservationTable);
}