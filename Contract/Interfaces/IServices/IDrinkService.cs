using Contract.Dtos.DrinkDtos;

namespace Contract.Interfaces.IServices
{
    public interface IDrinkService
    {
        // Get
        IEnumerable<DrinkDto> Get();
        DrinkDto GetById(int id);

        // Create
        DrinkDto Create(CreateDrinkDto entity);

        // Update
        DrinkDto Update(UpdateDrinkDto entity);

        // Delete
        bool DeleteById(int id);
    }
}
