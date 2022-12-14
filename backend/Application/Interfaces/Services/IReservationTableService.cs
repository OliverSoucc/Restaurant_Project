using Application.DTOs;
using Application.DTOs.ReservationTable;
using Domain;

namespace Application.Interfaces.Services;

public interface IReservationTableService
{
    public ICollection<GetReservationTableDto> GetReservationTables();
    public GetReservationTableDto GetReservationTable(int id);
    public GetReservationTableDto CreateReservationTable(ReservationTableDTO dto);
    public GetReservationTableDto UpdateReservationTable(PutReservationTableDto dto);
    public GetReservationTableDto DeleteReservationTable(int id);
}