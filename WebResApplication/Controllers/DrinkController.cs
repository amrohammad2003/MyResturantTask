using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Contract.Dtos.DrinkDtos;
using Contract.Interfaces.IServices;

namespace Controller
{
    [ApiController]
    [Route("api/Drink")]
    public class DrinkController : ControllerBase
    {
        private readonly IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<DrinkDto> drinks = _drinkService.Get();
                return Ok(drinks);
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
                DrinkDto drink = _drinkService.GetById(id);
                return Ok(drink);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDrinkDto creatDrinkDto)
        {
            try
            {
                DrinkDto drink = _drinkService.Create(creatDrinkDto);
                return Ok(drink);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(UpdateDrinkDto updateDrinkDto) 
        {
            try
            {
                DrinkDto drink = _drinkService.Update(updateDrinkDto);
                return Ok(drink);
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
                bool isDeleted = _drinkService.DeleteById(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
