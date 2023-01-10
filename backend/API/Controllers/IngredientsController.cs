using Application.DTOs;
using Application.DTOs.Ingredient;
using Application.DTOs.IngredientValidators;
using Application.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController: ControllerBase
{
    private readonly IIngredientService _service;
    private readonly PutIngredientValidator _putIngredientValidator;
    private readonly IngredientValidator _validator;

    public IngredientsController(IIngredientService service, PutIngredientValidator putIngredientValidator, IngredientValidator validator)
    {
        _putIngredientValidator = putIngredientValidator;
        _service = service;
        _validator = validator;
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
            var validation = _validator.Validate(dto);
            if (validation.IsValid)
            {
                var result = _service.CreateNewIngredient(dto);
                return Created("ingredients/" + result.Id, result);   
            }

            return BadRequest(validation.ToString());
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
            var validation = _putIngredientValidator.Validate(dto);
            if (validation.IsValid)
            {
                var result = _service.UpdateIngredient(dto);
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