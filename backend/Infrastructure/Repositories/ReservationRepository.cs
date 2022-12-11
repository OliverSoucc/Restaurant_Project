using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class ReservationRepository: IReservationRepository
{
    private readonly RestaurantDbContext _context;

    public ReservationRepository(RestaurantDbContext context)
    {
        _context = context;
    }
    
    public List<Reservation> GetReservations()
    {
        return _context.Reservations.ToList();
    }

    public Reservation GetReservation(int id)
    {
        var result = _context.Reservations.Find(id);
        if (result == null) throw new ArgumentException("Reservation with provided Id was not found");
        return result;
    }

    public Reservation CreateReservation(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        _context.SaveChanges();
        return reservation;
    }

    public Reservation DeleteReservation(int id)
    {
        var reservation = _context.Reservations.Find(id);
        if (reservation == null) throw new ArgumentException("Reservation with provided Id was not found");
        _context.Reservations.Remove(reservation);
        _context.SaveChanges();
        return reservation;
    }

    public Reservation UpdateReservation(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
        _context.SaveChanges();
        
        return reservation;
    }
}