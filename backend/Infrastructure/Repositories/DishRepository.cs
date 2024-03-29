﻿using Application.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DishRepository : IDishRepository
{
    private readonly RestaurantDbContext _context;

    public DishRepository(RestaurantDbContext context)
    {
        _context = context;
    }

    public List<Dish> GetAllDishes()
    {
        return _context.Dishes
            .Include(d => d.Ingredients)
            .ThenInclude(di => di.Ingredient)
            .ToList();
    }

    public Dish GetDish(int id)
    {
        var result = _context.Dishes
            .Include(d => d.Ingredients)
            .ThenInclude(di => di.Ingredient)
            .FirstOrDefault();
        if (result == null) throw new ArgumentException("Dish with provided Id was not found");
        return result;
    }

    public Dish CreateNewDish(Dish dish)
    {
        _context.Dishes.Add(dish);
        _context.SaveChanges();
        
        return dish;
    }

    public Dish DeleteDish(int id)
    {
        var result = _context.Dishes.Find(id);
        if (result == null) throw new ArgumentException("Dish with provided Id was not found");
        _context.Dishes.Remove(result);
        _context.SaveChanges();
        return result;
    }

    public Dish UpdateDish(Dish dish)
    {
        var dishs = _context.Dishes.Update(dish);
        _context.SaveChanges();
        
        return dish;
    }
}