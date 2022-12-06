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
        return _context.Reservations.Find(id);
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