using Application.DTOs;
using Application.DTOs.Reservation;
using Domain;

namespace Application.Interfaces.Services;

public interface IReservationService
{
    public ICollection<GetReservationDto> GetReservations();
    public GetReservationDto GetReservation(int id);
    public GetReservationDto CreateReservation(ReservationDTO reservationDto);
    public GetReservationDto UpdateReservation(PutReservationDto reservationDto);
    public GetReservationDto DeleteReservation(int id);

}