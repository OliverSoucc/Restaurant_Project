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

    public DishesController(IDishService dishService, PostDishValidator postDishValidator)
    {
        _dishService = dishService;
        _postDishValidator = postDishValidator;
    }

    [HttpGet]
    public ActionResult<List<Dish>> GetDishes()
    {
        try
        {
            return Ok(_dishService.GetAllDishes());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Dish> GetDish([FromRoute]int id)
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
    public ActionResult<Dish> CreateNewDish([FromBody]PostDishDto dto)
    {
        try
        {
            var result = _dishService.CreateNewDish(dto);
            return Created("dishes/" + result.Id, result);
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
    public ActionResult<Dish> UpdateDish([FromBody] PutDishDto dto)
    {
        try
        {
            var result = _dishService.UpdateDish(dto);
            return Ok(result);
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