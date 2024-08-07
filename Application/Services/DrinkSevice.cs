using AutoMapper;
using Contract.Dtos.DrinkDtos;
using Domain.Entities;
using Domain.MockData;
using Contract.Interfaces.IServices;
namespace Application.Services
{
    public class DrinkSevice : IDrinkService
    {
        private readonly IMapper _mapper;

        public DrinkSevice(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<DrinkDto> Get()
        {
            IEnumerable<Drink> drinks = DrinkMockData.Get();
            return _mapper.Map<List<DrinkDto>>(drinks);
        }

        public DrinkDto GetById(int id)
        {
            Drink drink = DrinkMockData.GetById(id) ?? 
                throw new Exception($"Drink with Id {id} not found.");

            return _mapper.Map<DrinkDto>(drink);
        }

        public DrinkDto Create(CreateDrinkDto entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }

            if (entity.Price <= 0) 
            {
                throw new Exception("Price less than zero.");
            }

            Drink drink = _mapper.Map<Drink>(entity);
            return _mapper.Map<DrinkDto>(DrinkMockData.Create(drink));
        }

        public DrinkDto Update(UpdateDrinkDto entity)
        {
            if (!DrinkMockData.IsExists(entity.Id))
            {
                throw new Exception("Entity not found.");
            }

            Drink drink = _mapper.Map<Drink>(entity);
            return _mapper.Map<DrinkDto>(DrinkMockData.Update(drink));
        }

        public bool DeleteById(int id)
        {
            if (!DrinkMockData.IsExists(id))
            {
                throw new Exception("Entity not found.");
            }

            Drink drink = DrinkMockData.GetById(id)!;
            return DrinkMockData.Delete(drink);
        }
    }
}
