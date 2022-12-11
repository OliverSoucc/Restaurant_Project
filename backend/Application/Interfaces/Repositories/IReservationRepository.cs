using Domain;

namespace Application.Interfaces.Services;

public interface IReservationRepository
{
    public List<Reservation> GetReservations();
    public Reservation GetReservation(int id);
    public Reservation CreateReservation(Reservation reservation);
    public Reservation DeleteReservation(int id);
    public Reservation UpdateReservation(Reservation reservation);
}