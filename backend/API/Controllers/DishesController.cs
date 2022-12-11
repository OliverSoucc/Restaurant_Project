using Application.Interfaces.Repositories;
using Application.DTOs;
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
    public List<Dish> GetDishes()
    {
        return _dishService.GetAllDishes();
    }

    [HttpPost]
    public ActionResult<Dish> CreateNewDish([FromBody]GetDishDto dto)
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