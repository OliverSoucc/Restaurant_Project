using Application.DTOs.Ingredient;

namespace Application.Interfaces.Services;
using Domain;

public interface IIngredientService
{
    public GetIngredientDto CreateNewIngredient(GetIngredientDto getIngredientDto);
    public List<GetIngredientDto> GetAllIngredients();
    public GetIngredientDto GetIngredient(int id);
    public GetIngredientDto UpdateIngredient(PutIngredientDto dto);
    public GetIngredientDto DeleteIngredient(int id);
}   