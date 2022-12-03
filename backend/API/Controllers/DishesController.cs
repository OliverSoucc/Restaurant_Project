using Application.Validators;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class DishesController : ControllerBase
{
    private IDishService _dishService;

    public DishesController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpGet]
    public List<Dish> GetDishes()
    {
        return _dishService.GetAllDishes();
    }

    [HttpGet]
    [Route("CreateDb")]
    public string CreateDb()
    {
        return _dishService.CreateDb();
    }

    [HttpPost]
    public ActionResult<Dish> CreateNewDish(PostDishDTO dto)
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
    
}