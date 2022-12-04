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

    [HttpGet]
    [Route("CreateDb")]
    public string CreateDb()
    {
        return _dishService.CreateDb();
    }

    [HttpPost]
    public ActionResult<Dish> CreateNewDish([FromBody]PostDishDTO dto)
    {
        try
        {
            var validation = _postDishValidator.Validate(dto);
            if (!validation.IsValid) throw new ValidationException(validation.ToString());

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