using API.Controllers;
using Application.DTOs;
using Application.DTOs.ReservationTable;
using Application.Interfaces.Services;
using AutoMapper;
using Domain;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.Tests.Controllers;

public class ReservationTableControllerTests
{
    private readonly ReservationTableController _controller;
    private readonly IReservationTableService _service;
    private readonly IMapper _mapper;
    
    public ReservationTableControllerTests()
    {
        _mapper = A.Fake<IMapper>();
        _service = A.Fake<IReservationTableService>();
        _controller = new ReservationTableController(_service);
    }
    
    [Fact]
    public void ReservationTablesController_GetReservationTables_ReturnOk()
    {
        // Arrange
        var reservationTables = A.Fake<ICollection<ReservationTable>>();
        var reservationTableList = A.Fake<List<GetReservationTableDto>>();
        A.CallTo(() => _mapper.Map<List<GetReservationTableDto>>(reservationTables)).Returns(reservationTableList);
        // Act
        var result = _controller.GetReservationTables();
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }
    
    [Fact]
    public void ReservationTablesController_CreateReservationTable_ReturnCreated()
    {
        // Arrange
        var postReservationTableDto = A.Fake<ReservationTableDTO>();
        var getReservationTableDto = A.Fake<GetReservationTableDto>();
        // Act
        A.CallTo(() => _service.CreateReservationTable(postReservationTableDto)).Returns(getReservationTableDto);
        var result = _controller.CreateReservationTable(postReservationTableDto);
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeOfType(typeof(BadRequestResult));
        result.Should().BeOfType(typeof(CreatedResult));
    }

    [Fact]
    public void ReservationTablesController_GetReservationTable_ReturnOk()
    {
        // Arrange
        var reservationTableId = 1;
        // Act
        var result = _controller.GetReservationTable(reservationTableId);
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeOfType(typeof(BadRequestResult));
        result.Should().BeOfType(typeof(OkObjectResult));
    }

    [Fact]
    public void ReservationTablesController_UpdateReservationTable_ReturnOk()
    {
        // Arrange
        var putReservationTableDto = A.Fake<PutReservationTableDto>();
        // Act
        var result = _controller.UpdateReservationTable(putReservationTableDto);
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeOfType(typeof(BadRequestResult));
        result.Should().BeOfType(typeof(OkObjectResult));
    }
}