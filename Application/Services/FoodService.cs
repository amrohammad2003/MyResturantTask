using Contract.Interfaces.IServices;
using AutoMapper;
using Contract.Dtos.FoodDtos;
using Domain.Entities;
using Domain.MockData;
namespace Application.Services
{
    public class FoodService : IFoodService
    {
        private readonly IMapper _mapper;

        public FoodService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<FoodDto> Get()
        {
            IEnumerable<Food> foods = FoodMockData.Get();
            return _mapper.Map<List<FoodDto>>(foods);
        }

        public FoodDto GetById(int id)
        {
            Food food = FoodMockData.GetById(id) ??
                throw new Exception($"Food with Id {id} not found.");

            return _mapper.Map<FoodDto>(food);
        }

        public FoodDto Create(CreateFoodDto entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }

            if (entity.Price <= 0)
            {
                throw new Exception("Price less than zero.");
            }

            Food food = _mapper.Map<Food>(entity);
            return _mapper.Map<FoodDto>(FoodMockData.Create(food));
        }

        public FoodDto Update(UpdateFoodDto entity)
        {
            if (!FoodMockData.IsExists(entity.Id))
            {
                throw new Exception("Entity not found.");
            }

            Food food = _mapper.Map<Food>(entity);
            return _mapper.Map<FoodDto>(FoodMockData.Update(food));
        }

        public bool DeleteById(int id)
        {
            if (!FoodMockData.IsExists(id))
            {
                throw new Exception("Entity not found.");
            }

            Food food = FoodMockData.GetById(id)!;
            return FoodMockData.Delete(food);
        }
    }
}
