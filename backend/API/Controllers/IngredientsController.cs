using Application.Interfaces.Repositories;
using Application.DTOs;
using Application.DTOs.Ingredient;
using Application.Interfaces.Services;
using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController: ControllerBase
{
    private readonly IIngredientService _service;

    public IngredientsController(IIngredientService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public ActionResult GetAllIngredients()
    {
        return Ok(_service.GetAllIngredients());
    }

    [HttpPost]
    public ActionResult CreateNewIngredient([FromBody] PostIngredientDto dto)
    {
        try
        {
            var result = _service.CreateNewIngredient(dto);
            return Created("ingredients/" + result.Id, result);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetIngredient([FromRoute]int id)
    {
        try
        {
            var result = _service.GetIngredient(id);
            return Ok(result);
        }
        catch (ArgumentException e)
        {
            return StatusCode(400, e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    public ActionResult UpdateIngredient([FromBody] PutIngredientDto dto)
    {
        try
        {
            var result = _service.UpdateIngredient(dto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteIngredient([FromRoute] int id)
    {
        try
        {
            var result = _service.DeleteIngredient(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}