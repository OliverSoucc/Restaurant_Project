using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Application;

public class DishService: IDishService
{
    private IDishRepository _repository;
    private IMapper _mapper;
    private IValidator<PostDishDTO> _postValidator;
    public DishService(IDishRepository repository, IMapper mapper, IValidator<PostDishDTO> postValidator)
    {
        _repository = repository;
        _mapper = mapper;
        _postValidator = postValidator;
    }
    public List<Dish> GetAllDishes()
    {
        return _repository.GetAllDishes();
    }

    public Dish CreateNewDish(PostDishDTO dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
        {
            throw new ValidationException(validation.ToString());
        }
        
        return _repository.CreateNewDish(_mapper.Map<Dish>(dto));
    }

    public string CreateDb()
    {
        return _repository.CreateDb();
    }
}