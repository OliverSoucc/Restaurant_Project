using Application.Interfaces.Services;
using Application.DTOs.Ingredient;
using AutoMapper;
using Domain;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;
namespace Application;

public class IngredientService: IIngredientService
{
    private readonly IIngredientRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<GetIngredientDto> _validator;
    

    public IngredientService(IIngredientRepository repository, IMapper mapper, IValidator<GetIngredientDto> validator)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    
    }
    
    public Ingredient CreateNewIngredient(GetIngredientDto getIngredientDto)
    {
        var validation = _validator.Validate(getIngredientDto);
        if (!validation.IsValid)
        {
            throw new ValidationException(validation.ToString());
        }

        return _repository.CreateNewIngredient(_mapper.Map<Ingredient>(getIngredientDto));

    }

    public List<Ingredient> GetAllIngredients()
    {
        return _repository.GetAllIngredients();
    }

    public Ingredient GetIngredient(int id)
    {
        return _repository.GetIngredient(id);
    }
    
}