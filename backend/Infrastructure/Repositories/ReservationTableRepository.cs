using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class ReservationTableRepository: IReservationTableRepository
{
    private readonly RestaurantDbContext _context;
    public ReservationTableRepository(RestaurantDbContext context)
    {
        _context = context;
    }

    public List<ReservationTable> GetReservationTables()
    {
        return _context.ReservationTables.ToList();
    }

    public ReservationTable GetReservationTable(int id)
    {
        var result = _context.ReservationTables.Find(id);
        if (result == null) throw new ArgumentException("Reservation table with provided Id does not exist");
        return result;
    }

    public ReservationTable CreateReservationTable(ReservationTable reservationTable)
    {
        _context.ReservationTables.Add(reservationTable);
        _context.SaveChanges();
        return reservationTable;
    }

    public ReservationTable DeleteReservationTable(int id)
    {
        var reservationTable = _context.ReservationTables.Find(id);
        if (reservationTable == null) throw new AggregateException("Reservation table with provided Id does not exist");
        _context.ReservationTables.Remove(reservationTable);
        _context.SaveChanges();
        return reservationTable;
    }

    public ReservationTable UpdateReservationTable(ReservationTable reservationTable)
    {
        _context.ReservationTables.Update(reservationTable);
        _context.SaveChanges();

        return reservationTable;
    }
}