using API.Controllers;
using Application.DTOs;
using Application.DTOs.Reservation;
using Application.Interfaces.Services;
using Application.Validators.ReservationValidators;
using AutoMapper;
using Domain;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.Tests.Controllers;

public class ReservationControllerTests
{
    private readonly ReservationsController _controller;
    private readonly IReservationService _service;
    private readonly IMapper _mapper;
    private readonly ReservationValidator _validator;
    private readonly PutReservationValidator _putReservationValidator;
    public ReservationControllerTests()
    {
        _service = A.Fake<IReservationService>();
        _validator = A.Fake<ReservationValidator>();
        _putReservationValidator = A.Fake<PutReservationValidator>();
        _controller = new ReservationsController(_service, _validator, _putReservationValidator);
        _mapper = A.Fake<IMapper>();
    }
    [Fact]
    public void ReservationsController_GetReservations_ReturnOk()
    {
        // Arrange
        var reservations = A.Fake<ICollection<Reservation>>();
        var reservationList = A.Fake<List<GetReservationDto>>();
        A.CallTo(() => _mapper.Map<List<GetReservationDto>>(reservations)).Returns(reservationList);
        // Act
        var result = _controller.GetReservations();
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }
    
    [Fact]
    public void ReservationsController_CreateReservation_ReturnCreated()
    {
        // Arrange
        var postReservationDto = A.Fake<ReservationDTO>();
        var getReservationDto = A.Fake<GetReservationDto>();
        // Act
        A.CallTo(() => _service.CreateReservation(postReservationDto)).Returns(getReservationDto);
        var result = _controller.CreateReservation(postReservationDto);
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeOfType(typeof(BadRequestResult));
        result.Should().BeOfType(typeof(CreatedResult));
    }

    [Fact]
    public void ReservationsController_GetReservation_ReturnOk()
    {
        // Arrange
        var reservationId = 1;
        // Act
        var result = _controller.GetReservation(reservationId);
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeOfType(typeof(BadRequestResult));
        result.Should().BeOfType(typeof(OkObjectResult));
    }

    [Fact]
    public void ReservationsController_UpdateReservation_ReturnOk()
    {
        // Arrange
        var putReservationDto = A.Fake<PutReservationDto>();
        // Act
        var result = _controller.UpdateReservation(putReservationDto);
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeOfType(typeof(BadRequestResult));
        result.Should().BeOfType(typeof(OkObjectResult));
    }
}