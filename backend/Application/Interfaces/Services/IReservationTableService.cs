using Application.DTOs;
using Application.DTOs.ReservationTable;
using Domain;

namespace Application.Interfaces.Services;

public interface IReservationTableService
{
    public ICollection<ReservationTable> GetReservationTables();
    public ReservationTable GetReservationTable(int id);
    public ReservationTable CreateReservationTable(ReservationTableDTO dto);
    public ReservationTable UpdateReservationTable(PutReservationTableDto dto);
    public ReservationTable DeleteReservationTable(int id);
}