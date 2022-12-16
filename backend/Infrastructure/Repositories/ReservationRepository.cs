using Application.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

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
        return _context.Reservations.Include(r => r.ReservationTable).ToList();
    }

    public Reservation GetReservation(int id)
    {
        var result = _context.Reservations
            .Include(r => r.ReservationTable)
            .FirstOrDefault();
        if (result == null) throw new ArgumentException("Reservation with provided Id was not found");
        return result;
    }

    public Reservation CreateReservation(Reservation reservation)
    {
        var reservationTable = _context.ReservationTables.Find(reservation.ReservationTableId);
        if (reservationTable == null) throw new ArgumentException("No reservation table with the id was found");

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