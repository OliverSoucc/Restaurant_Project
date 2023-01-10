using Application.DTOs;
using Application.DTOs.Dish;
using Application.Interfaces.Services;
using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DishesController : ControllerBase
{
    private IDishService _dishService;
    private PostDishValidator _postDishValidator;
    private PutDishValidator _putDishValidator;

    public DishesController(IDishService dishService, PostDishValidator postDishValidator, PutDishValidator putDishValidator)
    {
        _putDishValidator = putDishValidator;
        _dishService = dishService;
        _postDishValidator = postDishValidator;
    }

    [HttpGet]
    public IActionResult GetDishes()
    {
        try
        {
            var dishes = _dishService.GetAllDishes();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(dishes);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetDish([FromRoute]int id)
    {
        try
        {
            var result = _dishService.GetDish(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateNewDish([FromBody]PostDishDto dto)
    {
        try
        {
            var validation = _postDishValidator.Validate(dto);
            if (validation.IsValid)
            {
                var result = _dishService.CreateNewDish(dto);
                return Created("dishes/" + result.Id, result);   
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

    [HttpPut]
    public ActionResult UpdateDish([FromBody] PutDishDto dto)
    {
        try
        {
            var validation = _putDishValidator.Validate(dto);
            if (validation.IsValid)
            {
                var result = _dishService.UpdateDish(dto);
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
    public ActionResult<Dish> DeleteDish([FromRoute] int id)
    {
        try
        {
            var result = _dishService.DeleteDish(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}