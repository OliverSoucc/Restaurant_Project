using Application.DTOs;
using Application.DTOs.ReservationTable;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain;

namespace Application;

public class ReservationTableService: IReservationTableService
{
    private readonly IMapper _mapper;
    private readonly IReservationTableRepository _repository;

    public ReservationTableService(IMapper mapper, IReservationTableRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public ICollection<ReservationTable> GetReservationTables()
    {
        return _repository.GetReservationTables();
    }

    public ReservationTable GetReservationTable(int id)
    {
        return _repository.GetReservationTable(id);
    }

    public ReservationTable CreateReservationTable(ReservationTableDTO dto)
    {
        return _repository.CreateReservationTable(_mapper.Map<ReservationTable>(dto));
    }

    public ReservationTable UpdateReservationTable(PutReservationTableDto dto)
    {
        return _repository.UpdateReservationTable(_mapper.Map<ReservationTable>(dto));
    }

    public ReservationTable DeleteReservationTable(int id)
    {
        return _repository.DeleteReservationTable(id);
    }
}