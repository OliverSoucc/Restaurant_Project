using System.Text.Json.Serialization;
using Application.DTOs;
using Application.DTOs.Dish;
using Application.DTOs.Dishes;
using Application.DTOs.Ingredient;
using Application.DTOs.Reservation;
using Application.DTOs.ReservationTable;
using AutoMapper;
using Domain;
using FluentValidation;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<RestaurantDbContext>();
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var mapper = new MapperConfiguration(configure =>
{
    configure.CreateMap<GetDishDto, Dish>();
    configure.CreateMap<GetIngredientDto, Ingredient>();
    configure.CreateMap<PostDishIngredientDto, DishIngredient>();
    configure.CreateMap<Ingredient, GetIngredientDto>();
    configure.CreateMap<PostIngredientDto, Ingredient>();
    configure.CreateMap<Dish, GetDishDto>()
        .ForMember(dto => dto.Ingredients, d => d.MapFrom(d => d.Ingredients.Select(di => di.Ingredient)));
    configure.CreateMap<PutReservationDto, Reservation>();
    configure.CreateMap<ReservationDTO, Reservation>();
    configure.CreateMap<PutReservationTableDto, ReservationTable>();
    configure.CreateMap<ReservationTableDTO, ReservationTable>();
    configure.CreateMap<ReservationTable, ReservationTableDTO>();
    configure.CreateMap<PutIngredientDto, Ingredient>();
    configure.CreateMap<PostDishDto, Dish>();
    configure.CreateMap<PutDishDto, Dish>();
    configure.CreateMap<Reservation, GetReservationDto>();
    configure.CreateMap<ReservationTable, GetReservationTableDto>();
}).CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddCors();


Application.DependencyResolver.DependencyResolverService.RegisterApplicationLayer(builder.Services);
Infrastructure.DependencyResolver.DependencyResolverService.RegisterInfrastructureLayer(builder.Services);

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();