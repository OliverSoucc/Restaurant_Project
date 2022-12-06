using Application.Interfaces.Repositories;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;
namespace Application;

public class IngredientService: IIngredientService
{
    private readonly IIngredientRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<IngredientDTO> _validator;
    

    public IngredientService(IIngredientRepository repository, IMapper mapper, IValidator<IngredientDTO> validator)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    
    }
    
    public Ingredient CreateNewIngredient(IngredientDTO ingredientDto)
    {
        var validation = _validator.Validate(ingredientDto);
        if (!validation.IsValid)
        {
            throw new ValidationException(validation.ToString());
        }

        return _repository.CreateNewIngredient(_mapper.Map<Ingredient>(ingredientDto));

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