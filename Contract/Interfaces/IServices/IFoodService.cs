using Contract.Dtos.DrinkDtos;
using Contract.Dtos.FoodDtos;

namespace Contract.Interfaces.IServices
{
    public interface IFoodService
    {
        // Get
        IEnumerable<FoodDto> Get();
        FoodDto GetById(int id);

        // Create
        FoodDto Create(CreateFoodDto entity);

        // Update
        FoodDto Update(UpdateFoodDto entity);

        // Delete
        bool DeleteById(int id);
    }
}
