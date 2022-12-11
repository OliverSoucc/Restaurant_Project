using Domain;

namespace Application.Interfaces.Repositories;

public interface IReservationRepository
{
    public List<Reservation> GetReservations();
    public Reservation GetReservation(int id);
    public Reservation CreateReservation(Reservation reservation);
    public Reservation DeleteReservation(int id);
    public Reservation UpdateReservation(Reservation reservation);
}