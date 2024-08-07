using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Contract.Dtos.FoodDtos;
using Contract.Interfaces.IServices;

namespace Controller
{
    [ApiController]
    [Route("api/Food")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<FoodDto> foods = _foodService.Get();
                return Ok(foods);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                FoodDto drink = _foodService.GetById(id);
                return Ok(drink);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateFoodDto creatDrinkDto)
        {
            try
            {
                FoodDto drink = _foodService.Create(creatDrinkDto);
                return Ok(drink);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(UpdateFoodDto updateFoodDto)
        {
            try
            {
                FoodDto food = _foodService.Update(updateFoodDto);
                return Ok(food);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                bool isDeleted = _foodService.DeleteById(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
