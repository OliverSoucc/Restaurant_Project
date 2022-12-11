using Application;
using Application.Interfaces.Repositories;
using Application.DTOs.Dishes;
using Domain;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DishIngredientController: ControllerBase
{

    private readonly IDishIngredientService _service;
    public DishIngredientController(IDishIngredientService service)
    {
        _service = service;
    }

    [HttpPost]
    public ActionResult<Dish> AddDishIngredient(PostDishIngredientDto dto)
    {
        return Ok(_service.AddDishIngredient(dto));
    }
}