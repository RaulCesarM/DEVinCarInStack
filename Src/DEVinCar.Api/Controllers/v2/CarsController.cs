using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.Entities.Enuns;
using DEVinCar.Domain.Validations.Security;
using AutoMapper;


namespace DEVinCar.Api.Controllers.v2;


[ApiController]
[Route("API/v{version:apiVersion}/car")]
[ApiVersion("2", Deprecated = true)]
[Authorize]
public class CarController : ControllerBase
{

    private readonly ICarService _carService;
    private readonly IMapper _mapper;

    public CarController(ICarService carService, IMapper mapper)
    {
        _mapper = mapper;
        _carService = carService;
    }

    [HttpGet("{carId}")]
    [AllowAnonymous]
    public ActionResult<CarDTO> GetById([FromRoute] int carId)
    {
        try
        {
            return Ok(_mapper.Map<CarDTO>(_carService.GetCarById(carId)));

        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public ActionResult<List<CarDTO>> Get([FromQuery] string name, [FromQuery] decimal? priceMin, [FromQuery] decimal? priceMax, int skip = 0, int take = 5)
    {
        try
        {
            var page = new Pagination(take, skip);
            var Total = _carService.GetTotal();
            Response.Headers.Add("X-Paginacao-TotalRegistros", Total.ToString());
            var car = _carService.GetGeralViewCarPage(name, priceMin, priceMax, page);
            return Ok(car);

        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    [PermissaoAuthorize(Permission.Administrador)]
    public ActionResult<Car> Post([FromBody] CarDTO car)
    {
        try
        {
            _carService.Insert(_mapper.Map<CarDTO>(car));
            return StatusCode(StatusCodes.Status201Created);

        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

    }

    [HttpDelete("{carId}")]
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult Delete([FromRoute] int carId)
    {

        _carService.Remove(carId);
        if (_carService.GetById(carId) == null)
        {

            return Ok($"removed with successor,{carId}");
        }
        else
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }



    }

    [HttpPut("{carId}")]
   // [AllowAnonymous]
     [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult<Car> EditCarNameOrPrice([FromBody] CarDTO carDto, [FromRoute] int carId)
    {
        try
        {
            var car = _carService.GetCarById(carId);
            car.Name = carDto.Name;
            car.SuggestedPrice = carDto.SuggestedPrice;

            _carService.Update(_mapper.Map<CarDTO>(car), carId);
            return Ok("Edited");

        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
