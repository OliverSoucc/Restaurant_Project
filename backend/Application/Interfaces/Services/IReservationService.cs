using Application.DTOs;
using Application.DTOs.Reservation;
using Domain;

namespace Application.Interfaces.Services;

public interface IReservationService
{
    public ICollection<Reservation> GetReservations();
    public Reservation GetReservation(int id);
    public Reservation CreateReservation(ReservationDTO reservationDto);
    public Reservation UpdateReservation(PutReservationDto reservationDto);
    public Reservation DeleteReservation(int id);

}