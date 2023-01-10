using Application.DTOs;
using Application.DTOs.ReservationTable;
using Application.Interfaces.Services;
using Application.Validators.ReservationTableValidators;
using Domain;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationTableController: ControllerBase
{
    private readonly IReservationTableService _service;
    private readonly PostReservationTableValidator _postReservationTableValidator;
    private readonly PutReservationTableValidator _putReservationTableValidator;
    public ReservationTableController(IReservationTableService service, PostReservationTableValidator postReservationTableValidator, PutReservationTableValidator putReservationTableValidator)
    {
        _postReservationTableValidator = postReservationTableValidator;
        _putReservationTableValidator = putReservationTableValidator;
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
            var validation = _postReservationTableValidator.Validate(dto);
            if (validation.IsValid)
            {
                var result = _service.CreateReservationTable(dto);
                return Created("reservationTables/" + result.Id, result);   
            }

            return BadRequest(validation.ToString());
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
            var validation = _putReservationTableValidator.Validate(dto);
            if (validation.IsValid)
            {
                var result = _service.UpdateReservationTable(dto);
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