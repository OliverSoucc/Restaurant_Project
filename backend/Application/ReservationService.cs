using Application.Interfaces.Repositories;
using Application.DTOs;
using Application.DTOs.Reservation;
using Application.Interfaces.Services;
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
    
    public ICollection<GetReservationDto> GetReservations()
    {
        return _mapper.Map<ICollection<GetReservationDto>>(_repository.GetReservations());
    }

    public GetReservationDto GetReservation(int id)
    {
        return _mapper.Map<GetReservationDto>(_repository.GetReservation(id));
    }

    public GetReservationDto CreateReservation(ReservationDTO reservationDto)
    {
        return _mapper.Map<GetReservationDto>(_repository.CreateReservation(_mapper.Map<Reservation>(reservationDto)));
    }

    public GetReservationDto UpdateReservation(PutReservationDto reservationDto)
    {
        return _mapper.Map<GetReservationDto>(_repository.UpdateReservation(_mapper.Map<Reservation>(reservationDto)));
    }

    public GetReservationDto DeleteReservation(int id)
    {
        return _mapper.Map<GetReservationDto>(_repository.DeleteReservation(id));
    }
}