using API.Controllers;
using Application;
using Application.DTOs;
using Application.DTOs.Dish;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain;
using FakeItEasy;
using FluentAssertions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.Tests.Controllers;

public class DishesControllerTests
{
    private readonly IMapper _mapper;
    private readonly DishesController _dishesController;
    
    public DishesControllerTests()
    {
        var repository = A.Fake<IDishRepository>();
        _mapper = A.Fake<IMapper>();
        var validator = A.Fake<IValidator<GetDishDto>>();
        var postDishValidator = A.Fake<PostDishValidator>();
        var dishService = new DishService(repository, _mapper, validator);
        _dishesController = new DishesController(dishService, postDishValidator);
    }

    [Fact]
    public void DishesController_GetDishes_ReturnOk()
    {
        // Arrange
        var dishes = A.Fake<ICollection<Dish>>();
        var dishList = A.Fake<List<GetDishDto>>();
        A.CallTo(() => _mapper.Map<List<GetDishDto>>(dishes)).Returns(dishList);
        // Act
        var result = _dishesController.GetDishes();
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }

    [Fact]
    public void DishesController_CreateDish_ReturnCreated()
    {
        // Arrange
        var postDishDto = A.Fake<PostDishDto>();
        // Act
        var result = _dishesController.CreateNewDish(postDishDto);
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeOfType(typeof(BadRequestResult));
        result.Should().BeOfType(typeof(CreatedResult));
    }

    [Fact]
    public void DishesController_GetDish_ReturnOk()
    {
        // Arrange
        var dishId = 1;
        // Act
        var result = _dishesController.GetDish(dishId);
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeOfType(typeof(BadRequestResult));
        result.Should().BeOfType(typeof(OkObjectResult));
    }

    [Fact]
    public void DishesController_UpdateDish_ReturnOk()
    {
        // Arrange
        var putDishDto = A.Fake<PutDishDto>();
        // Act
        var result = _dishesController.UpdateDish(putDishDto);
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeOfType(typeof(BadRequestResult));
        result.Should().BeOfType(typeof(OkObjectResult));
    }
}