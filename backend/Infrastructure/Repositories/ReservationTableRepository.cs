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
        return _context.ReservationTables.Find(id);
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