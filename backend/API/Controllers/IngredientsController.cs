using Application.Interfaces.Repositories;
using Application.Validators;
using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController: ControllerBase
{
    private readonly IIngredientService _service;
    private readonly IngredientValidator _validator;
    
    public IngredientsController(IIngredientService service, IngredientValidator validator)
    {
        _validator = validator;
        _service = service;
    }
    
    [HttpGet]
    public ActionResult<List<Ingredient>> GetAllIngredients()
    {
        return Ok(_service.GetAllIngredients());
    }

    [HttpPost]
    public ActionResult<Ingredient> CreateNewIngredient([FromBody] IngredientDTO dto)
    {
        try
        {
            var validation = _validator.Validate(dto);
            if (!validation.IsValid) throw new ValidationException(validation.ToString());

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
    public ActionResult<Ingredient> GetIngredient([FromRoute]int id)
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
}