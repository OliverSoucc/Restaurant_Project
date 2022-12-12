using Application.Interfaces.Repositories;
using Application.DTOs;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DishIngredientRepository: IDishIngredientRepository
{
    private readonly RestaurantDbContext _context;
    private readonly IMapper _mapper;
    
    public DishIngredientRepository(RestaurantDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public GetDishDto AddDishIngredient(DishIngredient dishIngredient)
    {
        Dish dish = _context.Dishes
            .Include(d => d.Ingredients).ThenInclude(di => di.Ingredient)
            .FirstOrDefault(d => d.Id == dishIngredient.DishId);
        if (dish == null) throw new Exception("Dish not found");

        Ingredient ingredient = _context.Ingredients
            .FirstOrDefault(i => i.Id == dishIngredient.IngredientId);
        if (ingredient == null) throw new Exception("Skill not found");

        DishIngredient newDishIngredient = new DishIngredient()
        {
            Dish = dish,
            Ingredient = ingredient
        };

        _context.DishIngredients.Add(newDishIngredient);
        _context.SaveChanges();
        
        return _mapper.Map<GetDishDto>(dish);
    }
}