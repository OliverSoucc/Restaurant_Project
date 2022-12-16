using Application.DTOs.Dishes;
using Application.Interfaces.Services;
using Domain;
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
    public ActionResult AddDishIngredient(PostDishIngredientDto dto)
    {
        return Ok(_service.AddDishIngredient(dto));
    }
}