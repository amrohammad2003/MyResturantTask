using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MockData
{
    public static class FoodMockData
    {
        private static List<Food> Foods = new()
        {
            new()
            {
                Id = 1,
                Name = "Pizza",
                Price = 8,
            },
            new()
            {
                Id = 2,
                Name = "Burger",
                Price = 5,
            },
            new()
            {
                Id = 3,
                Name = "Salad",
                Price = 6,
            }
        };

        public static IEnumerable<Food> Get()
        {
            return Foods;
        }

        public static Food? GetById(int id)
        {
            return Foods.FirstOrDefault(f => f.Id == id);
        }

        public static Food? Create(Food entity)
        {
            entity.Id = Foods.Max(f => f.Id) + 1;
            Foods.Add(entity);
            return entity;
        }

        public static Food Update(Food entity)
        {
            Food foodToUpdate = Foods.First(f => f.Id == entity.Id)!;
            foodToUpdate.Price = entity.Price;
            foodToUpdate.Name = entity.Name;

            return foodToUpdate;
        }

        public static bool Delete(Food entity)
        {
            Foods.Remove(entity);
            return true;
        }

        public static bool IsExists(int id)
        {
            return Foods.Any(f => f.Id == id);
        }
    }
}
