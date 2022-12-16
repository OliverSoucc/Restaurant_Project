using Application.DTOs;
using Application.DTOs.ReservationTable;
using Application.Interfaces.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationTableController: ControllerBase
{
    private readonly IReservationTableService _service;
    public ReservationTableController(IReservationTableService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult GetReservationTables()
    {
        try
        {
            var result = _service.GetReservationTables();
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetReservationTable([FromRoute] int id)
    {  
        try
        {
            var result = _service.GetReservationTable(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    public ActionResult CreateReservationTable([FromBody] ReservationTableDTO dto)
    {
        try
        {
            var result = _service.CreateReservationTable(dto);
            return Created("reservationTables/" + result.Id, result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public ActionResult UpdateReservationTable([FromBody] PutReservationTableDto dto)
    {
        try
        {
            var result = _service.UpdateReservationTable(dto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteReservationTable([FromRoute]int id)
    {
        try
        {
            var result = _service.DeleteReservationTable(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}