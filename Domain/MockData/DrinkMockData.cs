using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MockData
{
    public static class DrinkMockData
    {
        private static List<Drink>  Drinks = new()
        {
                new()
                {
                        Id = 1,
                        Name="Cola",
                        Price =5,
                        Size = "L"
                },
                new()
                {
                        Id = 2,
                        Name="Sprit",
                        Price =10,
                        Size = "S"
                },
                new()
                {
                    Id = 3,
                    Name = "Chat",
                    Price = 4,
                    Size = "M"
                }
        };

        public static IEnumerable<Drink> Get()
        {
            return Drinks;
        }

        public static Drink? GetById(int id)
        {
            return Drinks.Where(d => d.Id.Equals(id)).FirstOrDefault();
        }

        public static Drink? Create(Drink entity)
        {
            entity.Id = Drinks.Max(d => d.Id) + 1;
            Drinks.Add(entity);
            return entity;
        }

        public static Drink Update(Drink entity)
        {
            Drink drinkToUpdate = Drinks.Where(d => d.Id == entity.Id).First()!;
            drinkToUpdate.Price = entity.Price;
            drinkToUpdate.Size = entity.Size;
            drinkToUpdate.Name = entity.Name;

            return drinkToUpdate;
        }

        public static bool Delete(Drink entity)
        {
            Drinks.Remove(entity);
            return true;
        }

        public static bool IsExists(int id) 
        {
            return Drinks.Any(d => d.Id == id);
        }
    }
}
