using Application.Interfaces.Services;
using Application.DTOs;
using Application.DTOs.Reservation;
using AutoMapper;
using Domain;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Application;

public class ReservationService: IReservationService
{
    private readonly IReservationRepository _repository;
    private readonly IMapper _mapper;
    public ReservationService(IReservationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public ICollection<Reservation> GetReservations()
    {
        return _repository.GetReservations();
    }

    public Reservation GetReservation(int id)
    {
        return _repository.GetReservation(id);
    }

    public Reservation CreateReservation(ReservationDTO reservationDto)
    {
        return _repository.CreateReservation(_mapper.Map<Reservation>(reservationDto));
    }

    public Reservation UpdateReservation(PutReservationDto reservationDto)
    {
        return _repository.UpdateReservation(_mapper.Map<Reservation>(reservationDto));
    }

    public Reservation DeleteReservation(int id)
    {
        return _repository.DeleteReservation(id);
    }
}