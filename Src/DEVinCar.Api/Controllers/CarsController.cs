using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.Entities.Enuns;
using DEVinCar.Domain.Validations.Security;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/car")]
[Authorize]

public class CarController : ControllerBase
{
   
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet("{carId}")]
    [PermissaoAuthorize(Permission.Gerente)]
    public ActionResult<Car> GetById([FromRoute] int carId)
    {
        
        var car = _carService.GetCarById(carId);
        if (car == null) return NotFound();
        return Ok(car);
    }

    [HttpGet]
    [Authorize(Roles ="Gerente")] 
    public ActionResult<List<Car>> Get([FromQuery] string name, [FromQuery] decimal? priceMin,[FromQuery] decimal? priceMax)
    {
        var car= _carService.GetGeralViewCar(name,priceMin,priceMax );
        return Ok(car);
    }

    [HttpPost]
    [AllowAnonymous]
    public ActionResult<Car> Post([FromBody] CarDTO body)
    {

        var car = new CarDTO
        {
            Name = body.Name,
            SuggestedPrice = body.SuggestedPrice,
        };
        if(ModelState.IsValid)
        {           
            _carService.Insert(car);          

        }else{
            BadRequest();
        }
        return Created("api/car", car);
        
    }

    [HttpDelete("{carId}")]
    [AllowAnonymous]
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
    [AllowAnonymous]
    public ActionResult<Car> Put([FromBody] CarDTO carDto, [FromRoute] int carId)
    {
        var car = _carService.GetCarById(carId);
        if (car == null)
            return NotFound();
        if (carDto.Name.Equals(null) || carDto.SuggestedPrice.Equals(null))
            return BadRequest();
        if (carDto.SuggestedPrice <= 0)
            return BadRequest();
        car.Name = carDto.Name;
        car.SuggestedPrice = carDto.SuggestedPrice;      
        return NoContent();
    }
}
