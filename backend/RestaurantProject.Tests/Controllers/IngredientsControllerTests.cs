using API.Controllers;
using Application.DTOs.Ingredient;
using Application.Interfaces.Services;
using AutoMapper;
using Domain;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.Tests.Controllers;

public class IngredientsControllerTests
{
    private readonly IngredientsController _controller;
    private readonly IMapper _mapper;
    private readonly IIngredientService _service;
    
    public IngredientsControllerTests()
    {
        _mapper = A.Fake<IMapper>();
        _service = A.Fake<IIngredientService>();
        _controller = new IngredientsController(_service);
    }
    
    [Fact]
    public void IngredientsController_GetIngredients_ReturnOk()
    {
        // Arrange
        var ingredients = A.Fake<ICollection<Ingredient>>();
        var ingredientList = A.Fake<List<GetIngredientDto>>();
        A.CallTo(() => _mapper.Map<List<GetIngredientDto>>(ingredients)).Returns(ingredientList);
        // Act
        var result = _controller.GetAllIngredients();
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }
    
    [Fact]
    public void IngredientsController_CreateIngredient_ReturnCreated()
    {
        // Arrange
        var postIngredientDto = A.Fake<PostIngredientDto>();
        var getIngredientDto = A.Fake<GetIngredientDto>();
        // Act
        A.CallTo(() => _service.CreateNewIngredient(postIngredientDto)).Returns(getIngredientDto);
        var result = _controller.CreateNewIngredient(postIngredientDto);
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeOfType(typeof(BadRequestResult));
        result.Should().BeOfType(typeof(CreatedResult));
    }

    [Fact]
    public void IngredientsController_GetIngredient_ReturnOk()
    {
        // Arrange
        var ingredientId = 1;
        // Act
        var result = _controller.GetIngredient(ingredientId);
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeOfType(typeof(BadRequestResult));
        result.Should().BeOfType(typeof(OkObjectResult));
    }

    [Fact]
    public void IngredientsController_UpdateIngredient_ReturnOk()
    {
        // Arrange
        var putIngredientDto = A.Fake<PutIngredientDto>();
        // Act
        var result = _controller.UpdateIngredient(putIngredientDto);
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeOfType(typeof(BadRequestResult));
        result.Should().BeOfType(typeof(OkObjectResult));
    }
}