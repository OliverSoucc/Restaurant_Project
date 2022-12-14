using Application.Interfaces.Repositories;
using Application.DTOs.Ingredient;
using Application.Interfaces.Services;
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
    
    public GetIngredientDto CreateNewIngredient(GetIngredientDto getIngredientDto)
    {
        var validation = _validator.Validate(getIngredientDto);
        if (!validation.IsValid)
        {
            throw new ValidationException(validation.ToString());
        }

        return _mapper.Map<GetIngredientDto>(_repository.CreateNewIngredient(_mapper.Map<Ingredient>(getIngredientDto)));

    }

    public List<GetIngredientDto> GetAllIngredients()
    {
        var ingredients = _repository.GetAllIngredients();
        return _mapper.Map<List<GetIngredientDto>>(ingredients);
    }

    public GetIngredientDto GetIngredient(int id)
    {
        return _mapper.Map<GetIngredientDto>(_repository.GetIngredient(id));
    }

    public GetIngredientDto UpdateIngredient(PutIngredientDto dto)
    {
        return _mapper.Map<GetIngredientDto>(_repository.UpdateIngredient(_mapper.Map<Ingredient>(dto)));
    }

    public GetIngredientDto DeleteIngredient(int id)
    {
        return _mapper.Map<GetIngredientDto>(_repository.DeleteIngredient(id));
    }
}