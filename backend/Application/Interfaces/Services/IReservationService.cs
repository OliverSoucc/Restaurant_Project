using Application.DTOs;
using Application.DTOs.Reservation;
using Domain;

namespace Application.Interfaces.Repositories;

public interface IReservationService
{
    public ICollection<Reservation> GetReservations();
    public Reservation GetReservation(int id);
    public Reservation CreateReservation(ReservationDTO reservationDto);
    public Reservation UpdateReservation(PutReservationDto reservationDto);

}