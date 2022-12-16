using Application.DTOs;
using Application.DTOs.Reservation;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReservationsController: ControllerBase
{
    private readonly IReservationService _service;
    
    public ReservationsController(IReservationService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult GetReservations()
    {
        try
        {
            return Ok(_service.GetReservations());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetReservation([FromRoute] int id)
    {
        try
        {
            return Ok(_service.GetReservation(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public ActionResult CreateReservation([FromBody] ReservationDTO dto)
    {
        try
        {
            var result = _service.CreateReservation(dto);
            return Created("reservations/" + result.Id, result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public ActionResult UpdateReservation([FromBody] PutReservationDto dto)
    {
        try
        {
            var result = _service.UpdateReservation(dto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteReservation([FromRoute] int id)
    {
        try
        {
            var result = _service.DeleteReservation(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}