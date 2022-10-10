
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/car")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService _carService)
    {
        this._carService = _carService;
    }

    [HttpGet("{carId}")]
    public ActionResult<Car> GetById([FromRoute] int carId)
    {
        var car = _carService.GetCarById(carId);
        if (car == null) return NotFound();
        return Ok(car);
    }

    [HttpGet]
    public ActionResult<List<Car>> Get(
        [FromQuery] string name,
        [FromQuery] decimal? priceMin,
        [FromQuery] decimal? priceMax
    )
    {

       var car= _carService.GetGeralViewCar(name,priceMin,priceMax );
        return Ok(car);
    }

    [HttpPost]
    public ActionResult<Car> Post([FromBody] CarDTO body)
    {
      
        var car = new CarDTO
        {
            Name = body.Name,
            SuggestedPrice = body.SuggestedPrice,
        };
        _carService.Insert(car);
        
        return Created("api/car", car);
    }

    [HttpDelete("{carId}")]
    public ActionResult Delete([FromRoute] int carId)
    {
              
        _carService.Remove(carId);

        var car = _carService.GetCarById(carId);
        if(car !=null){
            return BadRequest();
        }
             
      
        return Ok();
    }















    [HttpPut("{carId}")]
    public ActionResult<Car> Put([FromBody] CarDTO carDto,
                                 [FromRoute] int carId)
    {
        var car = _carService.GetCarById(carId);
        //var name = _carService.Cars.Any(c => c.Name == carDto.Name && c.Id != carId);


        if (car == null)
            return NotFound();
        if (carDto.Name.Equals(null) || carDto.SuggestedPrice.Equals(null))
            return BadRequest();
        if (carDto.SuggestedPrice <= 0)
            return BadRequest();/*
        if (name)
            return BadRequest();*/

        car.Name = carDto.Name;
        car.SuggestedPrice = carDto.SuggestedPrice;

       // _context.SaveChanges();
        return NoContent();
    }
}
