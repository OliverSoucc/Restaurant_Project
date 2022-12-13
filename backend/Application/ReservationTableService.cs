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
    
    public ICollection<GetReservationTableDto> GetReservationTables()
    {
        return _mapper.Map<ICollection<GetReservationTableDto>>(_repository.GetReservationTables());
    }

    public GetReservationTableDto GetReservationTable(int id)
    {
        return _mapper.Map<GetReservationTableDto>(_repository.GetReservationTable(id));
    }

    public GetReservationTableDto CreateReservationTable(ReservationTableDTO dto)
    {
        return _mapper.Map<GetReservationTableDto>(_repository.CreateReservationTable(_mapper.Map<ReservationTable>(dto)));
    }

    public GetReservationTableDto UpdateReservationTable(PutReservationTableDto dto)
    {
        return _mapper.Map<GetReservationTableDto>(_repository.UpdateReservationTable(_mapper.Map<ReservationTable>(dto)));
    }

    public GetReservationTableDto DeleteReservationTable(int id)
    {
        return _mapper.Map<GetReservationTableDto>(_repository.DeleteReservationTable(id));
    }
}