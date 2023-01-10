using Application.DTOs;
using Application.DTOs.Reservation;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Validators.ReservationValidators;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReservationsController: ControllerBase
{
    private readonly IReservationService _service;
    private readonly ReservationValidator _validator;
    private readonly PutReservationValidator _putReservationValidator;
    
    public ReservationsController(IReservationService service, ReservationValidator validator, PutReservationValidator putReservationValidator)
    {
        _validator = validator;
        _service = service;
        _putReservationValidator = putReservationValidator;
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
            var validation = _validator.Validate(dto);
            
            if (validation.IsValid)
            {
                var result = _service.CreateReservation(dto);
                return Created("reservations/" + result.Id, result);   
            }
            
            return BadRequest(validation.ToString());
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
            var validation = _putReservationValidator.Validate(dto);
            if (validation.IsValid)
            {
                var result = _service.UpdateReservation(dto);
                return Ok(result);   
            }

            return BadRequest(validation.ToString());
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