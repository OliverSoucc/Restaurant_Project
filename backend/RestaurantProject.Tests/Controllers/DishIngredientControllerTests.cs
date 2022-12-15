using API.Controllers;
using Application.DTOs;
using Application.DTOs.Dishes;
using Application.Interfaces.Services;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.Tests.Controllers;

public class DishIngredientControllerTests
{
    private readonly DishIngredientController _controller;
    private readonly IDishIngredientService _service;
    
    public DishIngredientControllerTests()
    {
        _service = A.Fake<IDishIngredientService>();
        _controller = new DishIngredientController(_service);
    }

    [Fact]
    public void DishIngredientController_AddDishIngredient_ReturnOk()
    {
        // Arrange
        var postDishIngredient = A.Fake<PostDishIngredientDto>();
        var getDishDto = A.Fake<GetDishDto>();
        // Act
        A.CallTo(() => _service.AddDishIngredient(postDishIngredient)).Returns(getDishDto);
        var result = _controller.AddDishIngredient(postDishIngredient);
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeOfType(typeof(BadRequestResult));
        result.Should().BeOfType(typeof(OkObjectResult));
    }
}